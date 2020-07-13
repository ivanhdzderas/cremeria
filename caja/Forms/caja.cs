using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using caja.Models;
using caja.Forms;
using System.Drawing.Printing;
using System.IO;
using Microsoft.VisualBasic;

namespace caja
{
    public partial class caja : Form
    {
        public static string id;
        public static int id_cliente;

        public static double tarjeta;
        public static double efectivo;
        public static double transferencia;
        public static Boolean factura;
        public static Boolean cancelado;
        public static string sucursal;
        public static string fecha = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

        public int Atendio=0;
        public caja()
        {
            InitializeComponent();
        }

        private void caja_Load(object sender, EventArgs e)
        {
            txtCodigo.AutoCompleteCustomSource = cargadatos();
            txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


            txtidcliente.AutoCompleteCustomSource = carga_clientes();
            txtidcliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtidcliente.AutoCompleteSource = AutoCompleteSource.CustomSource;


            txtIdAtiende.AutoCompleteCustomSource = carga_atiende();
            txtIdAtiende.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtIdAtiende.AutoCompleteSource = AutoCompleteSource.CustomSource;


            cancelado = false;
            Client cliente = new Client();
            List<Client> clien = cliente.getClientbyRFC("XAXX010101000");
            if (clien.Count > 0) {
                lbClient.Text = "Cliente: " + clien[0].Name + ", RFC: "+ clien[0].RFC;
                txtidcliente.Text = clien[0].Id.ToString();
            }

            txtCodigo.Focus();
            txtDescuento.Text = "0";
            txtTdescuento.Text = "0";
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(this.Font,  FontStyle.Bold);
            for (int i = 0; i < 7; i++) {
                dtProductos.Columns[i].HeaderCell.Style = style;
            }



            txtImporte.TextAlign = HorizontalAlignment.Right;
            txtCantidad.TextAlign = HorizontalAlignment.Right;
            txtDescuento.TextAlign = HorizontalAlignment.Right;

            txtSubtotal.TextAlign = HorizontalAlignment.Right;
            txtTdescuento.TextAlign = HorizontalAlignment.Right;
            txtIva.TextAlign = HorizontalAlignment.Right;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            txtcIva.TextAlign = HorizontalAlignment.Right;
            txtsIva.TextAlign = HorizontalAlignment.Right;
            cbPu.TextAlign = HorizontalAlignment.Right;

        }

