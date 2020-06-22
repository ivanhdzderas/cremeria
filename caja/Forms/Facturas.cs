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
	public partial class Facturas : Form
	{
		public Facturas()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//producto.Codigo = "";
			Form_factura Facturas = new Form_factura();

			Facturas.Show(this);
		}
	}
}
