using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;
namespace caja.Forms
{
    public partial class Proveedores : Form
	{
		public Proveedores()
		{
			InitializeComponent();
		}
        public void carga() {

            Providers prov = new Providers();
            List<Providers> result = prov.getProviders();

            foreach (Providers item in result)
            {
                dtgProveedores.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
            }
        }
		private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBuscar.Text == "")
                {
                    carga();

                }
                else
                {
                    dtgProveedores.Rows.Clear();
                    string bus_descripcion = txtBuscar.Text;


                    Providers prov = new Providers();
                    List<Providers> result = prov.getProviderbyNombre(bus_descripcion);

                    foreach (Providers item in result)
                    {
                        dtgProveedores.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
                    }

                }

            }
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            carga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_proveedor.id = "0";
            form_proveedor prov = new form_proveedor();
            prov.Show(this);
        }

        private void dtgProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dtgProveedores.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dtgProveedores.Rows[selectedrowindex];
            string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
            form_proveedor.id = codigo;
            form_proveedor prov = new form_proveedor();
            prov.Show(this);
        }
    }
}
