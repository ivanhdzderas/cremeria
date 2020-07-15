namespace caja.Forms
{
	partial class clientes_detallado
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
			this.txtIdcliente = new System.Windows.Forms.TextBox();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
			this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dtDetallado = new System.Windows.Forms.DataGridView();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lbTotal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtDetallado)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cliente";
			// 
			// txtIdcliente
			// 
			this.txtIdcliente.Location = new System.Drawing.Point(91, 12);
			this.txtIdcliente.Name = "txtIdcliente";
			this.txtIdcliente.Size = new System.Drawing.Size(66, 20);
			this.txtIdcliente.TabIndex = 1;
			this.txtIdcliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdcliente_KeyDown);
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(163, 12);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(257, 20);
			this.txtCliente.TabIndex = 2;
			this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Fecha inicio";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Fecha Fin";
			// 
			// dtFechaInicio
			// 
			this.dtFechaInicio.Location = new System.Drawing.Point(91, 38);
			this.dtFechaInicio.Name = "dtFechaInicio";
			this.dtFechaInicio.Size = new System.Drawing.Size(104, 20);
			this.dtFechaInicio.TabIndex = 5;
			// 
			// dtFechaFinal
			// 
			this.dtFechaFinal.Location = new System.Drawing.Point(91, 64);
			this.dtFechaFinal.Name = "dtFechaFinal";
			this.dtFechaFinal.Size = new System.Drawing.Size(104, 20);
			this.dtFechaFinal.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 102);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Consultar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(120, 102);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Limpiar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dtDetallado
			// 
			this.dtDetallado.AllowUserToAddRows = false;
			this.dtDetallado.AllowUserToDeleteRows = false;
			this.dtDetallado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtDetallado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDetallado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.fecha,
            this.cantidad,
            this.producto,
            this.total});
			this.dtDetallado.Location = new System.Drawing.Point(12, 141);
			this.dtDetallado.Name = "dtDetallado";
			this.dtDetallado.ReadOnly = true;
			this.dtDetallado.Size = new System.Drawing.Size(776, 162);
			this.dtDetallado.TabIndex = 9;
			// 
			// folio
			// 
			this.folio.HeaderText = "Folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.HeaderText = "fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// cantidad
			// 
			this.cantidad.HeaderText = "Cantidad";
			this.cantidad.Name = "cantidad";
			this.cantidad.ReadOnly = true;
			// 
			// producto
			// 
			this.producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.producto.HeaderText = "Producto";
			this.producto.Name = "producto";
			this.producto.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// lbTotal
			// 
			this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbTotal.AutoSize = true;
			this.lbTotal.Location = new System.Drawing.Point(687, 125);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(31, 13);
			this.lbTotal.TabIndex = 10;
			this.lbTotal.Text = "Total";
			// 
			// clientes_detallado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 315);
			this.Controls.Add(this.lbTotal);
			this.Controls.Add(this.dtDetallado);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtFechaFinal);
			this.Controls.Add(this.dtFechaInicio);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.txtIdcliente);
			this.Controls.Add(this.label1);
			this.Name = "clientes_detallado";
			this.Text = "clientes_detallado";
			this.Load += new System.EventHandler(this.clientes_detallado_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDetallado)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtIdcliente;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtFechaInicio;
		private System.Windows.Forms.DateTimePicker dtFechaFinal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dtDetallado;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.Label lbTotal;
	}
}