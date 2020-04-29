namespace caja.Forms
{
	partial class Pagos_proveedores
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.fecha,
            this.proveedor,
            this.subtotal,
            this.iva,
            this.Total});
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(776, 301);
			this.dataGridView1.TabIndex = 0;
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
			// proveedor
			// 
			this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.proveedor.HeaderText = "Proveedor";
			this.proveedor.Name = "proveedor";
			this.proveedor.ReadOnly = true;
			// 
			// subtotal
			// 
			this.subtotal.HeaderText = "Subtotal";
			this.subtotal.Name = "subtotal";
			this.subtotal.ReadOnly = true;
			// 
			// iva
			// 
			this.iva.HeaderText = "IVA";
			this.iva.Name = "iva";
			this.iva.ReadOnly = true;
			// 
			// Total
			// 
			this.Total.HeaderText = "Total";
			this.Total.Name = "Total";
			this.Total.ReadOnly = true;
			// 
			// Pagos_proveedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Pagos_proveedores";
			this.Text = "Pago Proveedores";
			this.Load += new System.EventHandler(this.Pagos_proveedores_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
		private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn iva;
		private System.Windows.Forms.DataGridViewTextBoxColumn Total;
	}
}