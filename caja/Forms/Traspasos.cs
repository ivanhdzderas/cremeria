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

			Offices oficinas = new Offices();


			foreach(Transfers item in lista)
			{
				List<Offices> sucursal = oficinas.GetOfficesbyid(Convert.ToInt16(item.Sucursal));
				dtTraspasos.Rows.Add(item.Id, item.Folio, sucursal[0].Name, item.Fecha, item.Total);
			}
		}
		private void Traspasos_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Transfer_forms.id_transfer = 0;
			Transfer_forms Producto = new Transfer_forms();

			Producto.ShowDialog();
			carga();
		}

		private void dtTraspasos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtTraspasos.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtTraspasos.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Transfer_forms.id_transfer =Convert.ToInt16(codigo);
			Transfer_forms Producto = new Transfer_forms();

			Producto.ShowDialog();
			carga();
		}
	}
}
