namespace caja
{
    partial class inicial
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inicial));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.cajaMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.catalogoMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gruposYSubgruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.traspasosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comprasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.corteCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.Bienvenido = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.Menu = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.btnCorteTurno = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Home = new System.Windows.Forms.TabControl();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.Menu.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaMenu,
            this.facturasToolStripMenuItem,
            this.catalogoMenu,
            this.movimientosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.configuracionToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(632, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// cajaMenu
			// 
			this.cajaMenu.Enabled = false;
			this.cajaMenu.Name = "cajaMenu";
			this.cajaMenu.Size = new System.Drawing.Size(42, 20);
			this.cajaMenu.Text = "&Caja";
			this.cajaMenu.Click += new System.EventHandler(this.cajaMenu_Click);
			// 
			// catalogoMenu
			// 
			this.catalogoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.gruposYSubgruposToolStripMenuItem,
            this.sucursalesToolStripMenuItem});
			this.catalogoMenu.Enabled = false;
			this.catalogoMenu.Name = "catalogoMenu";
			this.catalogoMenu.Size = new System.Drawing.Size(67, 20);
			this.catalogoMenu.Text = "C&atalogo";
			// 
			// inventarioToolStripMenuItem
			// 
			this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
			this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.inventarioToolStripMenuItem.Text = "&Inventario";
			this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
			// 
			// clientesToolStripMenuItem
			// 
			this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
			this.clientesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.clientesToolStripMenuItem.Text = "C&lientes";
			this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
			// 
			// proveedoresToolStripMenuItem
			// 
			this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
			this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.proveedoresToolStripMenuItem.Text = "&Proveedores";
			this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
			// 
			// usuariosToolStripMenuItem
			// 
			this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
			this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.usuariosToolStripMenuItem.Text = "Usuarios";
			this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
			// 
			// gruposYSubgruposToolStripMenuItem
			// 
			this.gruposYSubgruposToolStripMenuItem.Name = "gruposYSubgruposToolStripMenuItem";
			this.gruposYSubgruposToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.gruposYSubgruposToolStripMenuItem.Text = "Grupos y Subgrupos";
			this.gruposYSubgruposToolStripMenuItem.Click += new System.EventHandler(this.gruposYSubgruposToolStripMenuItem_Click);
			// 
			// sucursalesToolStripMenuItem
			// 
			this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
			this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.sucursalesToolStripMenuItem.Text = "Sucursales";
			this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
			// 
			// movimientosToolStripMenuItem
			// 
			this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem1,
            this.comprasToolStripMenuItem});
			this.movimientosToolStripMenuItem.Enabled = false;
			this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
			this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.movimientosToolStripMenuItem.Text = "&Movimientos";
			// 
			// inventarioToolStripMenuItem1
			// 
			this.inventarioToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.ajustesToolStripMenuItem,
            this.traspasosToolStripMenuItem});
			this.inventarioToolStripMenuItem1.Name = "inventarioToolStripMenuItem1";
			this.inventarioToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.inventarioToolStripMenuItem1.Text = "i&nventario";
			// 
			// entradasToolStripMenuItem
			// 
			this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
			this.entradasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.entradasToolStripMenuItem.Text = "En&tradas";
			this.entradasToolStripMenuItem.Click += new System.EventHandler(this.entradasToolStripMenuItem_Click);
			// 
			// salidasToolStripMenuItem
			// 
			this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
			this.salidasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.salidasToolStripMenuItem.Text = "Salidas";
			this.salidasToolStripMenuItem.Click += new System.EventHandler(this.salidasToolStripMenuItem_Click);
			// 
			// ajustesToolStripMenuItem
			// 
			this.ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
			this.ajustesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.ajustesToolStripMenuItem.Text = "Ajustes";
			this.ajustesToolStripMenuItem.Click += new System.EventHandler(this.ajustesToolStripMenuItem_Click);
			// 
			// traspasosToolStripMenuItem
			// 
			this.traspasosToolStripMenuItem.Name = "traspasosToolStripMenuItem";
			this.traspasosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.traspasosToolStripMenuItem.Text = "Traspasos";
			this.traspasosToolStripMenuItem.Click += new System.EventHandler(this.traspasosToolStripMenuItem_Click);
			// 
			// comprasToolStripMenuItem
			// 
			this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem1,
            this.pagosToolStripMenuItem});
			this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
			this.comprasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.comprasToolStripMenuItem.Text = "Proveedores";
			// 
			// comprasToolStripMenuItem1
			// 
			this.comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
			this.comprasToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.comprasToolStripMenuItem1.Text = "Compras";
			this.comprasToolStripMenuItem1.Click += new System.EventHandler(this.comprasToolStripMenuItem1_Click);
			// 
			// pagosToolStripMenuItem
			// 
			this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
			this.pagosToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.pagosToolStripMenuItem.Text = "Pagos";
			this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem2,
            this.inventarioToolStripMenuItem3,
            this.clientesToolStripMenuItem1,
            this.corteCajaToolStripMenuItem});
			this.reportesToolStripMenuItem.Enabled = false;
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.reportesToolStripMenuItem.Text = "Reportes";
			// 
			// inventarioToolStripMenuItem2
			// 
			this.inventarioToolStripMenuItem2.Name = "inventarioToolStripMenuItem2";
			this.inventarioToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
			this.inventarioToolStripMenuItem2.Text = "Inventario";
			this.inventarioToolStripMenuItem2.Click += new System.EventHandler(this.inventarioToolStripMenuItem2_Click);
			// 
			// inventarioToolStripMenuItem3
			// 
			this.inventarioToolStripMenuItem3.Name = "inventarioToolStripMenuItem3";
			this.inventarioToolStripMenuItem3.Size = new System.Drawing.Size(139, 22);
			this.inventarioToolStripMenuItem3.Text = "Proveedores";
			this.inventarioToolStripMenuItem3.Click += new System.EventHandler(this.inventarioToolStripMenuItem3_Click);
			// 
			// clientesToolStripMenuItem1
			// 
			this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
			this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
			this.clientesToolStripMenuItem1.Text = "Clientes";
			this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
			// 
			// corteCajaToolStripMenuItem
			// 
			this.corteCajaToolStripMenuItem.Name = "corteCajaToolStripMenuItem";
			this.corteCajaToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.corteCajaToolStripMenuItem.Text = "Corte Caja";
			this.corteCajaToolStripMenuItem.Click += new System.EventHandler(this.corteCajaToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Enabled = false;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem1.Text = "?";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// configuracionToolStripMenuItem
			// 
			this.configuracionToolStripMenuItem.Enabled = false;
			this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
			this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.configuracionToolStripMenuItem.Text = "Configuracion";
			this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
			// 
			// facturasToolStripMenuItem
			// 
			this.facturasToolStripMenuItem.Enabled = false;
			this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
			this.facturasToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.facturasToolStripMenuItem.Text = "Facturas";
			this.facturasToolStripMenuItem.Click += new System.EventHandler(this.facturasToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.saveAsToolStripMenuItem.Text = "Guardar &como";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(203, 6);
			// 
			// printSetupToolStripMenuItem
			// 
			this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
			this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.printSetupToolStripMenuItem.Text = "Configurar impresión";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(203, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.exitToolStripMenuItem.Text = "&Salir";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bienvenido});
			this.statusStrip.Location = new System.Drawing.Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(632, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// Bienvenido
			// 
			this.Bienvenido.Name = "Bienvenido";
			this.Bienvenido.Size = new System.Drawing.Size(42, 17);
			this.Bienvenido.Text = "Estado";
			// 
			// mySqlCommand1
			// 
			this.mySqlCommand1.CacheAge = 0;
			this.mySqlCommand1.Connection = null;
			this.mySqlCommand1.EnableCaching = false;
			this.mySqlCommand1.Transaction = null;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "cart.png");
			this.imageList1.Images.SetKeyName(1, "application_form.png");
			this.imageList1.Images.SetKeyName(2, "box.png");
			this.imageList1.Images.SetKeyName(3, "group.png");
			this.imageList1.Images.SetKeyName(4, "report.png");
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton4,
            this.btnCorteTurno,
            this.toolStripButton6});
			this.Menu.Location = new System.Drawing.Point(0, 24);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(632, 25);
			this.Menu.TabIndex = 4;
			this.Menu.Text = "toolStrip1";
			this.Menu.Visible = false;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::caja.Properties.Resources.cart;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
			this.toolStripButton1.Text = "Ventas";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = global::caja.Properties.Resources.group;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(69, 22);
			this.toolStripButton2.Text = "Clientes";
			this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = global::caja.Properties.Resources.application_form;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(80, 22);
			this.toolStripButton3.Text = "Inventario";
			this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Image = global::caja.Properties.Resources.box;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(75, 22);
			this.toolStripButton5.Text = "Compras";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = global::caja.Properties.Resources.report;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(68, 22);
			this.toolStripButton4.Text = "Reporte";
			// 
			// btnCorteTurno
			// 
			this.btnCorteTurno.Image = global::caja.Properties.Resources.money_dollar;
			this.btnCorteTurno.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCorteTurno.Name = "btnCorteTurno";
			this.btnCorteTurno.Size = new System.Drawing.Size(99, 22);
			this.btnCorteTurno.Text = "Corte De Caja";
			this.btnCorteTurno.Click += new System.EventHandler(this.btnCorteTurno_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.Image = global::caja.Properties.Resources.door_in;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(49, 22);
			this.toolStripButton6.Text = "Salir";
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Home);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.panel1.Size = new System.Drawing.Size(632, 407);
			this.panel1.TabIndex = 5;
			this.panel1.Visible = false;
			// 
			// Home
			// 
			this.Home.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Home.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.Home.Location = new System.Drawing.Point(0, 0);
			this.Home.Name = "Home";
			this.Home.SelectedIndex = 0;
			this.Home.Size = new System.Drawing.Size(632, 407);
			this.Home.TabIndex = 0;
			this.Home.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Home_DrawItem);
			this.Home.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Enabled = false;
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.newToolStripMenuItem.Text = "&Nuevo";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.openToolStripMenuItem.Text = "&Abrir";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.saveToolStripMenuItem.Text = "&Guardar";
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.printToolStripMenuItem.Text = "&Imprimir";
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.printPreviewToolStripMenuItem.Text = "&Vista previa de impresión";
			// 
			// inicial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Menu);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "inicial";
			this.Text = "Caja";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.inicial_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel Bienvenido;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.ToolStripMenuItem cajaMenu;
        public System.Windows.Forms.ToolStripMenuItem catalogoMenu;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
		private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
		private System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.ToolStrip Menu;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		public System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.TabControl Home;
		private System.Windows.Forms.ToolStripMenuItem gruposYSubgruposToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		public System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
		public System.Windows.Forms.ToolStripButton toolStripButton1;
		public System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton btnCorteTurno;
		private System.Windows.Forms.ToolStripMenuItem corteCajaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem traspasosToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
	}
}



