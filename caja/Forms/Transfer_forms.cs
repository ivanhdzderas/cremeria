using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using caja.Models;

namespace caja.Forms
{
	public partial class Transfer_forms : Form
	{
		public static int id_transfer;
		static int id_producto;
		public Transfer_forms()
		{
			InitializeComponent();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

			Product producto = new Product();
			using (producto)
			{
				List<Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
				foreach (Product item in result)
				{
					datos.Add(item.Code1);
				}
			}
			


			return datos;
		}
		private void Transfer_forms_Load(object sender, EventArgs e)
		{
			this.txtFolios.AutoSize = true;
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			//lbFecha.Visible = false;
			DataTable table = new DataTable();
			DataRow row;

			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);

			Offices oficinas = new Offices();
			using (oficinas)
			{
				List<Offices> oficina = oficinas.GetOffices();
				foreach (Offices ofi in oficina)
				{
					row = table.NewRow();
					row["Text"] = ofi.Name;
					row["Value"] = ofi.Id;
					table.Rows.Add(row);
				}
			}
			
			cbOficinas.BindingContext = new BindingContext();
			cbOficinas.DataSource = table;
			cbOficinas.DisplayMember = "Text";
			cbOficinas.ValueMember = "Value";
			cbOficinas.BindingContext = new BindingContext();
			
