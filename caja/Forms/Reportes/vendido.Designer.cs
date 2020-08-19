namespace caja.Forms.Reportes
{
	partial class vendido
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
			this.button1 = new System.Windows.Forms.Button();
			this.Ffinal = new System.Windows.Forms.DateTimePicker();
			this.Finicial = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(603, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Mostrar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Ffinal
			// 
			this.Ffinal.Location = new System.Drawing.Point(397, 11);
			this.Ffinal.Name = "Ffinal";
			this.Ffinal.Size = new System.Drawing.Size(200, 20);
			this.Ffinal.TabIndex = 10;
			// 
			// Finicial
			// 
			this.Finicial.Location = new System.Drawing.Point(100, 12);
			this.Finicial.Name = "Finicial";
			this.Finicial.Size = new System.Drawing.Size(200, 20);
			this.Finicial.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(329, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Fecha Final";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Fecha Inicial";
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.Location = new System.Drawing.Point(12, 47);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(776, 391);
			this.reportViewer1.TabIndex = 12;
			// 
			// vendido
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Ffinal);
			this.Controls.Add(this.Finicial);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "vendido";
			this.Text = "vendido";
			this.Load += new System.EventHandler(this.vendido_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker Ffinal;
		private System.Windows.Forms.DateTimePicker Finicial;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	}
}