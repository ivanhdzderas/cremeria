using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using caja.Models;
using Microsoft.VisualBasic;

namespace caja.Forms
{
	public partial class Form_compras : Form
	{
		public static string Entrada;
		public static string folio;
		public static string id;
		public Form_compras()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				Product producto = new Product();
				using (producto)
				{
					List<Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
					foreach (Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.F2)
			{
				busca_producto busca = new busca_producto();
				busca.ShowDialog();
				Product producto = new Product();
				using (producto)
				{
					List<Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}
		public void calcula()
		{
			double totales = 0;
			double cuantos = 0;
			double importe = 0;
			double excento = 0;
			double once = 0;
			double diezyseis = 0;
			double cero = 0;
			double grabado = 0;
			double sin_grabar = 0;


			//double descuento = Convert.ToDouble(txtTdescuento.Text);

			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				cuantos = cuantos + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				totales = totales + Convert.ToDouble(row.Cells["total"].Value.ToString());
				importe = Convert.ToDouble(row.Cells["total"].Value.ToString());
				switch (row.Cells["impuesto"].Value.ToString())
				{
					case "EXENTO IMPUESTOS":

						break;
					case "11":
						once = once + ((importe) * 0.11);
						break;
					case "16":
						diezyseis = diezyseis + ((importe) * 0.16);
						break;
					case "TASA CERO":

						break;
				}


				if (row.Cells["impuesto"].Value.ToString() == "16" || row.Cells["impuesto"].Value.ToString() == "11")
				{
					grabado = grabado + Convert.ToDouble(row.Cells["total"].Value.ToString());
				}
				else
				{
					sin_grabar = sin_grabar + Convert.ToDouble(row.Cells["total"].Value.ToString());
				}
			


			}
			double descuento = (importe / 100) * Convert.ToDouble(txtdescuento.Text);
			double productos = cuantos;
			double subtotal = totales;

			double iva = excento + once + diezyseis + cero;
			double total = (subtotal + iva) - descuento;



			txtiva.Text = string.Format("{0:#,0.00}", grabado);
			txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);


			txttotal.Text = string.Format("{0:#,0.00}", total);
		}
		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Product producto = new Product();
				using (producto)
				{
					List<Product> result = producto.getProductByDescription(txtDescripcion.Text);
					foreach (Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.F2)
			{
				busca_producto busca = new busca_producto();
				busca.ShowDialog();
				Product producto = new Product();
				using (producto)
				{
					List<Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void txtiva_TextChanged(object sender, EventArgs e)
		{

		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["p_u"].Value);
			double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["cantidad"].Value);
			dtProductos.Rows[e.RowIndex].Cells["total"].Value = (p_u * cantidad).ToString();
			calcula();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string Lote = "";
			string Cadu = "";
			Boolean pasa = false;
			Product producto = new Product();
			using (producto)
			{
				List<Product> item = producto.getProductById(Convert.ToInt16(id));
				if (Convert.ToBoolean(item[0].Lote) == true)
				{

					while (pasa == false)
					{
						Caducidad caduci = new Caducidad();
						caduci.ShowDialog();
						Lote = intercambios.Lote;
						Cadu = intercambios.Caducidad;
						if (!string.IsNullOrEmpty(Lote) || !string.IsNullOrEmpty(Cadu))
						{
							pasa = true;
						}
					}

				}
			}
			

			double total1 = (Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtpu.Text));

			using (producto)
			{
				List<Product> item = producto.getProductById(Convert.ToInt16(id));

				dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtpu.Text, total1.ToString(), Lote, Cadu, item[0].Buy_tax);

			}
			