        private AutoCompleteStringCollection cargadatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
                Product producto = new Product();
                List<Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
                foreach(Product item in result)
                {
                    datos.Add(item.Code1);
                }   
            return datos;
        }
        private AutoCompleteStringCollection carga_atiende()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            Users usuarios = new Users();
            List<Users> result = usuarios.getUsers();
            foreach (Users item in result)
            {
                datos.Add(item.Id.ToString());
            }
            return datos;
        }
        private AutoCompleteStringCollection carga_clientes()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            Client clientes = new Client();
            List<Client> result = clientes.getClients();
            foreach (Client item in result)
            {
                datos.Add(item.Id.ToString());
            }
            return datos;
        }
        private void calcula()
        {
            double totales = 0;
            double cuantos = 0;
            double importe = 0;
            double excento = 0;
            double once = 0;
            double diezyseis = 0;
            double cero = 0;
            double grabado = 0;
            double sin_grabar = 0;

            double descuento = Convert.ToDouble(txtTdescuento.Text);
            foreach (DataGridViewRow row in dtProductos.Rows)
            {
                cuantos = cuantos + Convert.ToDouble(row.Cells["Cantidad"].Value.ToString());
                totales = totales + Convert.ToDouble(row.Cells["importe"].Value.ToString());
                importe =  Convert.ToDouble(row.Cells["importe"].Value.ToString());
                switch (row.Cells["grabado"].Value.ToString())
                {
                    case "EXENTO IMPUESTOS":

                        break;
                    case "11":
                        once = once + ((importe - descuento) * 0.11);
                        break;
                    case "16":
                        diezyseis = diezyseis + ((importe - descuento) * 0.16);
                        break;
                    case "TASA CERO":

                        break;
                }


                if (row.Cells["grabado"].Value.ToString() == "16" || row.Cells["grabado"].Value.ToString() == "11")
                {
                    grabado = grabado + Convert.ToDouble(row.Cells["importe"].Value.ToString());
                }
                else
                {
                    sin_grabar = sin_grabar + Convert.ToDouble(row.Cells["importe"].Value.ToString());
                }

            }
            double productos = cuantos;
            double subtotal = totales;

            double iva = excento + once + diezyseis + cero;
            double total = subtotal+iva;


            txtNproductos.Text = productos.ToString();

            txtsIva.Text = string.Format("{0:#,0.00}", sin_grabar);
            txtcIva.Text = string.Format("{0:#,0.00}", grabado);
            txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);
            
            txtIva.Text = string.Format("{0:#,0.00}", iva);
           
            txtTotal.Text = string.Format("{0:#,0.00}", total);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                button1.PerformClick();
            }
            if (txtCodigo.Text != "")
            {

                string CODIGOABUSCAR;
                if (e.KeyCode == Keys.Enter)
                {
                   
                    string contenido = txtCodigo.Text;
                    if (contenido.Contains("*"))
                    {
                        string[] cantidades = contenido.Split('*');

                        CODIGOABUSCAR = cantidades[1];
                        txtCantidad.Text = cantidades[0];
                        Product producto = new Product();
                        List<Product> result = producto.getProductByCodeAbsolute(CODIGOABUSCAR);
                        if (result.Count > 0)
                        {
                            foreach (Product item in result)
                            {
                                id = item.Id.ToString();
                                txtCodigo.Text = item.Code1;
                                txtDescripcion.Text = item.Description;
                                if (item.Max_p1 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price1));
                                }
                                else if (item.Max_p2 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price2));
                                }
                                else if (item.Max_p3 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price3));
                                }
                                else if (item.Max_p4 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price4));
                                }
                                else if (item.Max_p5 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price5));
                                }

                            }
                            txtImporte.Text = (Convert.ToDouble(cbPu.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
                            txtDescuento.Text = "0";
                            txtCantidad.Focus();
                            btnVer.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        CODIGOABUSCAR = txtCodigo.Text;
                        Product producto = new Product();
                        List<Product> result = producto.getProductByCodeAbsolute(CODIGOABUSCAR);
                        txtCantidad.Text = "1";
                        if (result.Count > 0)
                        {
                            foreach (Product item in result)
                            {
                                id = item.Id.ToString();
                                txtCodigo.Text = item.Code1;
                                txtDescripcion.Text = item.Description;
                                if (item.Max_p1 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price1));
                                }
                                else if (item.Max_p2 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price2));
                                }
                                else if (item.Max_p3 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price3));
                                }
                                else if (item.Max_p4 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price4));
                                }
                                else if (item.Max_p5 >= Convert.ToDouble(txtCantidad.Text))
                                {
                                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price5));
                                }

                            }
                            txtImporte.Text = (Convert.ToDouble(cbPu.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
                            txtDescuento.Text = "0";
                            txtCantidad.Focus();
                            btnVer.Enabled = true;
                        }
                        
                    }

                    
                }
                
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                if (txtDescripcion.Text != "") {
                    cbPu.Focus();
                }
            }

           
        }

        

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" ) {
           
                txtImporte.Text = (Convert.ToDouble(cbPu.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
            }
            
        }

        private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcula();
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "")
            {
                double subtotal = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(cbPu.Text);
                double importe = (subtotal - Convert.ToDouble(txtDescuento.Text));
                txtImporte.Text = string.Format("{0:#,0.00}", importe);
                txtDescuento.Text = string.Format("{0:#,0.00}", Convert.ToDouble(txtDescuento.Text));
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Product producto = new Product();
                List<Product> prod = producto.getProductById(Convert.ToInt16(id)) ;
                string grabado = prod[0].Sale_tax;
                double costo = prod[0].Cost;
                grabado = grabado.Replace("IVA ", "");
                dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, string.Format("{0:#,0.00}", Convert.ToDouble(cbPu.Text)), string.Format("{0:#,0.00}", Convert.ToDouble(txtDescuento.Text)), string.Format("{0:#,0.00}", Convert.ToDouble(txtImporte.Text)), grabado, costo);
                txtCodigo.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";
                cbPu.Text = "0.00";
                txtImporte.Text = "";
                txtDescuento.Text = "";
                calcula();
                btnVer.Enabled = false;
                txtCodigo.Focus();
            }
        }

     

        private void txtTdescuento_TextChanged(object sender, EventArgs e)
        {
            txtTdescuento.Text = string.Format("{0:#,0.00}", Convert.ToDouble(txtTdescuento.Text));
            calcula();
        }
        private void limpiar() {
            cbPu.Text = "";
            dtProductos.Rows.Clear();
            txtCodigo.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            cbPu.Text = "0.00";
            txtImporte.Text = "";
            txtDescuento.Text = "";
            tarjeta = 0;
            efectivo = 0;

            calcula();
            txtCodigo.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscador();

            
        }
        private void buscador() {
            busca_producto busca = new busca_producto();
            busca.ShowDialog();
            Product producto = new Product();
            txtCantidad.Text = "1";
            List<Product> result = producto.getProductById(intercambios.Id_producto);
            foreach (Product item in result)
            {
                id = item.Id.ToString();
                txtCodigo.Text = item.Code1;
                txtDescripcion.Text = item.Description;

                if (item.Max_p1 >= Convert.ToDouble(txtCantidad.Text))
                {
                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price1));
                }
                else if (item.Max_p2 >= Convert.ToDouble(txtCantidad.Text))
                {
                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price2));
                }
                else if (item.Max_p3 >= Convert.ToDouble(txtCantidad.Text))
                {
                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price3));
                }
                else if (item.Max_p4 >= Convert.ToDouble(txtCantidad.Text))
                {
                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price4));
                }
                else if (item.Max_p5 >= Convert.ToDouble(txtCantidad.Text))
                {
                    cbPu.Text = (string.Format("{0:#,0.00}", item.Price5));
                }

               
            }
            txtImporte.Text = (Convert.ToDouble(cbPu.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
            txtDescuento.Text = "0";
 

           
            txtCantidad.Text = "1";
            txtCantidad.Focus();
            btnVer.Enabled = true;
        }
        private void caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                buscador();

            }
           
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCantidad.Text != "") {
                    txtDescripcion.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string folio=Interaction.InputBox("Ingrese el folio a reimprimir","Reimprimir");
            if (folio != "")
            {


                Dettickets detalles = new Dettickets();
                List<Dettickets> det = detalles.getDetalles(Convert.ToInt16(folio));

                Product prod = new Product();
                List<Product> lista = null;
                if (det.Count > 0)
                {
                    foreach (Dettickets item in det)
                    {
                        lista = prod.getProductById(item.Id_producto);
                        dtProductos.Rows.Add(item.Id_producto, lista[0].Code1, item.Cantidad, item.Descripcion, item.Pu, item.Descuento, item.Total, item.Grabado, item.Costo);
                        fecha = item.Fecha;

                    }
                    calcula();
                    id = folio;
                    PrinterSettings ps = new PrinterSettings();
                    Configuration configuracion = new Configuration();
                    List<Configuration> config = configuracion.getConfiguration();
                    printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.PrinterSettings = ps;
                    printDocument1.Print();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se encontro ticket");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIdAtiende.Text == "")
            {
                errorProvider1.SetError(txtIdAtiende, "Debe de ingresar quien atendio");
                txtIdAtiende.Focus();
            }
            else
            {
                cobro cb = new cobro();
                cancelado = false;

                cb.Owner = this;
                cb.lbResta.Text = txtTotal.Text;
                while (efectivo == 0 && tarjeta == 0)
                {
                    if (cancelado == true)
                    {
                        break;
                    }
                    cb.ShowDialog();
                }

                if (cancelado == false)
                {
                    guardar();
                }
            }
           
            
        }
        public void guardar() {
            Tickets ticket = new Tickets(
                0,
                Convert.ToInt16(txtidcliente.Text),
                fecha,
                Convert.ToDouble(txtSubtotal.Text),
                Convert.ToDouble(txtTdescuento.Text),
                Convert.ToDouble(txtIva.Text),
                Convert.ToDouble(txtTotal.Text),
                "A",
                Convert.ToDouble(txtcIva.Text),
                Convert.ToDouble(txtsIva.Text),
                Convert.ToInt16(inicial.id_usario),
                Convert.ToInt16(txtIdAtiende.Text)
                );
            ticket.CreateTicket();
            List<Tickets> lista = ticket.getLastTicket(fecha, Convert.ToDouble(txtSubtotal.Text), Convert.ToDouble(txtTdescuento.Text), Convert.ToDouble(txtIva.Text), Convert.ToDouble(txtTotal.Text), Convert.ToInt16(txtidcliente.Text));
            Product producto = new Product();
            Kardex kardex = new Kardex();
            Afecta_inv afecta = new Afecta_inv();
            double nuevo = 0;
            Dettickets detalle = new Dettickets();
            Pago_ticket pago = new Pago_ticket();
            pago.Id_ticket = lista[0].Id;
            id = lista[0].Id.ToString();
            if (tarjeta != 0) {
                pago.Monto = tarjeta;
                pago.Tipo_pago = "Tarjeta";
                pago.CreatePago();
            }
            if (efectivo !=0) {
                pago.Monto = efectivo;
                pago.Tipo_pago = "Efectivo";
                pago.CreatePago();
            }

            if (transferencia != 0)
            {
                pago.Monto = transferencia;
                pago.Tipo_pago = "Transferencia";
                pago.CreatePago();
            }
            detalle.Id_ticket = lista[0].Id;
            detalle.Id = 0;
            detalle.Fecha = fecha;
            foreach (DataGridViewRow row in dtProductos.Rows)
            {
                detalle.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
                detalle.Pu = Convert.ToDouble(row.Cells["p_unitario"].Value.ToString());
                detalle.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
                detalle.Descuento = Convert.ToDouble(row.Cells["descuento"].Value.ToString());
                detalle.Total = Convert.ToDouble(row.Cells["importe"].Value.ToString());
                detalle.Descripcion = row.Cells["Producto"].Value.ToString();
                detalle.Grabado = row.Cells["grabado"].Value.ToString();
                detalle.Costo = Convert.ToDouble(row.Cells["costo"].Value.ToString());
                detalle.CrateDetTicket();
                List<Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
                nuevo = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
                while (prod[0].Parent != "0")
                {
                    nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
                    prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));
                }
                kardex.Fecha = Convert.ToDateTime(fecha).ToString();
                kardex.Id_producto = prod[0].Id;
                kardex.Tipo = "V";
                kardex.Cantidad = nuevo;
                kardex.Antes = prod[0].Existencia;
                kardex.Id = 0;
                kardex.Id_documento = Convert.ToInt16(lista[0].Id);
                kardex.CreateKardex();
                List<Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(lista[0].Id), "V");
                afecta.Disminuye(numeracion[0].Id);
            }
            PrinterSettings ps = new PrinterSettings();
            Configuration configuracion = new Configuration();
            List<Configuration> config = configuracion.getConfiguration();
            printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
            printDocument1.PrintPage += Imprimir;
            printDocument1.PrinterSettings = ps;
            printDocument1.Print();
            limpiar();

            aviso_retiro();
        }
        private void aviso_retiro()
        {
            double retirado = 0;
            retiro_efectivo retiro = new retiro_efectivo();
            List<retiro_efectivo> retiros = retiro.get_retirostoday();
            if (retiros.Count > 0)
            {
                foreach(retiro_efectivo item in retiros)
                {
                    retirado = retirado + item.Monto;
                }
            }

            double vendido = 0;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            Tickets ticket = new Tickets();
            List<Tickets> lista = ticket.getTicketsToday(fecha);
            Pago_ticket pagos = new Pago_ticket();
            if (lista.Count > 0)
            {
                foreach(Tickets it in lista)
                {
                    List<Pago_ticket> pago = pagos.get_pago(it.Id); 
                    foreach(Pago_ticket pag in pago)
                    {
                        if (pag.Tipo_pago== "Efectivo")
                        {
                            vendido = vendido + pag.Monto;
                        }
                    }
                   
                }
            }

            double diferencia = vendido - retirado;
            if (diferencia >= 5000)
            {
                MessageBox.Show("Es necesario hacer el retiro de efectivo", "Retiro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Busca_cliente busca = new Busca_cliente();
            busca.ShowDialog();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {   
            producto.Codigo = id;
            producto Producto = new producto();
            Producto.Show(this);
        }
        private string formato(string numero) {
            double valor = 0;
            string resultado = "";
            valor = Convert.ToDouble(numero);
            resultado = valor.ToString("0.00");
            return resultado;
        }
    

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Configuration configuracion = new Configuration();
            List<Configuration> config = configuracion.getConfiguration();
            Font font = new Font("Verdana", 8, FontStyle.Regular);
            int y = 70;
            var format = new StringFormat() { Alignment = StringAlignment.Center };
            double cambio = 0;
            double descuento = Convert.ToDouble(txtTdescuento.Text);


            if (config[0].Logo_ticket != "") {
                if (File.Exists(config[0].Logo_ticket)) {
                    Image logo = Image.FromFile(config[0].Logo_ticket);
                    e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
                }
            }
            y = y + 10;
            e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
            y = y + 10;
            e.Graphics.DrawString(config[0].RFC, font, Brushes.Black, 125, y, format);
            y = y + 10;
            string calle = config[0].Calle + " " + config[0].No_ext;
            if (config[0].No_int != "") {
                calle += "-" + config[0].No_int;
            }
            e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
            y = y + 10;
            e.Graphics.DrawString(config[0].Municipio + " " +config[0].Estado, font, Brushes.Black, 125, y, format);
            y = y + 10;
            e.Graphics.DrawString("Telefono" + config[0].Telefono, font, Brushes.Black, 125, y, format);
            y = y + 10;
            e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
            format = new StringFormat() { Alignment = StringAlignment.Far };
            y = y + 10;
            e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
            Client cliente = new Client();
            List<Client> datos_cliente = cliente.getClientbyId(Convert.ToInt16(txtidcliente.Text));
            string nombre = "Cliente: [" + datos_cliente[0].Id + "] " + datos_cliente[0].Name;
            y = y + 20;
            e.Graphics.DrawString(nombre, font, Brushes.Black, 0, y);
            string rfc = "RFC: " + datos_cliente[0].RFC;
            y = y + 10;
            e.Graphics.DrawString(rfc, font, Brushes.Black, 0, y);
            y = y + 10;
            e.Graphics.DrawString(fecha, font, Brushes.Black, 0, y);
            y = y + 10;
            e.Graphics.DrawString("Folio: " + id, font, Brushes.Black, 0, y);
            /* y = y + 10;
            e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
            */
            y = y + 20;
            e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
            e.Graphics.DrawString("P/U.", font, Brushes.Black, 100, y, format);
            e.Graphics.DrawString("Desc.", font, Brushes.Black, 150, y, format);
            e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
            y = y + 10;
            e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
            foreach (DataGridViewRow row in dtProductos.Rows)
            {
                y = y + 20;
                e.Graphics.DrawString(row.Cells["Producto"].Value.ToString(), font, Brushes.Black, 10, y);


                e.Graphics.DrawString(row.Cells["cantidad"].Value.ToString(), font, Brushes.Black, 50, y+10, format);
                e.Graphics.DrawString(formato(row.Cells["p_unitario"].Value.ToString()), font, Brushes.Black, 100, y + 10, format);
                e.Graphics.DrawString(formato(row.Cells["descuento"].Value.ToString()), font, Brushes.Black, 150, y + 10, format);
                e.Graphics.DrawString(formato(row.Cells["importe"].Value.ToString()), font, Brushes.Black, 220, y + 10, format);

               
            }

            y = y + 20;
            e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);



            y = y + 10;
            e.Graphics.DrawString("VENTA C/IVA", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(txtcIva.Text, font, Brushes.Black, 220, y + 10, format);
            y = y + 10;
            e.Graphics.DrawString("VENTA S/IVA", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(txtsIva.Text, font, Brushes.Black, 220, y + 10, format);


            y = y + 10;
            e.Graphics.DrawString("Subtotal", font, Brushes.Black, 150, y + 10,format);
            e.Graphics.DrawString(txtSubtotal.Text, font, Brushes.Black, 220, y + 10, format);
            y = y + 10;
            e.Graphics.DrawString("Descuento", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(txtTdescuento.Text, font, Brushes.Black, 220, y + 10, format);
            y = y + 10;
            e.Graphics.DrawString("IVA", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(txtIva.Text, font, Brushes.Black, 220, y + 10,format);
            y = y + 10;
            e.Graphics.DrawString(txtNproductos.Text + " Articulos" , font, Brushes.Black, 10, y+10);
            e.Graphics.DrawString("Total", font, Brushes.Black, 150, y + 10,format);
            e.Graphics.DrawString(txtTotal.Text, font, Brushes.Black, 220, y + 10,format);
            y = y + 10;
            e.Graphics.DrawString("_____________________________", font, Brushes.Black, 140, y + 10);
            y = y + 15;
            e.Graphics.DrawString("Efectivo", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(efectivo.ToString(), font, Brushes.Black, 220, y + 10, format);
            y = y + 10;
            e.Graphics.DrawString("Tarjeta", font, Brushes.Black, 150, y + 10, format);
            e.Graphics.DrawString(tarjeta.ToString(), font, Brushes.Black, 220, y + 10, format);
            y = y + 10;
            e.Graphics.DrawString("Cambio", font, Brushes.Black, 150, y + 10, format);
            cambio = (tarjeta + efectivo) - Convert.ToDouble(txtTotal.Text);
            e.Graphics.DrawString(cambio.ToString(), font, Brushes.Black, 220, y + 10, format);
            y = y + 40;
            intercambios inter = new intercambios();
            e.Graphics.DrawString(inter.enletras(txtTotal.Text), font, Brushes.Black, 0, y);
            y = y + 20;
            e.Graphics.DrawString(config[0].Pie_ticket, font, Brushes.Black, 0, y);
            y = y + 30;
            e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
        }

        private void lbidcliente_TextChanged(object sender, EventArgs e)
        {
            Client cliente = new Client();
            List<Client> clien = cliente.getClientbyId(Convert.ToInt16(txtidcliente.Text));
            if (clien.Count > 0)
            {
                lbClient.Text = "Cliente: " + clien[0].Name + ", RFC: " + clien[0].RFC;
                txtidcliente.Text = clien[0].Id.ToString();
            }
            else {
                MessageBox.Show("No se encontro cliente");
                txtidcliente.Focus();
            }
        }

        private void btnVer_Click_1(object sender, EventArgs e)
        {
            producto.Codigo = id;
            producto Producto = new producto();
            Producto.Show(this);
        }

        private void txtCantidad_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCantidad.Text != "")
                {

                    txtImporte.Text = (Convert.ToDouble(cbPu.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();

                    Product producto = new Product();
                    List<Product> prod = producto.getProductById(Convert.ToInt16(id));
                    double costo = prod[0].Cost;
                    string grabado = prod[0].Sale_tax;
                    grabado = grabado.Replace("IVA ", "");
                    dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, string.Format("{0:#,0.00}", Convert.ToDouble(cbPu.Text)), string.Format("{0:#,0.00}", Convert.ToDouble(txtDescuento.Text)), string.Format("{0:#,0.00}", Convert.ToDouble(txtImporte.Text)), grabado, costo);
                    txtCodigo.Text = "";
                    txtCantidad.Text = "";
                    txtDescripcion.Text = "";
                    cbPu.Text = "0.00";
                    txtImporte.Text = "";
                    txtDescuento.Text = "";
                    calcula();
                    btnVer.Enabled = false;
                    txtCodigo.Focus();
                }
            }

           


        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtCantidad.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim() != "")
            {
                if (txtCantidad.Text.Trim() != "0")
                {
                    if (id is null) { }
                    else
                    {
                        Product productos = new Product();
                        List<Product> producto = productos.getProductById(Convert.ToInt16(id));
                        if (producto.Count > 0)
                        {
                            if (producto[0].Max_p1 >= Convert.ToDouble(txtCantidad.Text))
                            {
                                cbPu.Text = (string.Format("{0:#,0.00}", producto[0].Price1));
                            }
                            else if (producto[0].Max_p2 >= Convert.ToDouble(txtCantidad.Text))
                            {
                                cbPu.Text = (string.Format("{0:#,0.00}", producto[0].Price2));
                            }
                            else if (producto[0].Max_p3 >= Convert.ToDouble(txtCantidad.Text))
                            {
                                cbPu.Text = (string.Format("{0:#,0.00}", producto[0].Price3));
                            }
                            else if (producto[0].Max_p4 >= Convert.ToDouble(txtCantidad.Text))
                            {
                                cbPu.Text = (string.Format("{0:#,0.00}", producto[0].Price4));
                            }
                            else if (producto[0].Max_p5 >= Convert.ToDouble(txtCantidad.Text))
                            {
                                cbPu.Text = (string.Format("{0:#,0.00}", producto[0].Price5));
                            }
                        }
                        
                    }

                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            autentificar cb = new autentificar();
            cb.origen = "retiro";
            cancelado = false;

            cb.Owner = this;
           
            
            cb.ShowDialog();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            autentificar cb = new autentificar();
            cb.origen = "transferencia";
            cancelado = false;

            cb.Owner = this;


            cb.ShowDialog();
            if (cancelado == false)
            {
                transferencias();
            }
            
        }
        public void transferencias()
        {
            cancelado = false;
            Sucursal cb = new Sucursal();

            Product productos = new Product();
            foreach (DataGridViewRow row in dtProductos.Rows)
            {
                List<Product> produto = productos.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
                row.Cells["p_unitario"].Value = string.Format("{0:#,0.00}", produto[0].Cost);
                double sub = produto[0].Cost * Convert.ToDouble(row.Cells["Cantidad"].Value);
                row.Cells["importe"].Value = string.Format("{0:#,0.00}", sub);
            }

            Transfer_forms.id_transfer = 0;
            Transfer_forms Transfer = new Transfer_forms();

            Transfer.cbOficinas.SelectedValue = sucursal;
            foreach (DataGridViewRow row in dtProductos.Rows)
            {
                Transfer.dtProductos.Rows.Add(row.Cells["id_producto"].Value, row.Cells["Cantidad"].Value, row.Cells["Codigo"].Value, row.Cells["Producto"].Value, row.Cells["p_unitario"].Value, row.Cells["importe"].Value);
            }

            Transfer.calcula();
            Transfer.btnGuardar.PerformClick();
            PrinterSettings ps = new PrinterSettings();
            Configuration configuracion = new Configuration();
            List<Configuration> config = configuracion.getConfiguration();
            printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
            printDocument1.PrintPage += Imprimir;
            printDocument1.PrinterSettings = ps;
            printDocument1.Print();
            limpiar();
        }

        private void txtidcliente_KeyDown(object sender, KeyEventArgs e)
        {
            bool error = false;
            
            if (e.KeyCode == Keys.Enter)
            {
                Client clientes = new Client();
                List<Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtidcliente.Text));
                if (cliente.Count > 0)
                {
                    lbClient.Text = "Cliente: " + cliente[0].Name + ", RFC: " + cliente[0].RFC;
                    txtCodigo.Focus();
                }
                else
                {
                    error = true;
                }

                if (error == true)
                {
                    errorProvider1.SetError(txtidcliente, "No se encontro numero de cliente");
                    txtidcliente.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            
        }

        private void txtidcliente_Leave(object sender, EventArgs e)
        {
            bool error = false;
            Client clientes = new Client();
            List<Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtidcliente.Text));
            if (cliente.Count > 0)
            {
                lbClient.Text = "Cliente: " + cliente[0].Name + ", RFC: " + cliente[0].RFC;
                txtCodigo.Focus();
            }
            else
            {
                error = true;
            }


            if (error == true)
            {
                errorProvider1.SetError(txtidcliente, "No se encontro numero de cliente");
                txtidcliente.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtIdAtiende_KeyDown(object sender, KeyEventArgs e)
        {
            bool error = false;
            if (e.KeyCode == Keys.Enter)
            {
                Users usuarios = new Users();
                List<Users> usuario = usuarios.getUserbyid(Convert.ToInt16(txtIdAtiende.Text));
                
                if (usuario.Count > 0)
                {
                    lbAtiende.Text = usuario[0].Nombre;
                    txtCodigo.Focus();
                }
                else
                {
                    error = true;
                }

                if (error == true)
                {
                    errorProvider1.RightToLeft = false;
                    errorProvider1.SetError(txtIdAtiende, "No se encontro colaborador");
                    lbAtiende.Text = "";
                    txtidcliente.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            autentificar cb = new autentificar();
            cb.origen = "Cancelar";
            cancelado = false;

            cb.Owner = this;


            cb.ShowDialog();
            if (cancelado == false)
            {
                cancelar();
            }
        }
        private void cancelar()
        {
            string folio=Interaction.InputBox("Ingrese el folio a cancelar","Cancelar");
            if (folio != "")
            {
                Tickets tickets = new Tickets();
                List<Tickets> ticket = tickets.getTicketsbyId(Convert.ToInt16(folio));
                if (ticket.Count > 0)
                {
                    if (ticket[0].Status == "C")
                    {
                        MessageBox.Show("Ticket cancelado previamente");
                    }
                    else
                    {
                        tickets.Id = Convert.ToInt16(folio);
                        tickets.CancelTicket();

                        Dettickets detalle_ticket = new Dettickets();
                        List<Dettickets> Detalles = detalle_ticket.getDetalles(Convert.ToInt16(folio));
                        Product productos = new Product();
                        Kardex kardex = new Kardex();
                        Afecta_inv afecta = new Afecta_inv();
                        int nuevo = 0;
                        foreach (Dettickets dettickets in Detalles)
                        {

                            List<Product> prod = productos.getProductById(dettickets.Id_producto);
                            nuevo = Convert.ToInt16(dettickets.Cantidad);
                            while (prod[0].Parent != "0")
                            {
                                nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
                                prod = productos.getProductById(Convert.ToInt16(prod[0].Parent));
                            }


                            
                            kardex.Id_producto = prod[0].Id;
                            kardex.Tipo = "D";
                            kardex.Id_documento = Convert.ToInt16(folio);
                            kardex.Cantidad =nuevo;
                            kardex.Antes = prod[0].Existencia;
                            kardex.Fecha = fecha;
                            kardex.CreateKardex();
                            List<Kardex> ultimo = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "D");
                            afecta.Agrega(ultimo[0].Id);
                        }
                        MessageBox.Show("Ticket cancelado satisfactoriamente");
                    }
                   
                }
                else
                {
                    MessageBox.Show("No se encontro Ticket");
                }
            }
        }
    }
}
