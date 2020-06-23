namespace caja.Forms
{
	partial class Form_factura
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.txtIdCliente = new System.Windows.Forms.TextBox();
			this.dtdocumentos = new System.Windows.Forms.DataGridView();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtdocumentos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Factura";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(237, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Fecha";
			// 
			// cbTipo
			// 
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(74, 6);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(121, 21);
			this.cbTipo.TabIndex = 2;
			this.cbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipo_KeyPress);
			// 
			// dtFecha
			// 
			this.dtFecha.Location = new System.Drawing.Point(280, 6);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(200, 20);
			this.dtFecha.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(525, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Folio";
			// 
			// txtFolio
			// 
			this.txtFolio.Enabled = false;
			this.txtFolio.Location = new System.Drawing.Point(560, 7);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(43, 20);
			this.txtFolio.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Cliente";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "No. Cliente";
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(74, 33);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(406, 20);
			this.txtCliente.TabIndex = 8;
			// 
			// txtIdCliente
			// 
			this.txtIdCliente.Location = new System.Drawing.Point(74, 59);
			this.txtIdCliente.Name = "txtIdCliente";
			this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
			this.txtIdCliente.TabIndex = 9;
			// 
			// dtdocumentos
			// 
			this.dtdocumentos.AllowUserToAddRows = false;
			this.dtdocumentos.AllowUserToDeleteRows = false;
			this.dtdocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtdocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.tipo});
			this.dtdocumentos.Location = new System.Drawing.Point(12, 264);
			this.dtdocumentos.Name = "dtdocumentos";
			this.dtdocumentos.ReadOnly = true;
			this.dtdocumentos.Size = new System.Drawing.Size(249, 150);
			this.dtdocumentos.TabIndex = 10;
			this.dtdocumentos.Visible = false;
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.pu,
            this.total});
			this.dtProductos.Location = new System.Drawing.Point(12, 108);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(776, 150);
			this.dtProductos.TabIndex = 11;
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// cantidad
			// 
			this.cantidad.HeaderText = "Cantidad";
			this.cantidad.Name = "cantidad";
			this.cantidad.ReadOnly = true;
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo";
			this.codigo.Name = "codigo";
			this.codigo.ReadOnly = true;
			// 
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			this.descripcion.ReadOnly = true;
			// 
			// pu
			// 
			this.pu.HeaderText = "P/U";
			this.pu.Name = "pu";
			this.pu.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// folio
			// 
			this.folio.HeaderText = "folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// tipo
			// 
			this.tipo.HeaderText = "tipo";
			this.tipo.Name = "tipo";
			this.tipo.ReadOnly = true;
			// 
			// Form_factura
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.dtdocumentos);
			this.Controls.Add(this.txtIdCliente);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.cbTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form_factura";
			this.Text = "Facturas";
			this.Load += new System.EventHandler(this.Form_factura_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtdocumentos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox txtCliente;
		public System.Windows.Forms.TextBox txtIdCliente;
		public System.Windows.Forms.DataGridView dtdocumentos;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn pu;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
	}
}