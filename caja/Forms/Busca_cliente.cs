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
	public partial class Busca_cliente : Form
	{
		public Busca_cliente()
		{
			InitializeComponent();
		}

		private void Busca_cliente_Load(object sender, EventArgs e)
		{
			Clientes();
		}
		private void Clientes() {
			dtClientes.Rows.Clear();
			Client cliente = new Client();
			using (cliente)
			{
				List<Client> cli = cliente.getClients();
				if (cli.Count > 0)
				{
					foreach (Client item in cli)
					{
						dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
					}
				}

			}
			
		}

		private void dtClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtClientes.CurrentRow.Index;
				string valor = dtClientes.Rows[i].Cells["id"].Value.ToString();

				caja.id_cliente = Convert.ToInt16(valor);
				this.Close();
			}
		}

		private void txtRFC_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				dtClientes.Rows.Clear();
				Client clients = new Client();
				using (clients)
				{
					List<Client> result = clients.getClientbyRFC(txtRFC.Text);
					if (result.Count > 0)
					{
						foreach (Client item in result)
						{
							dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
						}
					}
				}
				
			}
		}

		private void txtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				dtClientes.Rows.Clear();
				Client clients = new Client();
				using (clients)
				{
					List<Client> result = clients.getClientbyName(txtNombre.Text);
					if (result.Count > 0)
					{
						foreach (Client item in result)
						{
							dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
						}
					}
					dtClientes.Focus();
				}
				
			}
		}

		private void dtClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtClientes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtClientes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			caja.id_cliente = Convert.ToInt16(codigo);
			
			this.Close();
		}
	}
}
