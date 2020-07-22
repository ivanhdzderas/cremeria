using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;
namespace caja.Forms
{
    public partial class busca_unidadSAT : Form
    {
        public busca_unidadSAT()
        {
            InitializeComponent();
        }

        private void busca_unidadSAT_Load(object sender, EventArgs e)
        {
            carga();
        }
        private void carga() {
            dgUnidadSat.Rows.Clear();
            Unidad_Sat unidad_sat = new Unidad_Sat();
            using (unidad_sat)
            {
                List<Unidad_Sat> result = unidad_sat.getUnidadSat();
                foreach (Unidad_Sat item in result)
                {
                    dgUnidadSat.Rows.Add(item.Code, item.Description);
                }
            }
                
            
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dgUnidadSat.Rows.Clear();
                Unidad_Sat unidad_sat = new Unidad_Sat();
                using (unidad_sat)
                {
                    List<Unidad_Sat> result = unidad_sat.getUnidadSatByDescripton(txtSearch.Text);
                    foreach (Unidad_Sat item in result)
                    {
                        dgUnidadSat.Rows.Add(item.Code, item.Description);
                    }
                    dgUnidadSat.Focus();
                }
            }
        }

      

        private void dgUnidadSat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgUnidadSat.CurrentRow.Index;
                string valor = dgUnidadSat.Rows[i].Cells["clave"].Value.ToString();
                (this.Owner as producto).txtUnidadSat.Text = valor;
                this.Close();
            }
        }
    }
}
