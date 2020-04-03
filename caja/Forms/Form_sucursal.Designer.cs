namespace caja.Forms
{
	partial class Form_sucursal
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtDomicilio = new System.Windows.Forms.TextBox();
			this.txtServidor = new System.Windows.Forms.TextBox();
			this.txtCone = new System.Windows.Forms.TextBox();
			this.txtNotas = new System.Windows.Forms.TextBox();
			this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtFacturacion = new System.Windows.Forms.TextBox();
			this.txtRfc = new System.Windows.Forms.TextBox();
			this.txtInterior = new System.Windows.Forms.TextBox();
			this.txtExterior = new System.Windows.Forms.TextBox();
			this.txtCalle = new System.Windows.Forms.TextBox();
			this.txtColonia = new System.Windows.Forms.TextBox();
			this.txtCp = new System.Windows.Forms.TextBox();
			this.txtMunicipio = new System.Windows.Forms.TextBox();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(312, 267);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtTelefono);
			this.tabPage1.Controls.Add(this.txtNotas);
			this.tabPage1.Controls.Add(this.txtCone);
			this.tabPage1.Controls.Add(this.txtServidor);
			this.tabPage1.Controls.Add(this.txtDomicilio);
			this.tabPage1.Controls.Add(this.txtNombre);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(304, 241);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtEstado);
			this.tabPage2.Controls.Add(this.txtMunicipio);
			this.tabPage2.Controls.Add(this.txtCp);
			this.tabPage2.Controls.Add(this.txtColonia);
			this.tabPage2.Controls.Add(this.txtCalle);
			this.tabPage2.Controls.Add(this.txtExterior);
			this.tabPage2.Controls.Add(this.txtInterior);
			this.tabPage2.Controls.Add(this.txtRfc);
			this.tabPage2.Controls.Add(this.txtFacturacion);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(304, 241);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Facturacion";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nombre";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Domicilio";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Telefono";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Servidor";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Conexion";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 139);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Notas";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(66, 6);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(232, 20);
			this.txtNombre.TabIndex = 6;
			// 
			// txtDomicilio
			// 
			this.txtDomicilio.Location = new System.Drawing.Point(66, 32);
			this.txtDomicilio.Name = "txtDomicilio";
			this.txtDomicilio.Size = new System.Drawing.Size(232, 20);
			this.txtDomicilio.TabIndex = 7;
			// 
			// txtServidor
			// 
			this.txtServidor.Location = new System.Drawing.Point(66, 84);
			this.txtServidor.Name = "txtServidor";
			this.txtServidor.Size = new System.Drawing.Size(232, 20);
			this.txtServidor.TabIndex = 9;
			this.txtServidor.Leave += new System.EventHandler(this.txtServidor_Leave);
			// 
			// txtCone
			// 
			this.txtCone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCone.Enabled = false;
			this.txtCone.Location = new System.Drawing.Point(66, 110);
			this.txtCone.Name = "txtCone";
			this.txtCone.Size = new System.Drawing.Size(232, 13);
			this.txtCone.TabIndex = 10;
			// 
			// txtNotas
			// 
			this.txtNotas.Location = new System.Drawing.Point(66, 136);
			this.txtNotas.Multiline = true;
			this.txtNotas.Name = "txtNotas";
			this.txtNotas.Size = new System.Drawing.Size(232, 78);
			this.txtNotas.TabIndex = 11;
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(66, 58);
			this.txtTelefono.Mask = "(999)000-0000";
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(232, 20);
			this.txtTelefono.TabIndex = 12;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(45, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Nombre";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(61, 35);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "RFC";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(10, 61);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "Numero Interior";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 87);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(82, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "Numero Exterior";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(59, 113);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(30, 13);
			this.label11.TabIndex = 4;
			this.label11.Text = "Calle";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(47, 139);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(42, 13);
			this.label12.TabIndex = 5;
			this.label12.Text = "Colonia";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(62, 165);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(27, 13);
			this.label13.TabIndex = 6;
			this.label13.Text = "C.P.";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(37, 191);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 13);
			this.label14.TabIndex = 7;
			this.label14.Text = "Municipio";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(49, 217);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 13);
			this.label15.TabIndex = 8;
			this.label15.Text = "Estado";
			// 
			// txtFacturacion
			// 
			this.txtFacturacion.Location = new System.Drawing.Point(95, 6);
			this.txtFacturacion.Name = "txtFacturacion";
			this.txtFacturacion.Size = new System.Drawing.Size(203, 20);
			this.txtFacturacion.TabIndex = 9;
			// 
			// txtRfc
			// 
			this.txtRfc.Location = new System.Drawing.Point(95, 32);
			this.txtRfc.Name = "txtRfc";
			this.txtRfc.Size = new System.Drawing.Size(203, 20);
			this.txtRfc.TabIndex = 10;
			// 
			// txtInterior
			// 
			this.txtInterior.Location = new System.Drawing.Point(95, 58);
			this.txtInterior.Name = "txtInterior";
			this.txtInterior.Size = new System.Drawing.Size(203, 20);
			this.txtInterior.TabIndex = 11;
			// 
			// txtExterior
			// 
			this.txtExterior.Location = new System.Drawing.Point(95, 84);
			this.txtExterior.Name = "txtExterior";
			this.txtExterior.Size = new System.Drawing.Size(203, 20);
			this.txtExterior.TabIndex = 12;
			// 
			// txtCalle
			// 
			this.txtCalle.Location = new System.Drawing.Point(95, 110);
			this.txtCalle.Name = "txtCalle";
			this.txtCalle.Size = new System.Drawing.Size(203, 20);
			this.txtCalle.TabIndex = 13;
			// 
			// txtColonia
			// 
			this.txtColonia.Location = new System.Drawing.Point(95, 136);
			this.txtColonia.Name = "txtColonia";
			this.txtColonia.Size = new System.Drawing.Size(203, 20);
			this.txtColonia.TabIndex = 14;
			// 
			// txtCp
			// 
			this.txtCp.Location = new System.Drawing.Point(95, 162);
			this.txtCp.Name = "txtCp";
			this.txtCp.Size = new System.Drawing.Size(203, 20);
			this.txtCp.TabIndex = 15;
			// 
			// txtMunicipio
			// 
			this.txtMunicipio.Location = new System.Drawing.Point(95, 188);
			this.txtMunicipio.Name = "txtMunicipio";
			this.txtMunicipio.Size = new System.Drawing.Size(203, 20);
			this.txtMunicipio.TabIndex = 16;
			// 
			// txtEstado
			// 
			this.txtEstado.Location = new System.Drawing.Point(95, 214);
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(203, 20);
			this.txtEstado.TabIndex = 17;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(245, 281);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Guardar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(164, 281);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 18;
			this.button2.Text = "Cancelar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form_sucursal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 319);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_sucursal";
			this.Text = "Sucursales";
			this.Load += new System.EventHandler(this.Form_sucursal_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.MaskedTextBox txtTelefono;
		private System.Windows.Forms.TextBox txtNotas;
		private System.Windows.Forms.TextBox txtCone;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.TextBox txtDomicilio;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtEstado;
		private System.Windows.Forms.TextBox txtMunicipio;
		private System.Windows.Forms.TextBox txtCp;
		private System.Windows.Forms.TextBox txtColonia;
		private System.Windows.Forms.TextBox txtCalle;
		private System.Windows.Forms.TextBox txtExterior;
		private System.Windows.Forms.TextBox txtInterior;
		private System.Windows.Forms.TextBox txtRfc;
		private System.Windows.Forms.TextBox txtFacturacion;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}