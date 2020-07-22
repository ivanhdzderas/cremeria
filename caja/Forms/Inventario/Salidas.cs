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
using MySql.Data.MySqlClient;

namespace caja.Forms.Inventario
{
	public partial class Salidas : Form
	{
		public Salidas()
		{
			InitializeComponent();
		}

		private void Salidas_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga() {
			dtSalidas.Rows.Clear();
			Inv_out inv = new Inv_out();
			using (inv)
			{
				List<Inv_out> result = inv.getLista();
				foreach (Inv_out item in result)
				{
					dtSalidas.Rows.Add(item.Date, item.Id, item.Status);
				}
			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_salida.folio = "0";
			Form_salida new_salida = new Form_salida();
			new_salida.Owner = this;
			new_salida.Show();
		}

		private void dtSalidas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtSalidas.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtSalidas.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["folio"].Value);
			Form_salida.folio = codigo;
			Form_salida new_salida = new Form_salida();
			new_salida.Owner = this;
			new_salida.Show();
		}

		private void dtSalidas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtSalidas.CurrentRow.Index;
				string valor = dtSalidas.Rows[i].Cells["folio"].Value.ToString();

				Form_salida.folio = valor;
				Form_salida new_salida = new Form_salida();
				new_salida.Owner = this;
				new_salida.Show();
			}
		}
	}
}
