namespace caja.Forms
{
	partial class Busca_cliente
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
			this.dtClientes = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtClientes)).BeginInit();
			this.SuspendLayout();
			// 
			// dtClientes
			// 
			this.dtClientes.AllowUserToAddRows = false;
			this.dtClientes.AllowUserToDeleteRows = false;
			this.dtClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.rfc,
            this.telefono});
			this.dtClientes.Location = new System.Drawing.Point(12, 56);
			this.dtClientes.Name = "dtClientes";
			this.dtClientes.ReadOnly = true;
			this.dtClientes.Size = new System.Drawing.Size(776, 382);
			this.dtClientes.TabIndex = 0;
			this.dtClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtClientes_CellDoubleClick);
			this.dtClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtClientes_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(489, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "RFC";
			// 
			// txtNombre
			// 
			this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNombre.Location = new System.Drawing.Point(62, 20);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(372, 20);
			this.txtNombre.TabIndex = 3;
			this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
			// 
			// txtRFC
			// 
			this.txtRFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRFC.Location = new System.Drawing.Point(523, 20);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.Size = new System.Drawing.Size(265, 20);
			this.txtRFC.TabIndex = 4;
			this.txtRFC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRFC_KeyDown);
			// 
			// id
			// 
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			// 
			// nombre
			// 
			this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nombre.HeaderText = "Nombre";
			this.nombre.Name = "nombre";
			this.nombre.ReadOnly = true;
			// 
			// rfc
			// 
			this.rfc.HeaderText = "RFC";
			this.rfc.Name = "rfc";
			this.rfc.ReadOnly = true;
			// 
			// telefono
			// 
			this.telefono.HeaderText = "Telefono";
			this.telefono.Name = "telefono";
			this.telefono.ReadOnly = true;
			// 
			// Busca_cliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtRFC);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtClientes);
			this.Name = "Busca_cliente";
			this.Text = "Busca Cliente";
			this.Load += new System.EventHandler(this.Busca_cliente_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtClientes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtClientes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtRFC;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn rfc;
		private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
	}
}