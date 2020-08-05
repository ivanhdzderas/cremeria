namespace caja.Forms.Reportes
{
	partial class Cierre_caja
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
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Finicial = new System.Windows.Forms.DateTimePicker();
			this.Ffinal = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.chkDetallado = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.Location = new System.Drawing.Point(0, 39);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(800, 411);
			this.reportViewer1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Fecha Inicial";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(353, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Fecha Final";
			// 
			// Finicial
			// 
			this.Finicial.Location = new System.Drawing.Point(124, 13);
			this.Finicial.Name = "Finicial";
			this.Finicial.Size = new System.Drawing.Size(200, 20);
			this.Finicial.TabIndex = 3;
			// 
			// Ffinal
			// 
			this.Ffinal.Location = new System.Drawing.Point(421, 12);
			this.Ffinal.Name = "Ffinal";
			this.Ffinal.Size = new System.Drawing.Size(200, 20);
			this.Ffinal.TabIndex = 4;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(704, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Mostrar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chkDetallado
			// 
			this.chkDetallado.AutoSize = true;
			this.chkDetallado.Location = new System.Drawing.Point(627, 12);
			this.chkDetallado.Name = "chkDetallado";
			this.chkDetallado.Size = new System.Drawing.Size(71, 17);
			this.chkDetallado.TabIndex = 6;
			this.chkDetallado.Text = "Detallado";
			this.chkDetallado.UseVisualStyleBackColor = true;
			// 
			// Cierre_caja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.chkDetallado);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Ffinal);
			this.Controls.Add(this.Finicial);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.reportViewer1);
			this.Name = "Cierre_caja";
			this.Text = "Cierre_caja";
			this.Load += new System.EventHandler(this.Cierre_caja_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker Finicial;
		private System.Windows.Forms.DateTimePicker Ffinal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox chkDetallado;
	}
}