			if (id_transfer != 0)
			{
				Transfers transferencias = new Transfers();
				using (transferencias)
				{
					List<Transfers> lista = transferencias.getTransferbyid(id_transfer);

					Det_transfers detalles = new Det_transfers();
					Product productos = new Product();
					if (lista.Count > 0)
					{
						txtFolios.Text = lista[0].Folio.ToString();
						lbFecha.Text = "Fecha: " + lista[0].Fecha.ToString();
						cbOficinas.SelectedValue = lista[0].Sucursal;
						using (detalles)
						{
							List<Det_transfers> detallado = detalles.getDet_trans(id_transfer);
							if (detallado.Count > 0)
							{
								foreach (Det_transfers item in detallado)
								{
									using (productos)
									{
										List<Product> producto = productos.getProductById(item.Id_producto);
										double importe = item.Precio * item.Cantidad;
										dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, importe);
									}
									
								}
								calcula();
								nuCantidad.Enabled = false;
								txtCodigo.Enabled = false;
								txtDescripcion.Enabled = false;
								txtPrecio.Enabled = false;
							}
						}
						
					}
				}
				
			}
			else
			{
				Folios folio = new Folios();
				using (folio)
				{
					List<Folios> transfer = folio.getFolios();
					txtFolios.Text = transfer[0].Transferencia.ToString();

				}
				
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Product productos = new Product();
				using (productos)
				{
					List<Product> producto = productos.getProductBycode1(txtCodigo.Text);
					if (producto.Count > 0)
					{
						id_producto = producto[0].Id;
						txtDescripcion.Text = producto[0].Description;
						txtPrecio.Text = producto[0].Cost.ToString();
						txtPrecio.Focus();
					}
				}
				
			}
		}

		private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter )
			{
				if (txtCodigo.Text.Trim() != "" && txtDescripcion.Text.Trim()!="" && txtPrecio.Text.Trim()!="0" ) {
					double importe = Convert.ToDouble(nuCantidad.Value) * Convert.ToDouble(txtPrecio.Text);
					dtProductos.Rows.Add(id_producto,nuCantidad.Value,txtCodigo.Text,txtDescripcion.Text, txtPrecio.Text, importe);
					id_producto = 0;
					nuCantidad.Focus();
					calcula();
					nuCantidad.Value = 0;
					txtCodigo.Text = "";
					txtDescripcion.Text = "";
					txtPrecio.Text = "";
				}
			}
		}
		public void calcula()
		{
			double subtotal = 0;
			double total = 0;
			double iva = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				subtotal += Convert.ToDouble(row.Cells["Importe"].Value);
			}
			total = subtotal * 1.16;
			iva = subtotal * 0.16;
			txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void nuCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (nuCantidad.Value > 0)
			{
				txtCodigo.Focus();
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Transfers transferencia = new Transfers();
			using (transferencia)
			{
				transferencia.Folio = Convert.ToInt16(txtFolios.Text);
				transferencia.Tipo_trapaso = "E";
				transferencia.Sucursal = cbOficinas.SelectedValue.ToString();
				transferencia.Subtotal = Convert.ToDouble(txtSubtotal.Text);
				transferencia.Iva =0;
				transferencia.Total = 0;
				transferencia.Facturado = Convert.ToInt16(false);
				transferencia.CreateTransfer();
				List<Transfers> ultimo = transferencia.getTransferbyfolio(Convert.ToInt16(txtFolios.Text), "E");

				Det_transfers detalles = new Det_transfers();
				using (detalles)
				{
					detalles.Folio = Convert.ToInt16(txtFolios.Text);
					detalles.Tipo = "E";

					Product poductos = new Product();
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
						detalles.Precio = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
						detalles.CreateDet();
						using (poductos)
						{
							List<Product> producto = poductos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
							Kardex kardex = new Kardex();
							using (kardex)
							{
								kardex.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
								kardex.Tipo = "T";
								kardex.Id_documento = ultimo[0].Id;
								kardex.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								kardex.Antes = producto[0].Existencia;
								kardex.CreateKardex();
								
								List<Kardex> ultimo_kardez = kardex.getidKardex(Convert.ToInt16(row.Cells["id"].Value.ToString()), ultimo[0].Id, "T");
								Afecta_inv afecta = new Afecta_inv();
								using (afecta)
								{
									
									afecta.Disminuye(ultimo_kardez[0].Id);
								}

								
							}
							
						}
						

					}
				}
				
			}
			

			//crea_xml();
	
			


			Folios folio = new Folios();
			using (folio)
			{
				folio.Transferencia = (Convert.ToInt16(txtFolios.Text) + 1);
				folio.savenewTransfer();
			}

			PrinterSettings ps = new PrinterSettings();
			printDocument1.PrintController = new StandardPrintController();
			printDocument1.PrinterSettings = ps;
			Configuration configuracion = new Configuration();
			using (configuracion)
			{
				List<Configuration> config = configuracion.getConfiguration();
				printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
				printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
				printDocument1.Print();

			}
			this.Close();



		}
		private void crea_xml()
		{
			string ruta = "";
			Configuration configuracion = new Configuration();
			using (configuracion)
			{
				List<Configuration> config = configuracion.getConfiguration();
				ruta = config[0].Ruta_factura;
			}
				Transfers transferencia = new Transfers();
			using (transferencia)
			{
				List<Transfers> lista = transferencia.getTransferbyfolio(Convert.ToInt16(txtFolios.Text), "E");

				XmlTextWriter writer;
				writer = new XmlTextWriter(ruta+"transferencia-" + txtFolios.Text + ".xml", Encoding.UTF8);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument();
				writer.WriteStartElement("transferencia");
				//nodo de folio
				writer.WriteElementString("Folio", lista[0].Folio.ToString());
				//nodo de fecha
				writer.WriteElementString("Fecha", lista[0].Fecha.ToString());
				//nodo de Emisor
				Configuration configu = new Configuration();
				using (configu)
				{
					List<Configuration> config = configu.getConfiguration();
					writer.WriteElementString("Emisor", config[0].RFC);
				}
				
				//nodo Receptor
				Offices oficinas = new Offices();
				using (oficinas)
				{
					List<Offices> oficina = oficinas.GetOfficesbyid(Convert.ToInt16(lista[0].Sucursal));
					writer.WriteElementString("Receptor", oficina[0].Rfc);
				}
				
				
				//nodo monto
				writer.WriteElementString("Monto", lista[0].Total.ToString());
				//nodo de productos
				writer.WriteStartElement("Productos");

				// produtos uno a uno
				Det_transfers detalles = new Det_transfers();
				Product productos = new Product();
				using (detalles)
				{
					List<Det_transfers> lista_detalles = detalles.getDet_trans(Convert.ToInt16(lista[0].Folio));
					foreach (Det_transfers item in lista_detalles)
					{
						;
						using (productos)
						{
							List<Product> producto = productos.getProductById(Convert.ToInt16(item.Id));
							writer.WriteStartElement("Producto");
							writer.WriteElementString("Cantidad", Convert.ToDouble(item.Cantidad).ToString());
							writer.WriteElementString("Codigo1", producto[0].Code1);
							writer.WriteElementString("Codigo2", producto[0].Code2);
							writer.WriteElementString("Codigo3", producto[0].Code3);
							writer.WriteElementString("Codigo4", producto[0].Code4);
							writer.WriteElementString("Codigo5", producto[0].Code5);
							writer.WriteElementString("Descripcion", producto[0].Description);
							writer.WriteElementString("Pu", Convert.ToDouble(item.Precio).ToString());
							writer.WriteEndElement();
						}
						

					}
				}
				
				//fin nodo productos
				writer.WriteEndElement();
				//fin 
				writer.WriteEndElement();
				writer.WriteEndDocument();
				writer.Flush();
				writer.Close();
			}
			
			


		}
		private string formato(string numero)
		{
			double valor = 0;
			string resultado = "";
			valor = Convert.ToDouble(numero);
			resultado = valor.ToString("0.00");
			return resultado;
		}
		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Configuration configuracion = new Configuration();
			using (configuracion)
			{
				List<Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };


				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].RFC, font, Brushes.Black, 125, y, format);
				y = y + 10;
				string calle = config[0].Calle + " " + config[0].No_ext;
				if (config[0].No_int != "")
				{
					calle += "-" + config[0].No_int;
				}
				e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Municipio + " " + config[0].Estado, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString("Telefono" + config[0].Telefono, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				format = new StringFormat() { Alignment = StringAlignment.Far };
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				
				y = y + 15;
				e.Graphics.DrawString("Transferencia: " + txtFolios.Text, font, Brushes.Black, 0, y);
				/* y = y + 10;
                e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
                */
				y = y + 20;
				e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
				e.Graphics.DrawString("P/U.", font, Brushes.Black, 100, y, format);
				
				e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					y = y + 30;
					e.Graphics.DrawString(row.Cells["descripcion"].Value.ToString(), font, Brushes.Black, 10, y);
					e.Graphics.DrawString(row.Cells["cantidad"].Value.ToString(), font, Brushes.Black, 50, y + 10, format);
					e.Graphics.DrawString(formato(row.Cells["p_u"].Value.ToString()), font, Brushes.Black, 100, y + 10, format);

					e.Graphics.DrawString(formato(row.Cells["Importe"].Value.ToString()), font, Brushes.Black, 220, y + 10, format);
				}
				y = y + 15;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				y = y + 15;
				
				e.Graphics.DrawString("Total", font, Brushes.Black, 150, y + 10, format);
				e.Graphics.DrawString(txtSubtotal.Text, font, Brushes.Black, 220, y + 10, format);
				
				y = y + 40;
				intercambios inter = new intercambios();
				e.Graphics.DrawString(inter.enletras(txtSubtotal.Text), font, Brushes.Black, 0, y);
				
				y = y + 30;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
			}
		}
	}
}
