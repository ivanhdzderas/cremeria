﻿using System;
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
        public static double deberia_ser;
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
            lbResta.Text = string.Format("{0:#,0.00}", deberia_ser);
            txtRecibido.Focus();
            lbCobrar.Text = lbResta.Text;
            cbMpago.Items.Add("Tarjeta de Debito");
            cbMpago.Items.Add("Tarjeta de Credito");
            cbMpago.Items.Add("Efectivo");
            cbMpago.Items.Add("Transferencia");
            cbMpago.SelectedIndex = 2;

        }

		
       
        private void calcula() {
            double restantes = 0;
            double total = Convert.ToDouble(lbCobrar.Text);
            double recibido = 0;
            if (txtRecibido.Text != "")
            {
                recibido = Convert.ToDouble(txtRecibido.Text);
            }
            

            restantes = total - recibido;
            lbResta.Text = string.Format("{0:#,0.00}", restantes);
        }
       
        private void btnCobrar_Click(object sender, EventArgs e)
        {
           if (txtRecibido.Text == "")
            {
                if (cbMpago.Text== "Transferencia")
                {
                    caja.pagado = Convert.ToDouble(0);
                    caja.metodo = cbMpago.Text;
                    caja.factura = Convert.ToBoolean(chkFactura.Checked);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ingrese cuando recibio");
                    txtRecibido.Focus();
                }
               
            }
            else
            {
                caja.pagado = Convert.ToDouble(txtRecibido.Text);
                caja.metodo = cbMpago.Text;
                caja.factura = Convert.ToBoolean(chkFactura.Checked);
                this.Close();

            }
           


           
             
            
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCobrar.PerformClick();
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            txtRecibido.Text = string.Format("{0:#,0.00}", txtRecibido.Text);
            calcula();
        }

        private void cbMpago_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.Configuration configuracion = new Models.Configuration();
            List<Models.Configuration> config = configuracion.getConfiguration();
            switch (cbMpago.Text)
            {
                case "Tarjeta de Debito":


                    double nuevo_total = deberia_ser + ((deberia_ser / 100) * config[0].Debito);
                    lbCobrar.Text = string.Format("{0:#,0.00}", nuevo_total);
                    calcula();
                    break;
                case "Tarjeta de Credito":

                    double nuevo_total2 = deberia_ser + ((deberia_ser / 100) * config[0].Credito);
                    lbCobrar.Text = string.Format("{0:#,0.00}", nuevo_total2);
                    calcula();
                    break;
                default:
                    lbCobrar.Text= string.Format("{0:#,0.00}", deberia_ser);
                    calcula();
                    break;

            }


        }

        private void txtRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCobrar.PerformClick();
            }
        }
    }
}
