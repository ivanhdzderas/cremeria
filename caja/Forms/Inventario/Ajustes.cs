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
namespace caja.Forms.Inventario
{
	public partial class Ajustes : Form
	{
		public Ajustes()
		{
			InitializeComponent();
		}

		private void Ajustes_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga() {
			dtAjustes.Rows.Clear();
			Ajuste ajuste = new Ajuste();
			List < Ajuste > resultado= ajuste.getAjustes();
			foreach (Ajuste item in resultado) {
				dtAjustes.Rows.Add(item.Id, item.Fecha, item.Total);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_ajustes.folio = "0";
			Form_ajustes new_ajuste = new Form_ajustes();
			new_ajuste.Owner = this;
			new_ajuste.Show();
		}

		private void dtAjustes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtAjustes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtAjustes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["folio"].Value);
			Form_ajustes.folio = codigo;
			Form_ajustes new_ajuste = new Form_ajustes();
			new_ajuste.Owner = this;
			new_ajuste.Show();

		}

		private void dtAjustes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtAjustes.CurrentRow.Index;
				string valor = dtAjustes.Rows[i].Cells["folio"].Value.ToString();
				Form_ajustes.folio = valor;
				Form_ajustes new_ajuste = new Form_ajustes();
				new_ajuste.Owner = this;
				new_ajuste.Show();
			}
		}
	}
}
