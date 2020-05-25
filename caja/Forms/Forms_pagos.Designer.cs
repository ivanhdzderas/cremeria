namespace caja.Forms
{
	partial class Forms_pagos
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtidproveedor = new System.Windows.Forms.TextBox();
			this.txtproveedor = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbFolio = new System.Windows.Forms.Label();
			this.cbFacturas = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.dtfecha = new System.Windows.Forms.DateTimePicker();
			this.dtpagos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.lbTotal = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtpagos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 79);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Forma de pago";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(55, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Proveedor";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(117, 76);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(59, 20);
			this.txtCodigo.TabIndex = 2;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(182, 76);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(215, 20);
			this.txtDescripcion.TabIndex = 3;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// txtidproveedor
			// 
			this.txtidproveedor.Location = new System.Drawing.Point(117, 102);
			this.txtidproveedor.Name = "txtidproveedor";
			this.txtidproveedor.Size = new System.Drawing.Size(59, 20);
			this.txtidproveedor.TabIndex = 4;
			this.txtidproveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtidproveedor_KeyDown);
			// 
			// txtproveedor
			// 
			this.txtproveedor.Location = new System.Drawing.Point(182, 102);
			this.txtproveedor.Name = "txtproveedor";
			this.txtproveedor.Size = new System.Drawing.Size(215, 20);
			this.txtproveedor.TabIndex = 5;
			this.txtproveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtproveedor_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(63, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Facturas";
			// 
			// lbFolio
			// 
			this.lbFolio.AutoSize = true;
			this.lbFolio.Location = new System.Drawing.Point(114, 8);
			this.lbFolio.Name = "lbFolio";
			this.lbFolio.Size = new System.Drawing.Size(35, 13);
			this.lbFolio.TabIndex = 7;
			this.lbFolio.Text = "label4";
			// 
			// cbFacturas
			// 
			this.cbFacturas.Enabled = false;
			this.cbFacturas.FormattingEnabled = true;
			this.cbFacturas.Location = new System.Drawing.Point(117, 128);
			this.cbFacturas.Name = "cbFacturas";
			this.cbFacturas.Size = new System.Drawing.Size(199, 21);
			this.cbFacturas.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(109, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 13);
			this.label4.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(38, 27);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Folio del pago";
			// 
			// txtFolio
			// 
			this.txtFolio.Location = new System.Drawing.Point(117, 24);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(100, 20);
			this.txtFolio.TabIndex = 12;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(322, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(46, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Fecha Pago";
			// 
			// dtfecha
			// 
			this.dtfecha.Location = new System.Drawing.Point(117, 50);
			this.dtfecha.Name = "dtfecha";
			this.dtfecha.Size = new System.Drawing.Size(199, 20);
			this.dtfecha.TabIndex = 15;
			// 
			// dtpagos
			// 
			this.dtpagos.AllowUserToAddRows = false;
			this.dtpagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtpagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.documento,
            this.fecha,
            this.monto});
			this.dtpagos.Location = new System.Drawing.Point(12, 163);
			this.dtpagos.Name = "dtpagos";
			this.dtpagos.ReadOnly = true;
			this.dtpagos.Size = new System.Drawing.Size(385, 150);
			this.dtpagos.TabIndex = 16;
			this.dtpagos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtpagos_RowsRemoved);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// documento
			// 
			this.documento.HeaderText = "Documento";
			this.documento.Name = "documento";
			this.documento.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// monto
			// 
			this.monto.HeaderText = "Monto";
			this.monto.Name = "monto";
			this.monto.ReadOnly = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(327, 350);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "Guardar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(246, 350);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 18;
			this.button3.Text = "Cancelar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// lbTotal
			// 
			this.lbTotal.AutoSize = true;
			this.lbTotal.Location = new System.Drawing.Point(302, 316);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(35, 13);
			this.lbTotal.TabIndex = 19;
			this.lbTotal.Text = "label7";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(82, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Folio";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(283, 316);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "$";
			// 
			// Forms_pagos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 382);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lbTotal);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dtpagos);
			this.Controls.Add(this.dtfecha);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbFacturas);
			this.Controls.Add(this.lbFolio);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtproveedor);
			this.Controls.Add(this.txtidproveedor);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Forms_pagos";
			this.Text = "Pagos";
			this.Load += new System.EventHandler(this.Forms_pagos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtpagos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtidproveedor;
		private System.Windows.Forms.TextBox txtproveedor;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbFolio;
		private System.Windows.Forms.ComboBox cbFacturas;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtfecha;
		private System.Windows.Forms.DataGridView dtpagos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn documento;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn monto;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label lbTotal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}