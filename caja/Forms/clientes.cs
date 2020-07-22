using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;
namespace caja
{
    public partial class clientes : Form
    {
        public clientes()
        {
            InitializeComponent();
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            carga();
        }
        public void carga()
        {
            dtgClientes.Rows.Clear();

            Client client = new Client();
            using (client)
            {
                List<Client> result = client.getClients();
                foreach (Client item in result)
                {
                    dtgClientes.Rows.Add(item.Id, item.Name, item.RFC);
                }
            }
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            form_cliente.id = "0";
            form_cliente clie = new form_cliente();
            clie.Show(this);
        }

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dtgClientes.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dtgClientes.Rows[selectedrowindex];
            string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
            form_cliente.id = codigo;
            form_cliente clie = new form_cliente();
            clie.Show(this);

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
                    dtgClientes.Rows.Clear();
                    string bus_descripcion = txtBuscar.Text;
                    Client clien = new Client();
                    using (clien)
                    {
                        List<Client> result = clien.getClientbyName(bus_descripcion);
                        foreach (Client item in result)
                        {
                            dtgClientes.Rows.Add(item.Id, item.Name, item.RFC);
                        }
                    }
                }

            }
        }
    }
}
