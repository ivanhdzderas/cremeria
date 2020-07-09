using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caja.Forms;
using caja.Forms.Inventario;
using System.Runtime.InteropServices;
using caja.Models;

namespace caja
{
    public partial class inicial : Form
    {





        private int childFormNumber = 0;

        public inicial()
        {
            ;
            InitializeComponent();
        }
      
     
       
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        public static string conntxt;
        public static string connectionString;
        public static string web_string;

        public static string id_usario;
        public static Boolean cajero;
        private Point _imageLocation = new Point(22,5);
        private Point _imageHitArea = new Point(13,2);
        Image imagenCerado;
        public static string nombre;
        public static Boolean exit;

       
        private void inicial_Load(object sender, EventArgs e)
        {
            exit = false;
            cajero = false;
            Home.DrawItem += Home_DrawItem;
            imagenCerado = global::caja.Properties.Resources.close;
            conntxt = System.IO.File.ReadAllText(@"conn.txt");
            connectionString = conntxt;

            web_string = System.IO.File.ReadAllText(@"conn2.txt");


            Home.Padding= new System.Drawing.Point(13,8);
            login fc = new login();
            fc.Owner = this;
            fc.ShowDialog();
            if (exit == true)
            {

                Application.Exit();
            }
            else
            {
                Cortes cort = new Cortes();
                List<Cortes> existe = cort.getnoclose(Convert.ToInt16(id_usario));

                if (cajero == true)
                {
                    if (existe.Count > 0)
                    {

                    }
                    else
                    {
                        AbreCaja caja = new AbreCaja();
                        caja.Owner = this;
                        caja.ShowDialog();
                    }

                }

                Permisos permiso = new Permisos();
                List<Permisos> permisos = permiso.getPermiso(Convert.ToInt16(id_usario));



                if (Convert.ToBoolean(permisos[0].Mod_cli) == false)
                {
                    clientesToolStripMenuItem.Enabled = false;
                    toolStripButton2.Visible = false;
                }


                if (Convert.ToBoolean(permisos[0].Del_prod) == true
                    || Convert.ToBoolean(permisos[0].Mod_prod) == true
                    || Convert.ToBoolean(permisos[0].Nuevo_prod) == true
                    || Convert.ToBoolean(permisos[0].Ver_minimos) == true
                    || Convert.ToBoolean(permisos[0].Ver_mov_inv) == true

                    )
                {
                    inventarioToolStripMenuItem.Enabled = true;
                }
                else
                {
                    inventarioToolStripMenuItem.Enabled = false;
                }
                if (Convert.ToBoolean(permisos[0].Cobrar_ticket) == true
                    || Convert.ToBoolean(permisos[0].Cancelar_ticket) == true

                    )
                {
                    cajaMenu.Enabled = true;
                    toolStripButton1.Visible = true;
                }
                else
                {
                    cajaMenu.Enabled = false;
                    toolStripButton1.Visible = false;
                }
                facturasToolStripMenuItem.Enabled = true;
                catalogoMenu.Enabled = true;
                movimientosToolStripMenuItem.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;

                panel1.Visible = true;
                Menu.Visible = true;
                configuracionToolStripMenuItem.Enabled = true;
                Bienvenido.Text = "Bienvenido: " + nombre;
                busca_caducos();
                busca_pagos();
            }
            

        }
        public void busca_pagos()
        {
            Models.Compras compras = new Models.Compras();
            List<Models.Compras> compra = compras.getCompras_sin_pagar();
            if (compra.Count > 0)
            {
                noticacion("Proximos pagos a proveedores", "Tiene pagos por caducar");
            }
        }
        public void noticacion(string Titulo, string texto) {
            notifyIcon1.Text = "Notificaciones";
            notifyIcon1.BalloonTipTitle = Titulo;
            notifyIcon1.BalloonTipText = texto;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);
        }
        public void busca_caducos()
        {
            Product producto = new Product();
            List<Product> cad = producto.getCaducProducts();
            if (cad.Count > 0) {
                noticacion("Proximos productos caducos", "Tiene produtos por caducar");
            }

        }

