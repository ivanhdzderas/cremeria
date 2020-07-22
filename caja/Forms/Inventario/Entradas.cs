using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms.Inventario
{
	public partial class Entradas : Form
	{
		public Entradas()
		{
			InitializeComponent();
		}

		private void Entradas_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga() {
			dgvEntradas.Rows.Clear();
			Inv_in inv = new Inv_in();
			using (inv)
			{
				List<Inv_in> result = inv.getLista();
				foreach (Inv_in item in result)
				{
					dgvEntradas.Rows.Add(item.Date, item.Id, item.Status);
				}
			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_entrada.folio = "0";
			Form_entrada new_entrada = new Form_entrada();
			new_entrada.Owner = this;
			new_entrada.Show();
		}

		private void dgvEntradas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dgvEntradas.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dgvEntradas.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["folio"].Value);
			Form_entrada.folio = codigo;
			Form_entrada new_entrada = new Form_entrada();
			new_entrada.Owner = this;
			new_entrada.Show();
		}

		private void dgvEntradas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dgvEntradas.CurrentRow.Index;
				string valor = dgvEntradas.Rows[i].Cells["folio"].Value.ToString();

				Form_entrada.folio = valor;
				Form_entrada new_entrada = new Form_entrada();
				new_entrada.Owner = this;
				new_entrada.Show();
			}
		}
	}
}
