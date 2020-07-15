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
	public partial class clientes_detallado : Form
	{
		public clientes_detallado()
		{
			InitializeComponent();
		}

		private void clientes_detallado_Load(object sender, EventArgs e)
		{
			dtFechaFinal.Format = DateTimePickerFormat.Custom;
			dtFechaFinal.CustomFormat = "yyyy-MM-dd";
			dtFechaInicio.Format = DateTimePickerFormat.Custom;
			dtFechaInicio.CustomFormat = "yyyy-MM-dd";

			txtIdcliente.AutoCompleteCustomSource = carga_clientes1();
			txtIdcliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtIdcliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtCliente.AutoCompleteCustomSource = carga_clientes2();
			txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		private AutoCompleteStringCollection carga_productos1()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			List<Models.Product> result = producto.getProducts();
			foreach (Models.Product item in result)
			{
				datos.Add(item.Code1);
			}
			return datos;
		}
		private AutoCompleteStringCollection carga_clientes1()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			List<Models.Client> result = clientes.getClients();
			foreach (Models.Client item in result)
			{
				datos.Add(item.Id.ToString());
			}
			return datos;
		}

		private AutoCompleteStringCollection carga_clientes2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			List<Models.Client> result = clientes.getClients();
			foreach (Models.Client item in result)
			{
				datos.Add(item.Name);
			}
			return datos;
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				List<Models.Client> cliente = clientes.getClientbyName(txtCliente.Text);
				if (cliente.Count > 0)
				{
					txtIdcliente.Text = cliente[0].Id.ToString();
					dtFechaInicio.Focus();
				}
			}
		}

		private void txtIdcliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtIdcliente.Text));
				if (cliente.Count > 0)
				{
					txtCliente.Text = cliente[0].Name;
					dtFechaInicio.Focus();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtIdcliente.Text = "";
			txtCliente.Text = "";
			dtFechaInicio.Value = DateTime.Now;
			dtFechaFinal.Value = DateTime.Now;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if (txtIdcliente.Text != "")
			{
				double total = 0;
				Models.Detallado_ticket detalle = new Models.Detallado_ticket();
				List<Models.Detallado_ticket> det = detalle.get_detallado(dtFechaInicio.Text, dtFechaFinal.Text, Convert.ToInt16(txtIdcliente.Text));
				if (det.Count > 0)
				{
					foreach (Models.Detallado_ticket item in det)
					{
						dtDetallado.Rows.Add(item.Folio, item.Fecha, item.Cantidad, "[ " + item.Codigo + " ] " + item.Descripcion, item.Total);
						total += item.Total;
					}

				}
				lbTotal.Text = "Total: " + total;
			}
			
		}
	}
}
