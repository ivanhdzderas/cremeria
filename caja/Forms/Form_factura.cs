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
				

				switch (cbTipo.SelectedItem.ToString())
				{
					case "Ticket":
						Ticket_a_factura tic_a_fact = new Ticket_a_factura();
						tic_a_fact.Owner=this;
						tic_a_fact.ShowDialog();


						Product productos = new Product();
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

						break;
					default:
						txtCliente.Focus();
						break; 
				}
			}
		}
	}
}
