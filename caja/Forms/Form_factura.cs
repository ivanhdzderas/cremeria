using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			cbTipo.Items.Add("Directa");
			cbTipo.Items.Add("Ticket");
			cbTipo.Items.Add("Traspasos");

			Folios folios = new Folios();
			List<Folios> folio = folios.getFolios();
			txtFolio.Text = folio[0].Facturas.ToString();

			txtUsoCfdi.AutoCompleteCustomSource = cargadatos();
			txtUsoCfdi.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtUsoCfdi.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtFpago.AutoCompleteCustomSource = cargadatos2();
			txtFpago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtFpago.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtMPago.AutoCompleteCustomSource = cargadatos3();
			txtMPago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtMPago.AutoCompleteSource = AutoCompleteSource.CustomSource;

		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Uso_Cfdi usos = new Uso_Cfdi();
			List<Uso_Cfdi> uso = usos.get_Usos() ;
			foreach (Uso_Cfdi item in uso)
			{
				datos.Add(item.Descripcion);
				datos.Add(item.Clave);
			}
			return datos;
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Forma_pago pagos = new Forma_pago();
			List<Forma_pago> pago = pagos.getFpagos();
			foreach (Forma_pago item in pago)
			{
				datos.Add(item.Descripcion);
				datos.Add(item.Formapago);
			}
			return datos;
		}
		private void Calcula()
		{
			double subtotal = 0;
			double iva = 0;
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				subtotal = subtotal + (Convert.ToDouble(row.Cells["cantidad"].Value)* Convert.ToDouble(row.Cells["pu"].Value));
			}
			iva = subtotal * 0.16;
			total = subtotal * 1.16;

			txtSubtotal.Text = subtotal.ToString();
			txtIVa.Text = iva.ToString();
			txtTotal.Text = total.ToString();
		}
		private AutoCompleteStringCollection cargadatos3()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Payment_Form pagos = new Payment_Form();
			List<Payment_Form> pago = pagos.get_method();
			foreach (Payment_Form item in pago)
			{
				datos.Add(item.Description);
				datos.Add(item.Method);
			}
			return datos;
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
						Calcula();
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
						Calcula();
						break;
					default:
						txtCliente.Focus();
						break; 
				}
			}
		}


		private async void button1_Click(object sender, EventArgs e)
		{
			Models.Facturas factura = new Models.Facturas();

			Models.Folios folios = new Models.Folios();
			List<Models.Folios> folio = folios.getFolios();


			factura.Folio = folio[0].Facturas;
			factura.Serie = folio[0].Serie;
			factura.Cliente = Convert.ToInt16(txtIdCliente.Text);
			factura.Subtotal = Convert.ToDouble(txtSubtotal.Text);
			factura.Total = Convert.ToDouble(txtTotal.Text);
			factura.Pago = txtFpago.Text;


			Models.Client clientes = new Models.Client();
			List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
			var facturapi = new FacturapiClient("sk_test_ZMndoLa1ODwz13GebqDgXp0WXx5kVRK8");
			// Después, procede a llamar a los métodos como muestra la documentación.
			
			Product productos = new Product();

			List<Models.Factura.items> producto_factura = new List<Models.Factura.items>();

			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				List<Product> producto = productos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
				producto_factura.Add(
					new Models.Factura.items
					{
						quantity = 1,
						product = new Models.Factura.Productos
						{
							description = producto[0].Description,
							product_key = producto[0].Code_sat,
							price = producto[0].Price1,
							tax_included = false,
							Taxes = new Models.Factura.Taxes_productos
							{
								rate = Convert.ToDecimal(0.16),
								withholding = false,
								type = "IVA"
							},
							unit_key = producto[0].Medida_sat,
							unit_name = producto[0].C_unidad
						},
					}
					);


			}

			try {
				var invoice = await facturapi.Invoice.CreateAsync(new Dictionary<string, object>
				{
					["customer"] = new Dictionary<string, object>
					{
						["legal_name"] = cliente[0].Name,
						["tax_id"] = cliente[0].RFC
					},
					["items"] = producto_factura,

					["use"] = txtUsoCfdi.Text,
					["payment_method"] = txtMPago.Text,
					["payment_form"] = txtFpago.Text,
					["folio_number"] = folio[0].Facturas,
					["series"] = folio[0].Serie
				});
				factura.Id_invoi = invoice.Id;
				factura.Uuid = invoice.Uuid;

				Configuration config = new Configuration();
				List<Configuration> configuracion = config.getConfiguration();

				var zipStream = await facturapi.Invoice.DownloadZipAsync(invoice.Id);
				string Directorio = configuracion[0].Ruta_factura+"/";
				string Archivo = Directorio + invoice.Id + ".zip";

				var file = new System.IO.FileStream(Archivo, FileMode.Create);
				zipStream.CopyTo(file);
				file.Close();
				//Descomprimir
				System.IO.Compression.ZipFile.ExtractToDirectory(Archivo, Directorio);
				string Archivo_xml = Directorio + invoice.Uuid + ".xml";
				string text = System.IO.File.ReadAllText(Archivo_xml);
				factura.Xml = text;

				XmlDocument CFDI = new XmlDocument();
				CFDI.Load(Archivo_xml);
				XmlNode nodo = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
				string valorAtributo = nodo.Attributes.GetNamedItem("Fecha").Value;
				XmlNode Complemento = CFDI.GetElementsByTagName("cfdi:Complemento").Item(0);
				XmlNode Timbre = CFDI.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
				string SelloSAT = Timbre.Attributes.GetNamedItem("SelloSAT").Value;

				factura.Sello = SelloSAT;
				factura.create();

				folios.saveFacturas();
			} 
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			
			
			
		}

		private void txtUsoCfdi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Uso_Cfdi usos = new Uso_Cfdi();
				List<Uso_Cfdi> uso = usos.get_Usosbydescripcion(txtUsoCfdi.Text);
				if (uso.Count > 0)
				{
					txtUsoCfdi.Text = uso[0].Clave;
				}
				
			}
		}

		private void txtFpago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Forma_pago pagos = new Forma_pago();
				List<Forma_pago> pago = pagos.getFpagosbydescripcion(txtFpago.Text);
				if (pago.Count > 0)
				{
					txtFpago.Text = pago[0].Formapago;
				}
				
			}
		}

		private void txtMPago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Payment_Form pagos = new Payment_Form();
				List<Payment_Form> pago = pagos.get_methodbyDescription(txtMPago.Text);
				if (pago.Count > 0)
				{
					txtMPago.Text = pago[0].Method;
				}
				
			}
		}
	}
}
