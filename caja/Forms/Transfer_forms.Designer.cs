namespace caja.Forms
{
	partial class Transfer_forms
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
			this.cbOficinas = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFolios = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.nuCantidad = new System.Windows.Forms.NumericUpDown();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lbFecha = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nuCantidad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Sucursal";
			// 
			// cbOficinas
			// 
			this.cbOficinas.FormattingEnabled = true;
			this.cbOficinas.Location = new System.Drawing.Point(66, 6);
			this.cbOficinas.Name = "cbOficinas";
			this.cbOficinas.Size = new System.Drawing.Size(197, 21);
			this.cbOficinas.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(269, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Folio";
			// 
			// txtFolios
			// 
			this.txtFolios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFolios.Location = new System.Drawing.Point(300, 10);
			this.txtFolios.Name = "txtFolios";
			this.txtFolios.Size = new System.Drawing.Size(81, 20);
			this.txtFolios.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Cantidad";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(150, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Codigo";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(417, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Descripcion";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(623, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Precio";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(90, 55);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 8;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(196, 55);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(424, 20);
			this.txtDescripcion.TabIndex = 9;
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(626, 54);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 10;
			this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
			// 
			// nuCantidad
			// 
			this.nuCantidad.Location = new System.Drawing.Point(15, 55);
			this.nuCantidad.Name = "nuCantidad";
			this.nuCantidad.Size = new System.Drawing.Size(69, 20);
			this.nuCantidad.TabIndex = 11;
			this.nuCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nuCantidad_KeyDown);
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
            this.p_u,
            this.Importe});
			this.dtProductos.Location = new System.Drawing.Point(12, 81);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(714, 224);
			this.dtProductos.TabIndex = 12;
			this.dtProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProductos_RowsRemoved);
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
			// p_u
			// 
			this.p_u.HeaderText = "Costo U";
			this.p_u.Name = "p_u";
			this.p_u.ReadOnly = true;
			// 
			// Importe
			// 
			this.Importe.HeaderText = "Importe";
			this.Importe.Name = "Importe";
			this.Importe.ReadOnly = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(574, 314);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Subtotal";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(596, 340);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "IVA";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(589, 366);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Total";
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(626, 311);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 13);
			this.txtSubtotal.TabIndex = 16;
			// 
			// txtIva
			// 
			this.txtIva.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtIva.Enabled = false;
			this.txtIva.Location = new System.Drawing.Point(626, 337);
			this.txtIva.Name = "txtIva";
			this.txtIva.Size = new System.Drawing.Size(100, 13);
			this.txtIva.TabIndex = 17;
			// 
			// txtTotal
			// 
			this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTotal.Enabled = false;
			this.txtTotal.Location = new System.Drawing.Point(626, 363);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(100, 13);
			this.txtTotal.TabIndex = 18;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(12, 311);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 23);
			this.btnGuardar.TabIndex = 19;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(93, 311);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 20;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lbFecha
			// 
			this.lbFecha.AutoSize = true;
			this.lbFecha.Location = new System.Drawing.Point(387, 12);
			this.lbFecha.Name = "lbFecha";
			this.lbFecha.Size = new System.Drawing.Size(41, 13);
			this.lbFecha.TabIndex = 22;
			this.lbFecha.Text = "label10";
			// 
			// Transfer_forms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 398);
			this.Controls.Add(this.lbFecha);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.txtIva);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.nuCantidad);
			this.Controls.Add(this.txtPrecio);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFolios);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbOficinas);
			this.Controls.Add(this.label1);
			this.Name = "Transfer_forms";
			this.Text = "Traspasos";
			this.Load += new System.EventHandler(this.Transfer_forms_Load);
			((System.ComponentModel.ISupportInitialize)(this.nuCantidad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbOficinas;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFolios;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.NumericUpDown nuCantidad;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn p_u;
		private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSubtotal;
		private System.Windows.Forms.TextBox txtIva;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lbFecha;
	}
}