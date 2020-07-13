namespace caja.Forms.Reportes
{
	partial class Ganancias
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
			this.label2 = new System.Windows.Forms.Label();
			this.fInicial = new System.Windows.Forms.DateTimePicker();
			this.fFinal = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dtGanancias = new System.Windows.Forms.DataGridView();
			this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtGanancias)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fecha inicial";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(252, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Fecha Final";
			// 
			// fInicial
			// 
			this.fInicial.Location = new System.Drawing.Point(84, 23);
			this.fInicial.Name = "fInicial";
			this.fInicial.Size = new System.Drawing.Size(139, 20);
			this.fInicial.TabIndex = 2;
			// 
			// fFinal
			// 
			this.fFinal.Location = new System.Drawing.Point(320, 23);
			this.fFinal.Name = "fFinal";
			this.fFinal.Size = new System.Drawing.Size(139, 20);
			this.fFinal.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(483, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Consultar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 62);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Excel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(97, 62);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "PDF";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// dtGanancias
			// 
			this.dtGanancias.AllowUserToAddRows = false;
			this.dtGanancias.AllowUserToDeleteRows = false;
			this.dtGanancias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtGanancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtGanancias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.producto,
            this.costo,
            this.ganancia,
            this.bruto});
			this.dtGanancias.Location = new System.Drawing.Point(12, 91);
			this.dtGanancias.Name = "dtGanancias";
			this.dtGanancias.ReadOnly = true;
			this.dtGanancias.Size = new System.Drawing.Size(776, 229);
			this.dtGanancias.TabIndex = 7;
			// 
			// producto
			// 
			this.producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.producto.HeaderText = "Producto";
			this.producto.Name = "producto";
			this.producto.ReadOnly = true;
			// 
			// costo
			// 
			this.costo.HeaderText = "Costo";
			this.costo.Name = "costo";
			this.costo.ReadOnly = true;
			// 
			// ganancia
			// 
			this.ganancia.HeaderText = "Ganancia";
			this.ganancia.Name = "ganancia";
			this.ganancia.ReadOnly = true;
			// 
			// bruto
			// 
			this.bruto.HeaderText = "Bruto";
			this.bruto.Name = "bruto";
			this.bruto.ReadOnly = true;
			// 
			// Ganancias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 332);
			this.Controls.Add(this.dtGanancias);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.fFinal);
			this.Controls.Add(this.fInicial);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Ganancias";
			this.Text = "Ganancias";
			this.Load += new System.EventHandler(this.Ganancias_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtGanancias)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker fInicial;
		private System.Windows.Forms.DateTimePicker fFinal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGridView dtGanancias;
		private System.Windows.Forms.DataGridViewTextBoxColumn producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn ganancia;
		private System.Windows.Forms.DataGridViewTextBoxColumn bruto;
	}
}