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
			List<Models.Folios> folio = folios.getFolios();
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
			Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
			List<Models.Uso_Cfdi> uso = usos.get_Usos() ;
			foreach (Models.Uso_Cfdi item in uso)
			{
				datos.Add(item.Descripcion);
				datos.Add(item.Clave);
			}
			return datos;
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Forma_pago pagos = new Models.Forma_pago();
			List<Models.Forma_pago> pago = pagos.getFpagos();
			foreach (Models.Forma_pago item in pago)
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
			Models.Payment_Form pagos = new Models.Payment_Form();
			List<Models.Payment_Form> pago = pagos.get_method();
			foreach (Models.Payment_Form item in pago)
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
							Models.Dettickets detalles = new Models.Dettickets();
							List<Models.Dettickets> detalle = detalles.getDetalles(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
							foreach(Models.Dettickets item in detalle)
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
							Models.Det_transfers detalles = new Models.Det_transfers();
							List<Models.Det_transfers> detalle = detalles.getDet_trans(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
							foreach (Models.Det_transfers item in detalle)
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
			/*
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
			foreach (DataGridViewRow row in dtdocumentos.Rows)
			{
				detalle_facturas.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
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
			*/
			crear_xml();
			timbrar();
		}
		private void timbrar()
		{
			

		}
		private void crear_xml()
		{

			//creacion de xml sin firmar
			CFDI3_VB.CFDx CFDs = new CFDI3_VB.CFDx();
			DateTime dt = DateTime.Now;
			DateTime x = Convert.ToDateTime(String.Format("{0:s}", dt));
			var _with1 = CFDs;

			_with1.Comprobante(Folio: "649", Fecha: x, SubTotal: "22500.00", Moneda: "MXN", Total: "0.00", TipoDeComprobante: "I", LugarDeExpedicion: "67800", Serie: "A", FormaPago: "01",
			CondicionesDePago: "3 MESES", Descuento: "22500.00", TipoCambio: "1", MetodoPago: "PUE", Confirmacion: null);

			//_with1.AgregarCFDIRelacionados(TipoRelacion: "01");

			//_with1.AgregarCFDIRelacionado(UUID: "A39DA66B-52CA-49E3-879B-5C05185B0EF7");

			_with1.AgregarEmisor(Rfc: "EKU9003173C9", RegimenFiscal: "601", Nombre: "ISABEL MARQUEZ");

			_with1.AgregarReceptor(Rfc: "EKU9003173C9", UsoCFDI: "G01", Nombre: "RAUL SALDIVAR", ResidenciaFiscal: null, NumRegIdTrib: null);


			//CONCEPTO 1................................
			_with1.AgregarConcepto(ClaveProdServ: "10101500", Cantidad: "1.5", ClaveUnidad: "F52", Descripcion: "ACERO", ValorUnitario: "15000.00", Importe: "22500.00", Descuento: "22500.00", Unidad: "TONELADA", NoIdentificacion: "00001", InformacionAduanera: null,
			CuentaPredial: "51888", TrasladoImpuesto: CFDI3_VB.ComprobanteConceptoImpuestosTrasladoImpuesto.Item002, TrasladoBase: "22500.00", TrasladoTipoFactor: "Tasa", TrasladoTasaOCuota: "0.160000", TrasladoImporte: "3599.99", RetenidoImpuesto: CFDI3_VB.ComprobanteConceptoImpuestosRetencionImpuesto.Item002, RetenidoBase: "22500.00", RetenidoTipoFactor: "Tasa", RetenidoTasaOCuota: "0.160000",
			RetenidoImporte: "3599.99");



			_with1.AgregarImpuesto(TrasladoImpuesto: CFDI3_VB.ComprobanteImpuestosTrasladoImpuesto.Item002, TrasladoTasa: "0.160000", TrasladoTipoFactor: "Tasa", TrasladoImporte: "3599.99", RetenidoImpuesto: CFDI3_VB.ComprobanteImpuestosRetencionImpuesto.Item002, RetenidoImporte: "3599.99");

			//Referencia del webservice -- esta linea puede variar de acuerdo a tu proyecto
			

			string username = "alrashidmtz";
			string password = "586e34f0af947555b208aa8be3f2365abfbb414588c62eb0a60aadf5a16a";
			string Path = (@"C:\Certificados");
			string rutaGuardar = @"C:\Certificados";
			string CertFile = (Path + @"\EKU9003173C9.cer");
			string KeyFile = (Path + @"\EKU9003173C9.key");
			string KeyPass = "12345678a";
			//Dim Errores As String = ""
			string Errores = "";
			CFDs.CrearFacturaXML(username, password, KeyFile, KeyPass, CertFile, ref Errores, Ruta: rutaGuardar, nameXML: txtFolio.Text);
			
			//fin de creacion
		}
		private void txtUsoCfdi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
				List<Models.Uso_Cfdi> uso = usos.get_Usosbydescripcion(txtUsoCfdi.Text);
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
				Models.Forma_pago pagos = new Models.Forma_pago();
				List<Models.Forma_pago> pago = pagos.getFpagosbydescripcion(txtFpago.Text);
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
				Models.Payment_Form pagos = new Models.Payment_Form();
				List<Models.Payment_Form> pago = pagos.get_methodbyDescription(txtMPago.Text);
				if (pago.Count > 0)
				{
					txtMPago.Text = pago[0].Method;
				}
				
			}
		}
	}
}
