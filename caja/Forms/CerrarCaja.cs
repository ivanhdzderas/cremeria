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
	public partial class CerrarCaja : Form
	{
		public CerrarCaja()
		{
			InitializeComponent();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
		private void calcula() {
			double diferencia = 0;
			double deberia = Convert.ToDouble(lbEsperado.Text)-Convert.ToDouble(txtReal.Text);
			lbDiferencia.Text = string.Format("{0:#,0.00}", deberia);
		}
		private void button2_Click(object sender, EventArgs e)
		{
			inicial.cancelado = true;
			this.Close();
		}

		private void CerrarCaja_Load(object sender, EventArgs e)
		{
			
			Tickets ticket = new Tickets();
			List<Tickets> lista = ticket.getbyUser(Convert.ToInt16(inicial.id_usario));
			double total = 0;
			Cortes cortes = new Cortes();
			List<Cortes> ultimo = cortes.getnoclose(Convert.ToInt16(inicial.id_usario));
			foreach (Cortes item in ultimo) {
				total += item.Caja_inicial;
			}

			foreach (Tickets item in lista) {
				total += item.Total;
			}
			lbEsperado.Text= string.Format("{0:#,0.00}", total);
			txtReal.TextAlign = HorizontalAlignment.Right;
			txtReal.Text = "0.00";
			calcula();
		}

		private void txtReal_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (ch == 46 && txtReal.Text.IndexOf('.') != -1) {
				e.Handled = true;
				return;
			}
			if (!Char.IsDigit(ch) && ch != 9 && ch != 46) {
				e.Handled = true;
			}
		}

		private void txtReal_Leave(object sender, EventArgs e)
		{
			if (txtReal.Text == "") {
				txtReal.Text = "0.00";
			}
		}

		private void txtReal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Cortes corte = new Cortes();
			corte.Caja_fin = Convert.ToDouble(txtReal.Text);
			corte.Diferencia = Convert.ToDouble(lbDiferencia.Text);
			corte.Id_usuario = Convert.ToInt16(inicial.id_usario);
			corte.end_caja();
			inicial.exit = true;
			this.Close();
		}

		private void txtReal_TextChanged(object sender, EventArgs e)
		{
			calcula();
		}
	}
}
