namespace caja.Forms
{
	partial class retiro
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
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lbTotal = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.num20 = new System.Windows.Forms.NumericUpDown();
			this.num50 = new System.Windows.Forms.NumericUpDown();
			this.num100 = new System.Windows.Forms.NumericUpDown();
			this.num200 = new System.Windows.Forms.NumericUpDown();
			this.num500 = new System.Windows.Forms.NumericUpDown();
			this.num1000 = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtIdproveedor = new System.Windows.Forms.TextBox();
			this.txtMonto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtProveedor = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num50)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num100)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num200)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num500)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num1000)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(14, 247);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "Cancelar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(111, 247);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 21;
			this.button2.Text = "Aceptar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.lbTotal);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.num20);
			this.groupBox2.Controls.Add(this.num50);
			this.groupBox2.Controls.Add(this.num100);
			this.groupBox2.Controls.Add(this.num200);
			this.groupBox2.Controls.Add(this.num500);
			this.groupBox2.Controls.Add(this.num1000);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(14, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 229);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Retiro";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 36;
			this.label6.Text = "$ 1000";
			// 
			// lbTotal
			// 
			this.lbTotal.AutoSize = true;
			this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotal.Location = new System.Drawing.Point(19, 199);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(60, 24);
			this.lbTotal.TabIndex = 35;
			this.lbTotal.Text = "label7";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 174);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(202, 10);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			// 
			// num20
			// 
			this.num20.Location = new System.Drawing.Point(60, 152);
			this.num20.Name = "num20";
			this.num20.Size = new System.Drawing.Size(120, 20);
			this.num20.TabIndex = 33;
			this.num20.ValueChanged += new System.EventHandler(this.num20_ValueChanged);
			// 
			// num50
			// 
			this.num50.Location = new System.Drawing.Point(60, 126);
			this.num50.Name = "num50";
			this.num50.Size = new System.Drawing.Size(120, 20);
			this.num50.TabIndex = 32;
			this.num50.ValueChanged += new System.EventHandler(this.num50_ValueChanged);
			// 
			// num100
			// 
			this.num100.Location = new System.Drawing.Point(60, 100);
			this.num100.Name = "num100";
			this.num100.Size = new System.Drawing.Size(120, 20);
			this.num100.TabIndex = 31;
			this.num100.ValueChanged += new System.EventHandler(this.num100_ValueChanged);
			// 
			// num200
			// 
			this.num200.Location = new System.Drawing.Point(60, 74);
			this.num200.Name = "num200";
			this.num200.Size = new System.Drawing.Size(120, 20);
			this.num200.TabIndex = 30;
			this.num200.ValueChanged += new System.EventHandler(this.num200_ValueChanged);
			// 
			// num500
			// 
			this.num500.Location = new System.Drawing.Point(60, 48);
			this.num500.Name = "num500";
			this.num500.Size = new System.Drawing.Size(120, 20);
			this.num500.TabIndex = 29;
			this.num500.ValueChanged += new System.EventHandler(this.num500_ValueChanged);
			// 
			// num1000
			// 
			this.num1000.Location = new System.Drawing.Point(60, 22);
			this.num1000.Name = "num1000";
			this.num1000.Size = new System.Drawing.Size(120, 20);
			this.num1000.TabIndex = 28;
			this.num1000.ValueChanged += new System.EventHandler(this.num1000_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 154);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "$ 20";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "$ 50";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "$ 100";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "$ 200";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "$ 500";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtIdproveedor);
			this.groupBox3.Controls.Add(this.txtMonto);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.txtProveedor);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(220, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(468, 229);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Proveedores";
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// txtIdproveedor
			// 
			this.txtIdproveedor.Location = new System.Drawing.Point(68, 21);
			this.txtIdproveedor.Name = "txtIdproveedor";
			this.txtIdproveedor.Size = new System.Drawing.Size(72, 20);
			this.txtIdproveedor.TabIndex = 4;
			this.txtIdproveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdproveedor_KeyDown);
			// 
			// txtMonto
			// 
			this.txtMonto.Location = new System.Drawing.Point(68, 47);
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Size = new System.Drawing.Size(100, 20);
			this.txtMonto.TabIndex = 3;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(25, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Monto";
			// 
			// txtProveedor
			// 
			this.txtProveedor.Location = new System.Drawing.Point(146, 21);
			this.txtProveedor.Name = "txtProveedor";
			this.txtProveedor.Size = new System.Drawing.Size(316, 20);
			this.txtProveedor.TabIndex = 1;
			this.txtProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProveedor_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Proveedor";
			// 
			// retiro
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(700, 306);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "retiro";
			this.Text = "Retiro";
			this.Load += new System.EventHandler(this.retiro_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num50)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num100)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num200)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num500)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num1000)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbTotal;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown num20;
		private System.Windows.Forms.NumericUpDown num50;
		private System.Windows.Forms.NumericUpDown num100;
		private System.Windows.Forms.NumericUpDown num200;
		private System.Windows.Forms.NumericUpDown num500;
		private System.Windows.Forms.NumericUpDown num1000;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtMonto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtProveedor;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtIdproveedor;
	}
}