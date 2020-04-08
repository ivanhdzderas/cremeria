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
			List<Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
			foreach (Product item in result)
			{
				datos.Add(item.Code1);
			}


			return datos;
		}
		private void Transfer_forms_Load(object sender, EventArgs e)
		{
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			lbFecha.Visible = false;
			DataTable table = new DataTable();
			DataRow row;

			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));

			
			Offices oficinas = new Offices();
			List<Offices> oficina = oficinas.GetOffices();
			foreach(Offices ofi in oficina)
			{
				row = table.NewRow();
				row["Text"] = ofi.Name;
				row["Value"] = ofi.Id;
				table.Rows.Add(row);
			}
			cbOficinas.BindingContext = new BindingContext();
			cbOficinas.DataSource = table;
			cbOficinas.DisplayMember = "Text";
			cbOficinas.ValueMember = "Value";
			cbOficinas.BindingContext = new BindingContext();

			if (id_transfer != 0)
			{
				Transfers transferencias = new Transfers();
				List<Transfers> lista = transferencias.getTransferbyid(id_transfer);

				Det_transfers detalles = new Det_transfers();
				Product productos = new Product();
				if (lista.Count > 0)
				{
					txtFolios.Text = lista[0].Folio.ToString();
					lbFecha.Visible = true;
					lbFecha.Text = lista[0].Fecha.ToString();
					List<Det_transfers> detallado = detalles.getDet_trans(id_transfer);
					if (detallado.Count > 0)
					{
						foreach(Det_transfers item in detallado)
						{
							List<Product> producto = productos.getProductById(item.Id_producto);
							double importe = item.Precio * item.Cantidad;
							dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, importe);
						}
					}
				}
			}
			else
			{
				Folios folio = new Folios();
				List<Folios> transfer = folio.getFolios();
				txtFolios.Text = transfer[0].Transferencia.ToString();
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
				List<Product> producto = productos.getProductBycode1(txtCodigo.Text);
				if (producto.Count > 0)
				{
					id_producto = producto[0].Id;
					txtDescripcion.Text = producto[0].Description;
					txtPrecio.Text = producto[0].Cost.ToString();

				}
				txtPrecio.Focus();
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
		private void calcula()
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
			txtIva.Text = string.Format("{0:#,0.00}", iva);
			txtTotal.Text = string.Format("{0:#,0.00}", total);
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
			transferencia.Folio =Convert.ToInt16(txtFolios.Text);
			transferencia.Tipo_trapaso = "E";
			transferencia.Sucursal = cbOficinas.SelectedValue.ToString();
			transferencia.Subtotal = Convert.ToDouble(txtSubtotal.Text);
			transferencia.Iva = Convert.ToDouble(txtIva.Text);
			transferencia.Total = Convert.ToDouble(txtTotal.Text);
			transferencia.Facturado = Convert.ToInt16(false);
			transferencia.CreateTransfer();
			List<Transfers> ultimo= transferencia.getTransferbyfolio(Convert.ToInt16(txtFolios.Text), "E");

			Det_transfers detalles = new Det_transfers();
			detalles.Folio = Convert.ToInt16(txtFolios.Text);
			detalles.Tipo = "E";
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				detalles.Cantidad = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
				detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
				detalles.Precio = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
				detalles.CreateDet();
			}

		}
	}
}
