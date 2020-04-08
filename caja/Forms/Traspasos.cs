using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms
{
	public partial class Traspasos : Form
	{
		public Traspasos()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtTraspasos.Rows.Clear();
			Transfers transferencias = new Transfers();
			List<Transfers> lista = transferencias.getTransfers();
			foreach(Transfers item in lista)
			{
				dtTraspasos.Rows.Add(item.Id, item.Folio, item.Sucursal, item.Fecha, item.Total);
			}
		}
		private void Traspasos_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Transfer_forms Producto = new Transfer_forms();

			Producto.Show(this);
		}
	}
}
