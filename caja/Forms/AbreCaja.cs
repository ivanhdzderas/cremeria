using System;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms
{
	public partial class AbreCaja : Form
	{
		public AbreCaja()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Cortes corto = new Cortes();
			corto.Id_usuario = Convert.ToInt16(inicial.id_usario);
			corto.Caja_inicial = Convert.ToDouble(txtEfectivo.Text);
			corto.start_caja();
			this.Close();
		}

		private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (ch == 46 && txtEfectivo.Text.IndexOf('.') != -1)
			{
				e.Handled = true;
				return;
			}
			if (!Char.IsDigit(ch) && ch != 9 && ch != 46)
			{
				e.Handled = true;
			}

			
		}

		private void AbreCaja_Load(object sender, EventArgs e)
		{
			txtEfectivo.TextAlign = HorizontalAlignment.Right;
			txtEfectivo.Text = "0.00";
		}

		private void txtEfectivo_Leave(object sender, EventArgs e)
		{
			if (txtEfectivo.Text == "") {
				txtEfectivo.Text = "0.00";
			}
		}

		private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}
	}
}
