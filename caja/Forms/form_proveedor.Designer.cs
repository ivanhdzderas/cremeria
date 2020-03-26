namespace caja.Forms
{
	partial class form_proveedor
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtNotas = new System.Windows.Forms.TextBox();
			this.txtMunicipio = new System.Windows.Forms.TextBox();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.txtCp = new System.Windows.Forms.TextBox();
			this.txtColonia = new System.Windows.Forms.TextBox();
			this.txtNumInt = new System.Windows.Forms.TextBox();
			this.txtNumExt = new System.Windows.Forms.TextBox();
			this.txtCalle = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(202, 380);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 52;
			this.button2.Text = "Cancelar";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(51, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 51;
			this.button1.Text = "Guardar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(98, 246);
			this.txtTelefono.Mask = "(999)000-0000";
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(100, 20);
			this.txtTelefono.TabIndex = 50;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(98, 341);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(311, 20);
			this.txtEmail.TabIndex = 49;
			// 
			// txtNotas
			// 
			this.txtNotas.Location = new System.Drawing.Point(98, 272);
			this.txtNotas.Multiline = true;
			this.txtNotas.Name = "txtNotas";
			this.txtNotas.Size = new System.Drawing.Size(311, 63);
			this.txtNotas.TabIndex = 48;
			// 
			// txtMunicipio
			// 
			this.txtMunicipio.Location = new System.Drawing.Point(98, 220);
			this.txtMunicipio.Name = "txtMunicipio";
			this.txtMunicipio.Size = new System.Drawing.Size(311, 20);
			this.txtMunicipio.TabIndex = 47;
			// 
			// txtEstado
			// 
			this.txtEstado.Location = new System.Drawing.Point(98, 194);
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(311, 20);
			this.txtEstado.TabIndex = 46;
			// 
			// txtCp
			// 
			this.txtCp.Location = new System.Drawing.Point(98, 168);
			this.txtCp.Name = "txtCp";
			this.txtCp.Size = new System.Drawing.Size(100, 20);
			this.txtCp.TabIndex = 45;
			// 
			// txtColonia
			// 
			this.txtColonia.Location = new System.Drawing.Point(98, 142);
			this.txtColonia.Name = "txtColonia";
			this.txtColonia.Size = new System.Drawing.Size(311, 20);
			this.txtColonia.TabIndex = 44;
			// 
			// txtNumInt
			// 
			this.txtNumInt.Location = new System.Drawing.Point(98, 116);
			this.txtNumInt.Name = "txtNumInt";
			this.txtNumInt.Size = new System.Drawing.Size(100, 20);
			this.txtNumInt.TabIndex = 43;
			// 
			// txtNumExt
			// 
			this.txtNumExt.Location = new System.Drawing.Point(98, 90);
			this.txtNumExt.Name = "txtNumExt";
			this.txtNumExt.Size = new System.Drawing.Size(100, 20);
			this.txtNumExt.TabIndex = 42;
			// 
			// txtCalle
			// 
			this.txtCalle.Location = new System.Drawing.Point(98, 64);
			this.txtCalle.Name = "txtCalle";
			this.txtCalle.Size = new System.Drawing.Size(311, 20);
			this.txtCalle.TabIndex = 41;
			// 
			// txtRFC
			// 
			this.txtRFC.Location = new System.Drawing.Point(98, 38);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.Size = new System.Drawing.Size(179, 20);
			this.txtRFC.TabIndex = 40;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(98, 12);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(311, 20);
			this.txtNombre.TabIndex = 39;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(54, 344);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(38, 13);
			this.label12.TabIndex = 38;
			this.label12.Text = "Correo";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(57, 275);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 13);
			this.label11.TabIndex = 37;
			this.label11.Text = "Notas";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(43, 249);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 13);
			this.label10.TabIndex = 36;
			this.label10.Text = "Telefono";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(40, 223);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 13);
			this.label9.TabIndex = 35;
			this.label9.Text = "Municipio";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(52, 197);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 34;
			this.label8.Text = "Estado";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(65, 171);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(27, 13);
			this.label7.TabIndex = 33;
			this.label7.Text = "C.P.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(50, 145);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 32;
			this.label6.Text = "Colonia";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 31;
			this.label5.Text = "Numero Exterior";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 30;
			this.label4.Text = "Numero interior";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(62, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Calle";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(64, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 28;
			this.label2.Text = "RFC";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "Nombre";
			// 
			// form_proveedor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 418);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtTelefono);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtNotas);
			this.Controls.Add(this.txtMunicipio);
			this.Controls.Add(this.txtEstado);
			this.Controls.Add(this.txtCp);
			this.Controls.Add(this.txtColonia);
			this.Controls.Add(this.txtNumInt);
			this.Controls.Add(this.txtNumExt);
			this.Controls.Add(this.txtCalle);
			this.Controls.Add(this.txtRFC);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "form_proveedor";
			this.Text = "Proveedor";
			this.Load += new System.EventHandler(this.form_proveedor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MaskedTextBox txtTelefono;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtNotas;
		private System.Windows.Forms.TextBox txtMunicipio;
		private System.Windows.Forms.TextBox txtEstado;
		private System.Windows.Forms.TextBox txtCp;
		private System.Windows.Forms.TextBox txtColonia;
		private System.Windows.Forms.TextBox txtNumInt;
		private System.Windows.Forms.TextBox txtNumExt;
		private System.Windows.Forms.TextBox txtCalle;
		private System.Windows.Forms.TextBox txtRFC;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}