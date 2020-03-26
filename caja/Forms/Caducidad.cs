using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caja.Forms
{
	public partial class Caducidad : Form
	{
		public Caducidad()
		{
			InitializeComponent();
		}

		private void Caducidad_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtLote.Text == "")
			{
				MessageBox.Show("Debe de ingresar un lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				intercambios.Lote = txtLote.Text ;
				intercambios.Caducidad = dtFecha.Text + " 00:00:00";
				this.Close();
			}
		}
	}
}
