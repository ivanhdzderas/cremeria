namespace caja
{
    partial class inventario
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo,
            this.codigo2,
            this.codigo3,
            this.codigo4,
            this.codigo5,
            this.descripcion,
            this.existencia,
            this.precio1,
            this.precio2,
            this.precio3,
            this.precio4,
            this.precio5});
			this.dataGridView1.Location = new System.Drawing.Point(12, 89);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(663, 170);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo 1";
			this.codigo.Name = "codigo";
			this.codigo.ReadOnly = true;
			// 
			// codigo2
			// 
			this.codigo2.HeaderText = "Codigo 2";
			this.codigo2.Name = "codigo2";
			this.codigo2.ReadOnly = true;
			// 
			// codigo3
			// 
			this.codigo3.HeaderText = "Codigo 3";
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
			// existencia
			// 
			this.existencia.HeaderText = "Existencia";
			this.existencia.Name = "existencia";
			this.existencia.ReadOnly = true;
			// 
			// precio1
			// 
			this.precio1.HeaderText = "Precio 1";
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Descripcion";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(472, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Codigo";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(78, 30);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(380, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(518, 30);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(157, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(600, 265);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(441, 265);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(153, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Productos por Caducar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(287, 265);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(148, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Todos los productos";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// inventario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 300);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "inventario";
			this.Text = "inventario";
			this.Load += new System.EventHandler(this.inventario_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo4;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo5;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio2;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio3;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio4;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio5;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}