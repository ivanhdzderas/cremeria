namespace caja.Forms
{
	partial class busca_producto
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
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.SuspendLayout();
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.AllowUserToDeleteRows = false;
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo1,
            this.codigo2,
            this.codigo3,
            this.codigo4,
            this.codigo5,
            this.descripcion,
            this.precio1,
            this.precio2,
            this.precio3,
            this.precio4,
            this.precio5});
			this.dtProductos.Location = new System.Drawing.Point(12, 75);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(776, 150);
			this.dtProductos.TabIndex = 0;
			this.dtProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtProductos_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Codigo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(282, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descripcion";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(62, 12);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(168, 20);
			this.txtCodigo.TabIndex = 3;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(351, 12);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(437, 20);
			this.txtDescripcion.TabIndex = 4;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// codigo1
			// 
			this.codigo1.HeaderText = "Codigo 1";
			this.codigo1.Name = "codigo1";
			this.codigo1.ReadOnly = true;
			// 
			// codigo2
			// 
			this.codigo2.HeaderText = "Codigo 2";
			this.codigo2.Name = "codigo2";
			this.codigo2.ReadOnly = true;
			// 
			// codigo3
			// 
			this.codigo3.HeaderText = "Codigo3";
			this.codigo3.Name = "codigo3";
			this.codigo3.ReadOnly = true;
			// 
			// codigo4
			// 
			this.codigo4.HeaderText = "Codigo 4";
			this.codigo4.Name = "codigo4";
			this.codigo4.ReadOnly = true;
			// 
			// codigo5
			// 
			this.codigo5.HeaderText = "Codigo 5";
			this.codigo5.Name = "codigo5";
			this.codigo5.ReadOnly = true;
			// 
			// descripcion
			// 
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			this.descripcion.ReadOnly = true;
			// 
			// precio1
			// 
			this.precio1.HeaderText = "Precio1";
			this.precio1.Name = "precio1";
			this.precio1.ReadOnly = true;
			// 
			// precio2
			// 
			this.precio2.HeaderText = "Precio 2";
			this.precio2.Name = "precio2";
			this.precio2.ReadOnly = true;
			// 
			// precio3
			// 
			this.precio3.HeaderText = "Precio 3";
			this.precio3.Name = "precio3";
			this.precio3.ReadOnly = true;
			// 
			// precio4
			// 
			this.precio4.HeaderText = "Precio 4";
			this.precio4.Name = "precio4";
			this.precio4.ReadOnly = true;
			// 
			// precio5
			// 
			this.precio5.HeaderText = "Precio 5";
			this.precio5.Name = "precio5";
			this.precio5.ReadOnly = true;
			// 
			// busca_producto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 237);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtProductos);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "busca_producto";
			this.Text = "Busca Producto";
			this.Load += new System.EventHandler(this.busca_producto_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo1;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo2;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo3;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo4;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo5;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio1;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio2;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio3;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio4;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio5;
	}
}