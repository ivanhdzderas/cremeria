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
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbResta = new System.Windows.Forms.Label();
			this.txtEfectivo = new System.Windows.Forms.TextBox();
			this.txtTarjeta = new System.Windows.Forms.TextBox();
			this.chkFactura = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbCobrar = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTransferencia = new System.Windows.Forms.TextBox();
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(83, 100);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Efectivo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(91, 164);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tarjeta";
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
			// txtEfectivo
			// 
			this.txtEfectivo.Location = new System.Drawing.Point(157, 97);
			this.txtEfectivo.Name = "txtEfectivo";
			this.txtEfectivo.Size = new System.Drawing.Size(150, 26);
			this.txtEfectivo.TabIndex = 12;
			this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
			this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
			// 
			// txtTarjeta
			// 
			this.txtTarjeta.Location = new System.Drawing.Point(157, 161);
			this.txtTarjeta.Name = "txtTarjeta";
			this.txtTarjeta.Size = new System.Drawing.Size(150, 26);
			this.txtTarjeta.TabIndex = 14;
			this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTarjeta.TextChanged += new System.EventHandler(this.txtTarjeta_TextChanged);
			this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 132);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 20);
			this.label2.TabIndex = 19;
			this.label2.Text = "Transferencia";
			// 
			// txtTransferencia
			// 
			this.txtTransferencia.Location = new System.Drawing.Point(157, 129);
			this.txtTransferencia.Name = "txtTransferencia";
			this.txtTransferencia.Size = new System.Drawing.Size(150, 26);
			this.txtTransferencia.TabIndex = 20;
			// 
			// cobro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 409);
			this.Controls.Add(this.txtTransferencia);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.lbCobrar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkFactura);
			this.Controls.Add(this.txtTarjeta);
			this.Controls.Add(this.txtEfectivo);
			this.Controls.Add(this.lbResta);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label lbResta;
		private System.Windows.Forms.TextBox txtEfectivo;
		private System.Windows.Forms.TextBox txtTarjeta;
		private System.Windows.Forms.CheckBox chkFactura;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbCobrar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTransferencia;
	}
}