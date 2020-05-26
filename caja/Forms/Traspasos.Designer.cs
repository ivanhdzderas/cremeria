namespace caja.Forms
{
	partial class Traspasos
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
			this.dtTraspasos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtTraspasos)).BeginInit();
			this.SuspendLayout();
			// 
			// dtTraspasos
			// 
			this.dtTraspasos.AllowUserToAddRows = false;
			this.dtTraspasos.AllowUserToDeleteRows = false;
			this.dtTraspasos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtTraspasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtTraspasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.folio,
            this.sucursal,
            this.fecha,
            this.total});
			this.dtTraspasos.Location = new System.Drawing.Point(12, 27);
			this.dtTraspasos.Name = "dtTraspasos";
			this.dtTraspasos.ReadOnly = true;
			this.dtTraspasos.Size = new System.Drawing.Size(776, 283);
			this.dtTraspasos.TabIndex = 0;
			this.dtTraspasos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtTraspasos_CellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// folio
			// 
			this.folio.HeaderText = "Folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// sucursal
			// 
			this.sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.sucursal.HeaderText = "Sucursal";
			this.sucursal.Name = "sucursal";
			this.sucursal.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(713, 316);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(632, 316);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Carga XML";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Traspasos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 351);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtTraspasos);
			this.Name = "Traspasos";
			this.Text = "Traspasos";
			this.Load += new System.EventHandler(this.Traspasos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtTraspasos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtTraspasos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}