			id = "";
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtpu.Text = "";
			calcula();
			txtCantidad.Focus();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Product producto = new Product();
			using (producto)
			{
				List<Product> result = producto.getProducts();
				foreach (Product item in result)
				{
					datos.Add(item.Code1);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Product producto = new Product();
			using (producto)
			{
				List<Product> result = producto.getProducts();
				foreach (Product item in result)
				{
					datos.Add(item.Description);
				}
				return datos;
			}
		}
		private void Form_compras_Load(object sender, EventArgs e)
		{
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtDescripcion.AutoCompleteCustomSource = cargadatos2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			dtFechaDoc.Format = DateTimePickerFormat.Custom;
			dtFechaDoc.CustomFormat = "yyyy-MM-dd";
			dtVencimiento.Format = DateTimePickerFormat.Custom;
			dtVencimiento.CustomFormat = "yyyy-MM-dd";
			txtdescuento.Text = "0";
			carga_proveedor();
			if (folio != "0") {
				Models.Compras compra = new Models.Compras();
				using (compra)
				{
					List<Models.Compras> resultado = compra.getCompraByid(Convert.ToInt16(folio));
					foreach (Models.Compras item in resultado)
					{
						cbProveedor.SelectedText = item.Proveedor;
						txtFolio.Text = item.Folio_doc;
						dtFecha.Text = item.Fecha;
						dtFechaDoc.Text = item.Fecha_doc;
						txttotal.Text = item.Total.ToString();
						txtiva.Text = item.Iva.ToString();
						txtdescuento.Text = item.Descuento.ToString();
						txtSubtotal.Text = item.Subtotal.ToString();
						if (item.Pagado == "SI")
						{
							chkContado.Checked = true;
						}
						else
						{
							chkContado.Checked = false;
						}

						if (chkContado.Checked == false)
						{
							txtdias.Text = item.Dias.ToString();
							dtVencimiento.Text = item.Fecha_credito;
						}
					}
				}
				Product producto = new Product();
				Purchases detalle = new Purchases();
				Caducidades caducidades = new Caducidades();
				string master = "0";
				int id_prod = 0;
				using (detalle)
				{
					List<Purchases> resu = detalle.getPurchases(Convert.ToInt16(folio));
					foreach (Purchases va in resu)
					{
						using (producto)
						{
							List<Product> prod = producto.getProductById(va.Id_producto);
							master = prod[0].Parent;
							id_prod = prod[0].Id;
							while (master != "0")
							{
								List<Product> encontrado = producto.getProductById(Convert.ToInt16(master));
								master = encontrado[0].Parent;
								id_prod = encontrado[0].Id;
							}
							using (caducidades)
							{
								List<Caducidades> cadu = caducidades.GetCaducidadesbyCompra(Convert.ToInt16(folio), id_prod);
								dtProductos.Rows.Add(va.Id_producto, va.Cantidad, prod[0].Code1, prod[0].Description, va.P_u, va.Total, cadu[0].Lote, cadu[0].Caducidad);

							}

						}


					}
				}
					
				
				
				txtFolio.Enabled = false;
				button1.Enabled = false;
				toolStripButton2.Enabled = false;
				toolStripButton1.Enabled = false;
				button4.Enabled = false;
				button2.Enabled = false;
				txtCodigo.Enabled = false;
				txtDescripcion.Enabled = false;
				txtdescuento.Enabled = false;
				txtCantidad.Enabled = false;
				txtpu.Enabled = false;
				chkContado.Enabled = false;
				txtNumero.Enabled = false;
				cbProveedor.Enabled = false;
				dtFechaDoc.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
				txtdescuento.Enabled = false;
			}
		}
		public void carga_proveedor() {
			cbProveedor.DataSource = null;
			cbProveedor.Items.Clear();
			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);
			Providers prov = new Providers();
			using (prov)
			{
				List<Providers> data = prov.getProviders();

				foreach (Providers item in data)
				{
					row = table.NewRow();
					row["Text"] = item.Name;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}
				
			
			
			cbProveedor.BindingContext = new BindingContext();
			cbProveedor.DataSource = table;
			cbProveedor.DisplayMember = "Text";
			cbProveedor.ValueMember = "Value";
			cbProveedor.BindingContext = new BindingContext();
		}
		private void txtdescuento_Leave(object sender, EventArgs e)
		{
			if (txtdescuento.Text == "") {
				txtdescuento.Text = "0";
			}
			calcula();
		}

		private void txtpu_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int dias = 0;
			string fecha_credito = "0000-00-00 00:00:00";
			string pagado = "SI";
			if (chkContado.Checked != true) {
				dias = Convert.ToInt16(txtdias.Text);
				fecha_credito = dtVencimiento.Text + " 00:00:00";
				pagado = "NO";
			}
			Models.Compras compra = new Models.Compras(
				0,
				txtFolio.Text,
				dtFecha.Text + " 00:00:00",
				dtFechaDoc.Text + " 00:00:00",
				txtNumero.Text,
				"A",
				dias,
				fecha_credito,
				pagado,
				Convert.ToDouble(txtSubtotal.Text),
				Convert.ToDouble(txtiva.Text),
				Convert.ToDouble(txttotal.Text),
				Convert.ToDouble(txtdescuento.Text)
				);
			using (compra)
			{
				compra.crateCompra();
				List<Models.Compras> resultado = compra.GetlastCompras(dtFecha.Text + " 00:00:00", dtFechaDoc.Text + " 00:00:00", txtNumero.Text, Convert.ToDouble(txttotal.Text));
				Purchases detalles = new Purchases();
				detalles.Id = 0;
				detalles.Id_compra = resultado[0].Id;
				Kardex kardex = new Kardex();
				Product producto = new Product();
				Afecta_inv afecta = new Afecta_inv();
				Caducidades Caducida = new Caducidades();
				Caducida.Id = 0;
				Caducida.Id_compra = resultado[0].Id;
				double nuevo = 0;
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					using (producto)
					{
						List<Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));

						nuevo = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
						while (prod[0].Parent != "0")
						{
							nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
							prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));
						}


						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						detalles.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
						detalles.P_u = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
						detalles.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
						using (detalles)
						{
							detalles.createPurchases();
							Caducida.Id_producto = prod[0].Id;
							Caducida.Caducidad = row.Cells["caducidad"].Value.ToString();
							Caducida.Lote = row.Cells["lote"].Value.ToString();
							Caducida.Cantidad = nuevo;
							using (caducidad)
							{
								Caducida.createCaducidad();
								
							}
							kardex.Fecha = Convert.ToDateTime(dtFecha.Text).ToString();
							kardex.Id_producto = prod[0].Id;
							kardex.Tipo = "C";
							kardex.Cantidad = nuevo;
							kardex.Antes = prod[0].Existencia;
							kardex.Id = 0;
							kardex.Id_documento = Convert.ToInt16(resultado[0].Id);
							using (kardex)
							{
								kardex.CreateKardex();
								List<Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(resultado[0].Id), "C");
								using (afecta)
								{
									afecta.Agrega(numeracion[0].Id);
								}
								
							}
							

						}
						
					}
				}
			}
				
			
			
			this.Close();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void dtFecha_ValueChanged(object sender, EventArgs e)
		{

		}

		private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbProveedor.Text != "")
			{
				txtNumero.Text = cbProveedor.SelectedValue.ToString();
			}
			else {
				txtNumero.Text = "";
			}
		}

		private void chkContado_CheckedChanged(object sender, EventArgs e)
		{
			if (chkContado.Checked != true)
			{
				label14.Visible = true;
				label15.Visible = true;
				txtdias.Visible = true;
				dtVencimiento.Visible = true;
			}
			else {
				label14.Visible = false;
				label15.Visible = false;
				txtdias.Visible = false;
				dtVencimiento.Visible = false;
			}
		}
		private void txtNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbProveedor.SelectedIndex = Convert.ToInt16(txtNumero.Text);
				chkContado.Focus();
			}
		}

		private void txtdias_TextChanged(object sender, EventArgs e)
		{
			if (txtdias.Text == "" || txtdias.Text == "0"){
				dtVencimiento.Value = dtFechaDoc.Value;
			}
			else {
				dtVencimiento.Value = dtFechaDoc.Value.AddDays(Convert.ToInt16(txtdias.Text));
			}
			

		}

		

		

		private void button4_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "txt files (*.xml)|*.xml";
			if (open.ShowDialog() == DialogResult.OK && open.ToString() != " ") {
				XmlDocument CFDI = new XmlDocument();
				CFDI.Load(@open.FileName);
				XmlNode nodo = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
				string valorAtributo = nodo.Attributes.GetNamedItem("Fecha").Value;
				dtFechaDoc.Value = Convert.ToDateTime(valorAtributo) ;
				txtFolio.Text = nodo.Attributes.GetNamedItem("Folio").Value;
				txtdescuento.Text = nodo.Attributes.GetNamedItem("Descuento").Value.ToString();
				XmlNode emisor = CFDI.GetElementsByTagName("cfdi:Emisor").Item(0);
				string RFC= emisor.Attributes.GetNamedItem("Rfc").Value;


				Product prod = new Product();

				string clave = "";
				double sumatoria = 0;
				Providers proveedor = new Providers();
				using (proveedor)
				{
					List<Providers> resultado = proveedor.getProviderbyRFC(RFC);
					if (resultado.Count > 0)
					{
						cbProveedor.SelectedValue = resultado[0].Id;
						txtNumero.Text = resultado[0].Id.ToString();
					}
					else
					{
						proveedor.Id = 0;
						proveedor.RFC = emisor.Attributes.GetNamedItem("Rfc").Value;
						proveedor.Name = emisor.Attributes.GetNamedItem("Nombre").Value;
						proveedor.createProvider();
						resultado = proveedor.getProviderbyRFC(RFC);
						carga_proveedor();
						cbProveedor.SelectedValue = resultado[0].Id;
						txtNumero.Text = resultado[0].Id.ToString();
					}
				}
				foreach (XmlNode conceptos in CFDI.GetElementsByTagName("cfdi:Conceptos").Item(0).ChildNodes) {

					clave = conceptos.Attributes.GetNamedItem("NoIdentificacion").Value;
					using (prod)
					{
						List<Product> bucador = prod.getProductByigualCode(clave);
						if (bucador.Count > 0)
						{
							sumatoria = Convert.ToDouble(conceptos.Attributes.GetNamedItem("Cantidad").Value) * Convert.ToDouble(conceptos.Attributes.GetNamedItem("ValorUnitario").Value);
							dtProductos.Rows.Add(bucador[0].Id, bucador[0].Code1, conceptos.Attributes.GetNamedItem("Cantidad").Value, bucador[0].Description, conceptos.Attributes.GetNamedItem("ValorUnitario").Value, sumatoria);
						}
						else
						{
							DialogResult is_new = MessageBox.Show("El producto no fue encontrado, ¿Es nuevo?", "Producto no encontrado", MessageBoxButtons.YesNo);
							if (is_new == DialogResult.Yes)
							{

								producto.Codigo = "";
								producto Producto = new producto();

								Producto.txtCodigo1.Text = clave;
								Producto.txtDescripcion.Text = conceptos.Attributes.GetNamedItem("Descripcion").Value;
								Producto.txtCosto.Text = conceptos.Attributes.GetNamedItem("ValorUnitario").Value;
								Producto.txtUnidadSat.Text = conceptos.Attributes.GetNamedItem("ClaveUnidad").Value;
								Producto.txtSAT.Text = conceptos.Attributes.GetNamedItem("ClaveProdServ").Value;
								Producto.Owner = this;
								Producto.ShowDialog();

								bucador = prod.getProductByigualCode(clave);
								sumatoria = Convert.ToDouble(conceptos.Attributes.GetNamedItem("Cantidad").Value) * Convert.ToDouble(conceptos.Attributes.GetNamedItem("ValorUnitario").Value);
								dtProductos.Rows.Add(bucador[0].Id, bucador[0].Code1, conceptos.Attributes.GetNamedItem("Cantidad").Value, bucador[0].Description, conceptos.Attributes.GetNamedItem("ValorUnitario").Value, sumatoria);
							}
							else if (is_new == DialogResult.No)
							{
								MessageBox.Show("No se agregara el producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
					}
				}
				calcula();

			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if (txtCodigo.Text != "")
			{
				producto.Codigo = id.ToString();
				producto prod = new producto();
				prod.Show(this);
			}
			else
			{
				MessageBox.Show("Debe seleccionar un articulo a modificar");
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			producto.Codigo = "";
			producto prod = new producto();
			prod.Show(this);
		}

		private void cbProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Providers proveedores = new Providers();
				using (proveedores)
				{
					List<Providers> proveedor = proveedores.getProviderbyNombreabsolute(cbProveedor.Text);
					if (proveedor.Count > 0)
					{
						txtNumero.Text = proveedor[0].Id.ToString();
					}
				}
			}
		}
	}
}
