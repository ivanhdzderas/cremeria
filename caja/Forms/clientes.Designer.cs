namespace caja
{
    partial class clientes
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
			this.components = new System.ComponentModel.Container();
			this.dtgClientes = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgClientes
			// 
			this.dtgClientes.AllowUserToAddRows = false;
			this.dtgClientes.AllowUserToDeleteRows = false;
			this.dtgClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.rfc});
			this.dtgClientes.Location = new System.Drawing.Point(12, 61);
			this.dtgClientes.Name = "dtgClientes";
			this.dtgClientes.ReadOnly = true;
			this.dtgClientes.Size = new System.Drawing.Size(525, 439);
			this.dtgClientes.TabIndex = 0;
			this.dtgClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgClientes_CellDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(111, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre:";
			// 
			// txtBuscar
			// 
			this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBuscar.Location = new System.Drawing.Point(164, 29);
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(373, 20);
			this.txtBuscar.TabIndex = 2;
			this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 26);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "&Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// id
			// 
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			// 
			// nombre
			// 
			this.nombre.HeaderText = "Nombre";
			this.nombre.Name = "nombre";
			this.nombre.ReadOnly = true;
			// 
			// rfc
			// 
			this.rfc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.rfc.HeaderText = "RFC";
			this.rfc.Name = "rfc";
			this.rfc.ReadOnly = true;
			// 
			// clientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 512);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtBuscar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtgClientes);
			this.Name = "clientes";
			this.Text = "clientes";
			this.Load += new System.EventHandler(this.clientes_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn rfc;
	}
}