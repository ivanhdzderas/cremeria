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
	}
}
