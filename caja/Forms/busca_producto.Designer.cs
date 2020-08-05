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
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
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
            this.descripcion,
            this.precio1,
            this.precio2});
			this.dtProductos.Location = new System.Drawing.Point(12, 75);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(776, 150);
			this.dtProductos.TabIndex = 2;
			this.dtProductos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtProductos_CellMouseDoubleClick);
			this.dtProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtProductos_KeyDown);
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
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
			this.txtCodigo.TabIndex = 0;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(351, 12);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(437, 20);
			this.txtDescripcion.TabIndex = 1;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
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
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio1;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio2;
	}
}