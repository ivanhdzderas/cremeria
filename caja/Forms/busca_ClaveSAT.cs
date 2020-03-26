using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;
namespace caja.Forms
{
    public partial class busca_ClaveSAT : Form
    {
        public busca_ClaveSAT()
        {
            InitializeComponent();
        }

        private void busca_ClaveSAT_Load(object sender, EventArgs e)
        {
            carga();
        }
        private void carga(){
            dgClaveSat.Rows.Clear();
            SAT_prod sat_prod = new SAT_prod();
            List<SAT_prod> result = sat_prod.getSat_prod();
            foreach (SAT_prod item in result) {
                dgClaveSat.Rows.Add(item.Code, item.Description);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dgClaveSat.Rows.Clear();
                SAT_prod sat_prod = new SAT_prod();
                List<SAT_prod> result = sat_prod.getSat_prodbyDescription(txtSearch.Text);
                foreach (SAT_prod item in result)
                {
                    dgClaveSat.Rows.Add(item.Code, item.Description);
                }
                dgClaveSat.Focus();
            }
        }

        private void dgClaveSat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgClaveSat.CurrentRow.Index;
                string valor = dgClaveSat.Rows[i].Cells["clave"].Value.ToString();
                (this.Owner as producto).txtSAT.Text = valor;
                this.Close();
            }
        }
    }
}
