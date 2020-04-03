namespace caja.Forms
{
	partial class Sucursales
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
			this.dtOficinas = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtOficinas)).BeginInit();
			this.SuspendLayout();
			// 
			// dtOficinas
			// 
			this.dtOficinas.AllowUserToAddRows = false;
			this.dtOficinas.AllowUserToDeleteRows = false;
			this.dtOficinas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtOficinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtOficinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.telefono,
            this.domicilio});
			this.dtOficinas.Location = new System.Drawing.Point(12, 37);
			this.dtOficinas.Name = "dtOficinas";
			this.dtOficinas.ReadOnly = true;
			this.dtOficinas.Size = new System.Drawing.Size(776, 267);
			this.dtOficinas.TabIndex = 0;
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// nombre
			// 
			this.nombre.HeaderText = "Nombre";
			this.nombre.Name = "nombre";
			this.nombre.ReadOnly = true;
			// 
			// telefono
			// 
			this.telefono.HeaderText = "Telefono";
			this.telefono.Name = "telefono";
			this.telefono.ReadOnly = true;
			// 
			// domicilio
			// 
			this.domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.domicilio.HeaderText = "Domicilio";
			this.domicilio.Name = "domicilio";
			this.domicilio.ReadOnly = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(713, 310);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Sucursales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 337);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtOficinas);
			this.Name = "Sucursales";
			this.Text = "Sucursales";
			this.Load += new System.EventHandler(this.Sucursales_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtOficinas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtOficinas;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
		private System.Windows.Forms.DataGridViewTextBoxColumn domicilio;
		private System.Windows.Forms.Button button1;
	}
}