        private void cajaMenu_Click(object sender, EventArgs e)
        {
            string tabName = "Venta";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                caja fc = new caja();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Inventario";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                inventario fc = new inventario();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Clientes";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                clientes fc = new clientes();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

       
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Proveedores";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Proveedores fc = new Proveedores();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Entradas";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Entradas fc = new Entradas();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Salidas";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Salidas fc = new Salidas();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string tabName = "Compras";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Compras fc = new Forms.Compras();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

 
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.MdiParent = this;
            about.Show();
        }

        private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Ajustes";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Ajustes fc = new Ajustes();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }
        public void borrar_Tab(string nombre) {
            TabPage tpage = new TabPage(nombre);
            Home.TabPages.Remove(tpage);
        }
        private void inventarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string tabName = "Reporte Inventarios";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Reportes.Inventario fc = new Forms.Reportes.Inventario();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
           
        }
        public static Boolean cancelado = false;
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                
                if (cajero == true)
                {
                    CerrarCaja cerr = new CerrarCaja();
                    cerr.Owner = this;
                    cerr.ShowDialog();

                }
                if (cancelado == false) {
                    this.Close();
                }
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string tabName = "Venta";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                
                if (name == tabName) {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;
                caja fc = new caja();
                fc.TopLevel = false;
                fc.Visible = true;

                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
            
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string tabName = "Clientes";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                clientes fc = new clientes();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string tabName = "Inventario";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                inventario fc = new inventario();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

     

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string tabName = "Compras";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Compras fc = new Forms.Compras();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void inventarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string tabName = "Reporte Proveedores";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Reportes.Proveedores fc = new Forms.Reportes.Proveedores();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

    

      

        private void Home_DrawItem(object sender, DrawItemEventArgs e)
        {

            try {
                Image img = new Bitmap(imagenCerado);
                Rectangle r = e.Bounds;
                r = this.Home.GetTabRect(e.Index);
                r.Offset(1, 5);
                string title = this.Home.TabPages[e.Index].Text;
                Font f = this.Font;
                Brush titleBrush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(title, f, titleBrush, new PointF(r.X,r.Y));
               
                e.Graphics.DrawImage(img, new Point(r.X+(r.Width - _imageLocation.X),_imageLocation.Y));
               
            } catch (Exception ex) { }



        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.Home.GetTabRect(tc.SelectedIndex).Width - (_imageHitArea.X);
            Rectangle r = this.Home.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, _imageHitArea.Y);
            r.Width = 16;
            r.Height = 16;
           
                if (r.Contains(p))
                { 
                    TabPage tabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(tabP);
                }
           
          
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string tabName = "Reporte Clientes";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;
                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Reportes.Clientes fc = new Forms.Reportes.Clientes();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Usuarios";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Usuarios fc = new Usuarios();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void gruposYSubgruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Grupos";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Grupos fc = new Grupos();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Configuracion";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                configuracion fc = new configuracion();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void btnCorteTurno_Click(object sender, EventArgs e)
        {
            string tabName = "Corte de Caja";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Reportes.Cierre_caja fc = new Forms.Reportes.Cierre_caja();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void corteCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Corte de Caja";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Reportes.Cierre_caja fc = new Forms.Reportes.Cierre_caja();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Pagos Prov.";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Pagos_proveedores fc = new Pagos_proveedores();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Sucursales";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Sucursales fc = new Sucursales();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void traspasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Traspasos";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Traspasos fc = new Traspasos();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Facturas";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Facturas fc = new Forms.Facturas();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }

        private void levantarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabName = "Levantar";
            Boolean encontrado = false;
            foreach (TabPage page in Home.TabPages)
            {
                string name = page.Name;

                if (name == tabName)
                {
                    encontrado = true;
                    Home.SelectTab(tabName);
                }
            }
            if (encontrado == false)
            {
                TabPage tpage = new TabPage(tabName);
                tpage.Name = tabName;

                Forms.Levantar_inventario fc = new Forms.Levantar_inventario();
                fc.TopLevel = false;
                fc.Visible = true;
                fc.MdiParent = this;
                fc.FormBorderStyle = FormBorderStyle.None;
                fc.Dock = DockStyle.Fill;
                Home.TabPages.Add(tpage);
                int ultimo = (Home.TabPages.Count - 1);
                Home.TabPages[ultimo].Controls.Add(fc);
                Home.SelectTab(tabName);
            }
        }
    }
}
