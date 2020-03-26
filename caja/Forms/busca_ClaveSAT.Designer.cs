namespace caja.Forms
{
    partial class busca_ClaveSAT
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
			this.dgClaveSat = new System.Windows.Forms.DataGridView();
			this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgClaveSat)).BeginInit();
			this.SuspendLayout();
			// 
			// dgClaveSat
			// 
			this.dgClaveSat.AllowUserToAddRows = false;
			this.dgClaveSat.AllowUserToDeleteRows = false;
			this.dgClaveSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgClaveSat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clave,
            this.Descripcion});
			this.dgClaveSat.Location = new System.Drawing.Point(12, 91);
			this.dgClaveSat.Name = "dgClaveSat";
			this.dgClaveSat.ReadOnly = true;
			this.dgClaveSat.Size = new System.Drawing.Size(776, 347);
			this.dgClaveSat.TabIndex = 0;
			this.dgClaveSat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgClaveSat_KeyDown);
			// 
			// clave
			// 
			this.clave.HeaderText = "Clave";
			this.clave.Name = "clave";
			this.clave.ReadOnly = true;
			// 
			// Descripcion
			// 
			this.Descripcion.HeaderText = "descripcion";
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.Descripcion.Width = 400;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Busqueda";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(73, 51);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(353, 20);
			this.txtSearch.TabIndex = 3;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// busca_ClaveSAT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgClaveSat);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "busca_ClaveSAT";
			this.ShowIcon = false;
			this.Text = "busca_ClaveSAT";
			this.Load += new System.EventHandler(this.busca_ClaveSAT_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgClaveSat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgClaveSat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
    }
}