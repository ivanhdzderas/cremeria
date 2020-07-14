namespace caja.Forms
{
	partial class Tickets_a_facturar
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
			this.dtTickets = new System.Windows.Forms.DataGridView();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtDetallado = new System.Windows.Forms.DataGridView();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lbDatosCliente = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtTickets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDetallado)).BeginInit();
			this.SuspendLayout();
			// 
			// dtTickets
			// 
			this.dtTickets.AllowUserToAddRows = false;
			this.dtTickets.AllowUserToDeleteRows = false;
			this.dtTickets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.fecha,
            this.cliente,
            this.total});
			this.dtTickets.Location = new System.Drawing.Point(12, 12);
			this.dtTickets.Name = "dtTickets";
			this.dtTickets.ReadOnly = true;
			this.dtTickets.Size = new System.Drawing.Size(776, 150);
			this.dtTickets.TabIndex = 0;
			this.dtTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtTickets_CellContentClick);
			// 
			// folio
			// 
			this.folio.HeaderText = "Folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// cliente
			// 
			this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.cliente.HeaderText = "Cliente";
			this.cliente.Name = "cliente";
			this.cliente.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// dtDetallado
			// 
			this.dtDetallado.AllowUserToAddRows = false;
			this.dtDetallado.AllowUserToDeleteRows = false;
			this.dtDetallado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDetallado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.pu,
            this.ttotal});
			this.dtDetallado.Location = new System.Drawing.Point(12, 168);
			this.dtDetallado.Name = "dtDetallado";
			this.dtDetallado.ReadOnly = true;
			this.dtDetallado.Size = new System.Drawing.Size(624, 150);
			this.dtDetallado.TabIndex = 1;
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
			// ttotal
			// 
			this.ttotal.HeaderText = "Total";
			this.ttotal.Name = "ttotal";
			this.ttotal.ReadOnly = true;
			// 
			// lbDatosCliente
			// 
			this.lbDatosCliente.AutoSize = true;
			this.lbDatosCliente.Location = new System.Drawing.Point(642, 168);
			this.lbDatosCliente.Name = "lbDatosCliente";
			this.lbDatosCliente.Size = new System.Drawing.Size(35, 13);
			this.lbDatosCliente.TabIndex = 2;
			this.lbDatosCliente.Text = "label1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(645, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Aplicar Pago";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Tickets_a_facturar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbDatosCliente);
			this.Controls.Add(this.dtDetallado);
			this.Controls.Add(this.dtTickets);
			this.Name = "Tickets_a_facturar";
			this.Text = "Tickets a pagar";
			this.Load += new System.EventHandler(this.Tickets_a_facturar_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtTickets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDetallado)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtTickets;
		private System.Windows.Forms.DataGridView dtDetallado;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.Label lbDatosCliente;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn pu;
		private System.Windows.Forms.DataGridViewTextBoxColumn ttotal;
	}
}