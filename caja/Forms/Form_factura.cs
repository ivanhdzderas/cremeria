using caja.Timbrado;
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
using System.Xml.Serialization;
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

			Models.Folios folios = new Models.Folios();
			using (folios)
			{
				List<Models.Folios> folio = folios.getFolios();
				txtFolio.Text = folio[0].Facturas.ToString();
			}
			

			txtUsoCfdi.AutoCompleteCustomSource = cargadatos();
			txtUsoCfdi.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtUsoCfdi.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtFpago.AutoCompleteCustomSource = cargadatos2();
			txtFpago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtFpago.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtMPago.AutoCompleteCustomSource = cargadatos3();
			txtMPago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtMPago.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtCliente.AutoCompleteCustomSource = carga_cliente();
			txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtIdCliente.AutoCompleteCustomSource = carga_cliente2();
			txtIdCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtIdCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
			using (usos)
			{
				List<Models.Uso_Cfdi> uso = usos.get_Usos();
				foreach (Models.Uso_Cfdi item in uso)
				{
					datos.Add(item.Descripcion);
					datos.Add(item.Clave);
				}
			}
			return datos;
		}
		private AutoCompleteStringCollection carga_cliente()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> clie = clientes.getClients();
				foreach (Models.Client item in clie)
				{
					datos.Add(item.Name);
				}
			}
			return datos;
		}

		private AutoCompleteStringCollection carga_cliente2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> clie = clientes.getClients();
				foreach (Models.Client item in clie)
				{
					datos.Add(item.Id.ToString());
				}
			}
			return datos;
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Forma_pago pagos = new Models.Forma_pago();
			using (pagos)
			{
				List<Models.Forma_pago> pago = pagos.getFpagos();
				foreach (Models.Forma_pago item in pago)
				{
					datos.Add(item.Descripcion);
					datos.Add(item.Formapago);
				}
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
			Models.Payment_Form pagos = new Models.Payment_Form();
			using (pagos)
			{
				List<Models.Payment_Form> pago = pagos.get_method();
				foreach (Models.Payment_Form item in pago)
				{
					datos.Add(item.Description);
					datos.Add(item.Method);
				}
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
							Models.Dettickets detalles = new Models.Dettickets();
							using (detalles)
							{
								List<Models.Dettickets> detalle = detalles.getDetalles(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
								foreach (Models.Dettickets item in detalle)
								{
									using (productos)
									{
										List<Product> producto = productos.getProductById(item.Id_producto);
										dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Pu, item.Total);
									}
								}
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
							Models.Det_transfers detalles = new Models.Det_transfers();
							using (detalles)
							{
								List<Models.Det_transfers> detalle = detalles.getDet_trans(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
								foreach (Models.Det_transfers item in detalle)
								{
									using (productos)
									{
										List<Product> producto = productos.getProductById(item.Id_producto);
										dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, (item.Precio * item.Cantidad));
									}
									
								}
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
			
			Models.Folios folios = new Models.Folios();
			List<Models.Folios> folio = folios.getFolios();

			Models.Facturas facturas = new Models.Facturas();
			facturas.Folio = Convert.ToInt16(txtFolio.Text);
			facturas.Serie = folio[0].Serie;
			facturas.Cliente = Convert.ToInt16(txtIdCliente.Text);
			facturas.Subtotal = Convert.ToDouble(txtSubtotal.Text);
			facturas.Total = Convert.ToDouble(txtTotal.Text);
			facturas.Pago = txtMPago.Text;
			facturas.create();

			Models.Det_facturas detalle_facturas = new Models.Det_facturas();
			detalle_facturas.Factura = Convert.ToInt16(txtFolio.Text);

			
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				detalle_facturas.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
				detalle_facturas.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				detalle_facturas.P_u=Convert.ToDouble(row.Cells["pu"].Value.ToString());
				detalle_facturas.create();
			}

			switch (cbTipo.SelectedItem.ToString())
			{
				case "Ticket":
					Models.Ticket_a_facturas tic_a_fact = new Models.Ticket_a_facturas();

					foreach (DataGridViewRow row in dtdocumentos.Rows)
					{
						tic_a_fact.Factura = Convert.ToInt16(txtFolio.Text);
						tic_a_fact.Ticket = Convert.ToInt16(row.Cells["folio"].Value.ToString());
						tic_a_fact.createrelacion();
					}
					break;
				case "Traspasos":
					Models.Traspasos_a_facturas tras_a_factura = new Models.Traspasos_a_facturas();
					foreach (DataGridViewRow row in dtdocumentos.Rows)
					{
						tras_a_factura.Traspaso= Convert.ToInt16(row.Cells["folio"].Value.ToString());
						tras_a_factura.Factura = Convert.ToInt16(txtFolio.Text);
						tras_a_factura.create_relacion();
					}
					break;
			}
			
			xml2();
		}


		private void timbrar()
		{
			Models.Configuration configuracion = new Models.Configuration();
			using (configuracion)
			{
				List<Models.Configuration> config = configuracion.getConfiguration();
				//Instancias del timbrado
				Timbrado.StampSOAP selloSOAP = new Timbrado.StampSOAP();
				stamp oStamp = new stamp();
				stampResponse selloResponse = new stampResponse();

				//Cargas tu archivo xml
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(config[0].Ruta_factura + txtFolio.Text + ".xml");

				//Conviertes el archivo en byte
				byte[] byteXmlDocument = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
				//Conviertes el byte resultado en base64
				string stringByteXmlDocument = Convert.ToBase64String(byteXmlDocument);
				//Convirtes el resultado nuevamente a byte
				byteXmlDocument = Convert.FromBase64String(stringByteXmlDocument);

				//Timbras el archivo
				oStamp.xml = byteXmlDocument;

				oStamp.username = "alrashidmtze@gmail.com";
				oStamp.password = "4lR4sh1d+";

				//Generamos request
				String usuario;
				usuario = Environment.UserName;
				String url = config[0].Ruta_factura;
				StreamWriter XML = new StreamWriter(url + "SOAP_Request.xml");     //Direccion donde guardaremos el SOAP Envelope
				XmlSerializer soap = new XmlSerializer(oStamp.GetType());    //Obtenemos los datos del objeto oStamp que contiene los parámetros de envió y es de tipo stamp()
				soap.Serialize(XML, oStamp);
				XML.Close();

				//Recibes la respuesta de timbrado
				selloResponse = selloSOAP.stamp(oStamp);

				try
				{
					MessageBox.Show("No se timbro el XML" + "\nCódigo de error: " + selloResponse.stampResult.Incidencias[0].CodigoError.ToString() + "\nMensaje: " + selloResponse.stampResult.Incidencias[0].MensajeIncidencia);
				}
				catch (Exception)
				{
					MessageBox.Show(selloResponse.stampResult.CodEstatus.ToString());
					MessageBox.Show(selloResponse.stampResult.Fecha.ToString());
					MessageBox.Show(selloResponse.stampResult.UUID.ToString());
					MessageBox.Show(selloResponse.stampResult.xml.ToString());
					StreamWriter XMLL = new StreamWriter(url + txtFolio.Text +".xml");
					XMLL.Write(selloResponse.stampResult.xml);
					XMLL.Close();
				}
			}
			
		}
		
		private void xml2()
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Client clientes = new Models.Client();
			Models.Product productos = new Models.Product();
			using (configuracion)
			{
				using (clientes)
				{
					using (productos)
					{
						List<Models.Configuration> config = configuracion.getConfiguration();
						CFDI3_VB.CFDx CFDs = new CFDI3_VB.CFDx();

						DateTime dt = DateTime.Now;
						DateTime x = Convert.ToDateTime(String.Format("{0:s}", dt));

						var _with1 = CFDs;

						_with1.Comprobante(Folio: txtFolio.Text, Fecha: x, SubTotal: txtSubtotal.Text, Moneda: "MXN", Total: txtTotal.Text, TipoDeComprobante: "I", LugarDeExpedicion: config[0].Cp.ToString(), Serie: "A", FormaPago: txtFpago.Text,
						CondicionesDePago: null, Descuento: "0.00", TipoCambio: "1", MetodoPago: txtMPago.Text, Confirmacion: null);



						_with1.AgregarEmisor(Rfc: config[0].RFC, RegimenFiscal: config[0].Regimen, Nombre: config[0].Nombre_comercial);
						List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
						_with1.AgregarReceptor(Rfc: cliente[0].RFC, UsoCFDI: txtUsoCfdi.Text, Nombre: txtCliente.Text, ResidenciaFiscal: null, NumRegIdTrib: null);

						List<Models.Product> producto = null;
						foreach (DataGridViewRow row in dtProductos.Rows)
						{
							producto = productos.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
							//detalle_facturas.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
							_with1.AgregarConcepto(ClaveProdServ: producto[0].Code_sat, Cantidad: row.Cells["cantidad"].Value.ToString(), ClaveUnidad: producto[0].Medida_sat, Descripcion: row.Cells["descripcion"].Value.ToString(), ValorUnitario: row.Cells["pu"].Value.ToString(), Importe: row.Cells["total"].Value.ToString(), Descuento: "0.00", Unidad: producto[0].Unit, NoIdentificacion: producto[0].Code1, InformacionAduanera: null,
							CuentaPredial: null, TrasladoImpuesto: CFDI3_VB.ComprobanteConceptoImpuestosTrasladoImpuesto.Item002, TrasladoBase: row.Cells["total"].Value.ToString(), TrasladoTipoFactor: "Tasa", TrasladoTasaOCuota: "0.00000", TrasladoImporte: "0.00", RetenidoImpuesto: CFDI3_VB.ComprobanteConceptoImpuestosRetencionImpuesto.Item002, RetenidoBase: "0.00", RetenidoTipoFactor: "Tasa", RetenidoTasaOCuota: "0.000000",
							RetenidoImporte: "0.00");
						}

						//CONCEPTO 1................................




						_with1.AgregarImpuesto(TrasladoImpuesto: CFDI3_VB.ComprobanteImpuestosTrasladoImpuesto.Item002, TrasladoTasa: "0.000000", TrasladoTipoFactor: "Tasa", TrasladoImporte: "0.00", RetenidoImpuesto: CFDI3_VB.ComprobanteImpuestosRetencionImpuesto.Item002, RetenidoImporte: "0.00");


						string username = "alrashidmtze@gmail.com";
						string password = "4lR4sh1d+";
						//string Path = (@"C:\Certificados");
						string CertFile = (config[0].Cer);
						string KeyFile = (config[0].Key);
						string KeyPass = config[0].Pass;
						//Dim Errores As String = ""
						string Errores = "";

						if (CFDs.CrearFacturaXML(username, password, KeyFile, KeyPass, CertFile, ref Errores, Ruta: config[0].Ruta_factura, nameXML: txtFolio.Text))
						{
							timbrar();
						}
						else
						{
							MessageBox.Show("Error al generar CFDI");
						}
					}
					

				}
				
			}
			
		}
		private void txtUsoCfdi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
				using (usos)
				{
					List<Models.Uso_Cfdi> uso = usos.get_Usosbydescripcion(txtUsoCfdi.Text);
					if (uso.Count > 0)
					{
						txtUsoCfdi.Text = uso[0].Clave;
					}
				}
					
				
			}
		}

		private void txtFpago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Forma_pago pagos = new Models.Forma_pago();
				using (pagos)
				{
					List<Models.Forma_pago> pago = pagos.getFpagosbydescripcion(txtFpago.Text);
					if (pago.Count > 0)
					{
						txtFpago.Text = pago[0].Formapago;
					}
				}
				
				
			}
		}

		private void txtMPago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Payment_Form pagos = new Models.Payment_Form();
				using (pagos)
				{
					List<Models.Payment_Form> pago = pagos.get_methodbyDescription(txtMPago.Text);
					if (pago.Count > 0)
					{
						txtMPago.Text = pago[0].Method;
					}
				}
				
				
			}
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCliente.Text != "")
				{
					Models.Client clientes = new Models.Client();
					using (clientes)
					{
						List<Models.Client> cliente = clientes.getClientbyName(txtCliente.Text);
						if (cliente.Count > 0)
						{
							txtIdCliente.Text = cliente[0].Id.ToString();
						}
					}
				}
			}
		}

		private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> client = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
					if (client.Count > 0)
					{
						txtCliente.Text = client[0].Name;

					}
				}
			}
		}
	}
}
