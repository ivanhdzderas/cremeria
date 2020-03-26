namespace caja.Forms
{
	partial class Compras
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
			this.dtCompras = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDocumentos = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProveedor = new System.Windows.Forms.TextBox();
			this.btnNuevo = new System.Windows.Forms.Button();
			this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtCompras)).BeginInit();
			this.SuspendLayout();
			// 
			// dtCompras
			// 
			this.dtCompras.AllowUserToAddRows = false;
			this.dtCompras.AllowUserToDeleteRows = false;
			this.dtCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.documento,
            this.proveedor,
            this.fecha,
            this.total});
			this.dtCompras.Location = new System.Drawing.Point(12, 64);
			this.dtCompras.Name = "dtCompras";
			this.dtCompras.ReadOnly = true;
			this.dtCompras.Size = new System.Drawing.Size(776, 161);
			this.dtCompras.TabIndex = 0;
			this.dtCompras.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCompras_CellContentDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Documentos";
			// 
			// txtDocumentos
			// 
			this.txtDocumentos.Location = new System.Drawing.Point(91, 12);
			this.txtDocumentos.Name = "txtDocumentos";
			this.txtDocumentos.Size = new System.Drawing.Size(100, 20);
			this.txtDocumentos.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Proveedor";
			// 
			// txtProveedor
			// 
			this.txtProveedor.Location = new System.Drawing.Point(91, 38);
			this.txtProveedor.Name = "txtProveedor";
			this.txtProveedor.Size = new System.Drawing.Size(341, 20);
			this.txtProveedor.TabIndex = 4;
			// 
			// btnNuevo
			// 
			this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNuevo.Location = new System.Drawing.Point(713, 231);
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(75, 23);
			this.btnNuevo.TabIndex = 5;
			this.btnNuevo.Text = "Nuevo";
			this.btnNuevo.UseVisualStyleBackColor = true;
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			// 
			// documento
			// 
			this.documento.HeaderText = "Documento";
			this.documento.Name = "documento";
			this.documento.ReadOnly = true;
			// 
			// proveedor
			// 
			this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.proveedor.HeaderText = "Proveedor";
			this.proveedor.Name = "proveedor";
			this.proveedor.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// Compras
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 266);
			this.Controls.Add(this.btnNuevo);
			this.Controls.Add(this.txtProveedor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDocumentos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtCompras);
			this.Name = "Compras";
			this.Text = "Compras";
			this.Load += new System.EventHandler(this.Compras_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtCompras)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtCompras;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDocumentos;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtProveedor;
		private System.Windows.Forms.Button btnNuevo;
		private System.Windows.Forms.DataGridViewTextBoxColumn documento;
		private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
	}
}