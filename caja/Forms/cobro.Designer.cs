namespace caja.Forms
{
	partial class cobro
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
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnCobrar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.lbResta = new System.Windows.Forms.Label();
			this.chkFactura = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbCobrar = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRecibido = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbMpago = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::caja.Properties.Resources.cross;
			this.btnCancelar.Location = new System.Drawing.Point(188, 284);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(5);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(108, 103);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnCobrar
			// 
			this.btnCobrar.Image = global::caja.Properties.Resources.coins;
			this.btnCobrar.Location = new System.Drawing.Point(20, 284);
			this.btnCobrar.Margin = new System.Windows.Forms.Padding(5);
			this.btnCobrar.Name = "btnCobrar";
			this.btnCobrar.Size = new System.Drawing.Size(108, 103);
			this.btnCobrar.TabIndex = 0;
			this.btnCobrar.Text = "Cobrar";
			this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCobrar.UseVisualStyleBackColor = true;
			this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(74, 242);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "Restante";
			// 
			// lbResta
			// 
			this.lbResta.AutoSize = true;
			this.lbResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbResta.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbResta.Location = new System.Drawing.Point(155, 238);
			this.lbResta.Name = "lbResta";
			this.lbResta.Size = new System.Drawing.Size(66, 24);
			this.lbResta.TabIndex = 11;
			this.lbResta.Text = "label6";
			// 
			// chkFactura
			// 
			this.chkFactura.AutoSize = true;
			this.chkFactura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkFactura.Location = new System.Drawing.Point(20, 191);
			this.chkFactura.Name = "chkFactura";
			this.chkFactura.Size = new System.Drawing.Size(149, 24);
			this.chkFactura.TabIndex = 15;
			this.chkFactura.Text = "Necesita Factura";
			this.chkFactura.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(19, 213);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 10);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// lbCobrar
			// 
			this.lbCobrar.AutoSize = true;
			this.lbCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCobrar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lbCobrar.Location = new System.Drawing.Point(97, 30);
			this.lbCobrar.Name = "lbCobrar";
			this.lbCobrar.Size = new System.Drawing.Size(115, 39);
			this.lbCobrar.TabIndex = 17;
			this.lbCobrar.Text = "label2";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(8, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(299, 10);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(72, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 20);
			this.label4.TabIndex = 21;
			this.label4.Text = "Recibido";
			// 
			// txtRecibido
			// 
			this.txtRecibido.Location = new System.Drawing.Point(149, 150);
			this.txtRecibido.Name = "txtRecibido";
			this.txtRecibido.Size = new System.Drawing.Size(100, 26);
			this.txtRecibido.TabIndex = 22;
			this.txtRecibido.TextChanged += new System.EventHandler(this.txtRecibido_TextChanged);
			this.txtRecibido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecibido_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 119);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 20);
			this.label1.TabIndex = 23;
			this.label1.Text = "Metodo de pago";
			// 
			// cbMpago
			// 
			this.cbMpago.FormattingEnabled = true;
			this.cbMpago.Location = new System.Drawing.Point(149, 116);
			this.cbMpago.Name = "cbMpago";
			this.cbMpago.Size = new System.Drawing.Size(121, 28);
			this.cbMpago.TabIndex = 24;
			this.cbMpago.SelectedIndexChanged += new System.EventHandler(this.cbMpago_SelectedIndexChanged);
			// 
			// cobro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 409);
			this.Controls.Add(this.cbMpago);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRecibido);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.lbCobrar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkFactura);
			this.Controls.Add(this.lbResta);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnCobrar);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "cobro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "cobro";
			this.Load += new System.EventHandler(this.cobro_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCobrar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label lbResta;
		private System.Windows.Forms.CheckBox chkFactura;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbCobrar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRecibido;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbMpago;
	}
}