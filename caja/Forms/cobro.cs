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
	public partial class cobro : Form
	{
		public cobro()
		{
			InitializeComponent();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            caja.cancelado = true;
            this.Close();
		}

		private void cobro_Load(object sender, EventArgs e)
		{
            lbCobrar.Text = lbResta.Text;
            
		}

		private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
		{
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtEfectivo.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtTarjeta.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void calcula() {
            double restantes = 0;
            double total = Convert.ToDouble(lbCobrar.Text);
            double tarjeta = 0;
            double efectivo = 0;
            if (txtTarjeta.Text != "") {
                tarjeta = Convert.ToDouble(txtTarjeta.Text);
            }
            if (txtEfectivo.Text != "") {
                efectivo = Convert.ToDouble(txtEfectivo.Text);
            }

            restantes = total - (tarjeta + efectivo);
            lbResta.Text = string.Format("{0:#,0.00}", restantes);
        }
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            txtEfectivo.Text = string.Format("{0:#,0.00}", txtEfectivo.Text);
            calcula();
        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            txtTarjeta.Text = string.Format("{0:#,0.00}", txtTarjeta.Text);
            calcula();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                caja.efectivo = Convert.ToDouble(txtEfectivo.Text);
            }
            else {
                caja.efectivo = 0;
            }

            if (txtTarjeta.Text != "")
            {
                caja.tarjeta = Convert.ToDouble(txtTarjeta.Text);
            }
            else {
                caja.tarjeta = 0;
            }

            if (txtTransferencia.Text != "")
            {
                caja.transferencia = Convert.ToDouble(txtTransferencia.Text);
            }
            else {
                caja.transferencia = 0;
            }

            caja.factura = Convert.ToBoolean(chkFactura.Checked);
            this.Close();
               
            
        }
    }
}
