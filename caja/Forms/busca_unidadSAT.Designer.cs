namespace caja.Forms
{
    partial class busca_unidadSAT
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
            this.dgUnidadSat = new System.Windows.Forms.DataGridView();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnidadSat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgUnidadSat
            // 
            this.dgUnidadSat.AllowUserToAddRows = false;
            this.dgUnidadSat.AllowUserToDeleteRows = false;
            this.dgUnidadSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUnidadSat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clave,
            this.descripcion});
            this.dgUnidadSat.Location = new System.Drawing.Point(12, 80);
            this.dgUnidadSat.Name = "dgUnidadSat";
            this.dgUnidadSat.ReadOnly = true;
            this.dgUnidadSat.Size = new System.Drawing.Size(776, 358);
            this.dgUnidadSat.TabIndex = 0;
            this.dgUnidadSat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgUnidadSat_KeyDown);
            // 
            // clave
            // 
            this.clave.HeaderText = "Clave";
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(58, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(393, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // busca_unidadSAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgUnidadSat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "busca_unidadSAT";
            this.Text = "busca_unidadSAT";
            this.Load += new System.EventHandler(this.busca_unidadSAT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUnidadSat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgUnidadSat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}