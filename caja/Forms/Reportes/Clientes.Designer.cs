namespace caja.Forms.Reportes
{
	partial class Clientes
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
			this.dtReporte = new System.Windows.Forms.DataGridView();
			this.btnExcel = new System.Windows.Forms.Button();
			this.btnPdf = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtReporte)).BeginInit();
			this.SuspendLayout();
			// 
			// dtReporte
			// 
			this.dtReporte.AllowUserToAddRows = false;
			this.dtReporte.AllowUserToDeleteRows = false;
			this.dtReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtReporte.Location = new System.Drawing.Point(12, 41);
			this.dtReporte.Name = "dtReporte";
			this.dtReporte.ReadOnly = true;
			this.dtReporte.Size = new System.Drawing.Size(776, 397);
			this.dtReporte.TabIndex = 0;
			// 
			// btnExcel
			// 
			this.btnExcel.Location = new System.Drawing.Point(12, 12);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(75, 23);
			this.btnExcel.TabIndex = 1;
			this.btnExcel.Text = "Excel";
			this.btnExcel.UseVisualStyleBackColor = true;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnPdf
			// 
			this.btnPdf.Location = new System.Drawing.Point(93, 12);
			this.btnPdf.Name = "btnPdf";
			this.btnPdf.Size = new System.Drawing.Size(75, 23);
			this.btnPdf.TabIndex = 2;
			this.btnPdf.Text = "PDF";
			this.btnPdf.UseVisualStyleBackColor = true;
			this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
			// 
			// Clientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnPdf);
			this.Controls.Add(this.btnExcel);
			this.Controls.Add(this.dtReporte);
			this.Name = "Clientes";
			this.Text = "Clientes";
			this.Load += new System.EventHandler(this.Clientes_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtReporte)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtReporte;
		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.Button btnPdf;
	}
}