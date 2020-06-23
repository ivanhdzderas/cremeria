using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caja.Models;
using Facturapi;
using Product = caja.Models.Product;

namespace caja.Forms
{
	public partial class Form_factura : Form
	{
		public Form_factura()
		{
			InitializeComponent();
		}

		private void Form_factura_Load(object sender, EventArgs e)
		{
			cbTipo.Items.Add("Directa");
			cbTipo.Items.Add("Ticket");
			cbTipo.Items.Add("Traspasos");

			Folios folios = new Folios();
			List<Folios> folio = folios.getFolios();
			txtFolio.Text = folio[0].Facturas.ToString();

		}

		private void cbTipo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)13)
			{

				Product productos = new Product();
				switch (cbTipo.SelectedItem.ToString())
				{
					case "Ticket":
						Ticket_a_factura tic_a_fact = new Ticket_a_factura();
						tic_a_fact.Owner=this;
						tic_a_fact.ShowDialog();


						
						foreach (DataGridViewRow row in dtdocumentos.Rows)
						{
							Dettickets detalles = new Dettickets();
							List<Dettickets> detalle = detalles.getDetalles(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
							foreach(Dettickets item in detalle)
							{
								List<Product> producto = productos.getProductById(item.Id_producto);
								dtProductos.Rows.Add(item.Id_producto, item.Cantidad,producto[0].Code1, producto[0].Description,item.Pu, item.Total);
							}
						}
							break;
					case "Traspasos":
						Traspasos_a_facturas traspasos = new Traspasos_a_facturas();
						traspasos.Owner = this;
						traspasos.ShowDialog();


						foreach (DataGridViewRow row in dtdocumentos.Rows)
						{
							Det_transfers detalles = new Det_transfers();
							List<Det_transfers> detalle = detalles.getDet_trans(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
							foreach (Det_transfers item in detalle)
							{
								List<Product> producto = productos.getProductById(item.Id_producto);
								dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, (item.Precio*item.Cantidad));
							}
						}
						break;
					default:
						txtCliente.Focus();
						break; 
				}
			}
		}

		private async Task button1_ClickAsync(object sender, EventArgs e)
		{






			

			

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var facturapi = new FacturapiClient("sk_test_ZMndoLa1ODwz13GebqDgXp0WXx5kVRK8");
			// Después, procede a llamar a los métodos como muestra la documentación.
			var invoice = await facturapi.Invoice.CreateAsync(new Dictionary<string, object>
			{
				["customer"] = "58e93bd8e86eb318b0197456",
				["items"] = new Dictionary<string, object>[]
				{
				new Dictionary<string, object>
				{
					["product"] = new Dictionary<string, object>
					{
					["description"] = "Ukelele",
					["product_key"] = "60131324",
					["price"] = 345.60
					}
				}
				},
				["payment_form"] = Facturapi.PaymentForm.DINERO_ELECTRONICO,
				["folio_number"] = 914,
				["series"] = "A"
			});

			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			string fileName = invoice.Id + ".zip", myStringWebResource = null;

			// Concatenate the domain with the Web resource filename.
			myStringWebResource = "https://www.facturapi.io/v1/invoices/" + invoice.Id + "/zip";
			Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
			// Download the Web resource and save it into the current filesystem folder.
			myWebClient.DownloadFile(myStringWebResource, fileName);

		}
	}
}
