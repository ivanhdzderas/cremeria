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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.num1000 = new System.Windows.Forms.NumericUpDown();
			this.num500 = new System.Windows.Forms.NumericUpDown();
			this.num200 = new System.Windows.Forms.NumericUpDown();
			this.num100 = new System.Windows.Forms.NumericUpDown();
			this.num50 = new System.Windows.Forms.NumericUpDown();
			this.num20 = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbTotal = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.num1000)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num500)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num200)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num100)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num50)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num20)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "$ 500";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "$ 200";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "$ 100";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "$ 50";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "$ 20";
			// 
			// num1000
			// 
			this.num1000.Location = new System.Drawing.Point(57, 12);
			this.num1000.Name = "num1000";
			this.num1000.Size = new System.Drawing.Size(120, 20);
			this.num1000.TabIndex = 12;
			this.num1000.ValueChanged += new System.EventHandler(this.num1000_ValueChanged);
			// 
			// num500
			// 
			this.num500.Location = new System.Drawing.Point(57, 38);
			this.num500.Name = "num500";
			this.num500.Size = new System.Drawing.Size(120, 20);
			this.num500.TabIndex = 13;
			this.num500.ValueChanged += new System.EventHandler(this.num500_ValueChanged);
			// 
			// num200
			// 
			this.num200.Location = new System.Drawing.Point(57, 64);
			this.num200.Name = "num200";
			this.num200.Size = new System.Drawing.Size(120, 20);
			this.num200.TabIndex = 14;
			this.num200.ValueChanged += new System.EventHandler(this.num200_ValueChanged);
			// 
			// num100
			// 
			this.num100.Location = new System.Drawing.Point(57, 90);
			this.num100.Name = "num100";
			this.num100.Size = new System.Drawing.Size(120, 20);
			this.num100.TabIndex = 15;
			this.num100.ValueChanged += new System.EventHandler(this.num100_ValueChanged);
			// 
			// num50
			// 
			this.num50.Location = new System.Drawing.Point(57, 116);
			this.num50.Name = "num50";
			this.num50.Size = new System.Drawing.Size(120, 20);
			this.num50.TabIndex = 16;
			this.num50.ValueChanged += new System.EventHandler(this.num50_ValueChanged);
			// 
			// num20
			// 
			this.num20.Location = new System.Drawing.Point(57, 142);
			this.num20.Name = "num20";
			this.num20.Size = new System.Drawing.Size(120, 20);
			this.num20.TabIndex = 17;
			this.num20.ValueChanged += new System.EventHandler(this.num20_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(11, 164);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(196, 10);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			// 
			// lbTotal
			// 
			this.lbTotal.AutoSize = true;
			this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotal.Location = new System.Drawing.Point(16, 189);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(60, 24);
			this.lbTotal.TabIndex = 19;
			this.lbTotal.Text = "label7";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(14, 233);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "Cancelar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(111, 233);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 21;
			this.button2.Text = "Aceptar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "$ 1000";
			// 
			// retiro
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(205, 268);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbTotal);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.num20);
			this.Controls.Add(this.num50);
			this.Controls.Add(this.num100);
			this.Controls.Add(this.num200);
			this.Controls.Add(this.num500);
			this.Controls.Add(this.num1000);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "retiro";
			this.Text = "Retiro";
			this.Load += new System.EventHandler(this.retiro_Load);
			((System.ComponentModel.ISupportInitialize)(this.num1000)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num500)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num200)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num100)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num50)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num20)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown num1000;
		private System.Windows.Forms.NumericUpDown num500;
		private System.Windows.Forms.NumericUpDown num200;
		private System.Windows.Forms.NumericUpDown num100;
		private System.Windows.Forms.NumericUpDown num50;
		private System.Windows.Forms.NumericUpDown num20;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbTotal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
	}
}