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
	public partial class Tickets_terminar : Form
	{
		public static int id_ticket;
		public Tickets_terminar()
		{
			InitializeComponent();
		}

		private void Tickets_terminar_Load(object sender, EventArgs e)
		{
			lbDatosCliente.Text = "";
			carga();
		}
		private void carga()
		{
			dtTickets.Rows.Clear();
			Models.Tickets tickets = new Models.Tickets();
			List<Models.Tickets> ticket = tickets.getTickets_porfacturar();

			Models.Client clientes = new Models.Client();

			if (ticket.Count > 0)
			{
				foreach (Models.Tickets item in ticket)
				{
					List<Models.Client> cliente = clientes.getClientbyId(item.Id_cliente);
					dtTickets.Rows.Add(item.Id, item.Fecha, cliente[0].Name, item.Total);
				}
			}
		}

		private void dtTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtTickets.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtTickets.Rows[selectedrowindex];
			int folio = Convert.ToInt16(selectedRow.Cells["folio"].Value);
			id_ticket = folio;
			Models.Tickets ticket = new Models.Tickets();
			List<Models.Tickets> tic = ticket.getTicketsbyId(folio);


			Models.Dettickets detallado_ticket = new Models.Dettickets();
			List<Models.Dettickets> detalle = detallado_ticket.getDetalles(folio);

			dtDetallado.Rows.Clear();
			Models.Product productos = new Models.Product();
			foreach (Models.Dettickets item in detalle)
			{
				List<Models.Product> producto = productos.getProductById(item.Id_producto);
				dtDetallado.Rows.Add(item.Cantidad, producto[0].Code1, producto[0].Description, item.Pu, item.Total);
			}

			Models.Client clientes = new Models.Client();
			List<Models.Client> cliente = clientes.getClientbyId(tic[0].Id_cliente);
			lbDatosCliente.Text = cliente[0].Name + ", RFC:" + cliente[0].RFC;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Tickets tickets = new Models.Tickets();
			tickets.A_facturar = Convert.ToInt16(false);
			tickets.termina();
			carga();
			dtDetallado.Rows.Clear();
			lbDatosCliente.Text = "";


		}
	}
}
