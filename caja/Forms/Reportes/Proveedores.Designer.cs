namespace caja.Forms.Reportes
{
	partial class Proveedores
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
			this.btnExcel = new System.Windows.Forms.Button();
			this.btnPdf = new System.Windows.Forms.Button();
			this.dtReporte = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dtReporte)).BeginInit();
			this.SuspendLayout();
			// 
			// btnExcel
			// 
			this.btnExcel.Location = new System.Drawing.Point(12, 22);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(75, 23);
			this.btnExcel.TabIndex = 0;
			this.btnExcel.Text = "Excel";
			this.btnExcel.UseVisualStyleBackColor = true;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnPdf
			// 
			this.btnPdf.Location = new System.Drawing.Point(93, 22);
			this.btnPdf.Name = "btnPdf";
			this.btnPdf.Size = new System.Drawing.Size(75, 23);
			this.btnPdf.TabIndex = 1;
			this.btnPdf.Text = "PDF";
			this.btnPdf.UseVisualStyleBackColor = true;
			this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
			// 
			// dtReporte
			// 
			this.dtReporte.AllowUserToAddRows = false;
			this.dtReporte.AllowUserToDeleteRows = false;
			this.dtReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtReporte.Location = new System.Drawing.Point(12, 64);
			this.dtReporte.Name = "dtReporte";
			this.dtReporte.ReadOnly = true;
			this.dtReporte.Size = new System.Drawing.Size(653, 363);
			this.dtReporte.TabIndex = 2;
			// 
			// Proveedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 439);
			this.Controls.Add(this.dtReporte);
			this.Controls.Add(this.btnPdf);
			this.Controls.Add(this.btnExcel);
			this.Name = "Proveedores";
			this.Text = "Proveedores";
			this.Load += new System.EventHandler(this.Proveedores_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtReporte)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.Button btnPdf;
		private System.Windows.Forms.DataGridView dtReporte;
	}
}