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
	public partial class devoluciones : Form
	{
		public static Boolean cancelado;
		private static string Id;
		public static int id_usuario;
		public devoluciones()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			autentificar cb = new autentificar();
			cb.origen = "Devollucion";
			cancelado = false;
			cb.Owner = this;
			cb.ShowDialog();
			if (cancelado == false)
			{
				devolucion();
			}
		}
		private void devolucion()
		{
			Devolutions devolucion = new Devolutions();
			devolucion.Fecha = dtFecha.Text + " 00:00:00";
			devolucion.Autorizo = id_usuario;
			devolucion.Total = Convert.ToDouble(txtTotal.Text);
			devolucion.create();
			List<Devolutions> devo = devolucion.get_lastdevocion(dtFecha.Text + " 00:00:00", id_usuario, Convert.ToDouble(txtTotal.Text));

			det_devolution detalles = new det_devolution();
			detalles.Id_devolucion = devo[0].Id;

			Product productos = new Product();
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
				detalles.Pu = Convert.ToDouble(row.Cells["pu"].Value.ToString());
				detalles.create_det();

				productos.Id= Convert.ToInt16(row.Cells["id"].Value.ToString());
				List<Product> produ = productos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
				productos.Devoluciones=produ[0].Devoluciones+ Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				productos.update_devoluciones();
			}

			limpiar();
			MessageBox.Show("Se guardo con exito la devolucion");
		}
		private void limpiar()
		{
			dtProductos.Rows.Clear();
			txtTotal.Text = "";
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtPrecio.Text = "";
			id_usuario = 0;
			Id = "";
			
		}
		private void devoluciones_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";

			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtDescripcion.AutoCompleteCustomSource = cargadatos2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Product producto = new Product();
			List<Product> result = producto.getProducts();
			foreach (Product item in result)
			{
				datos.Add(item.Code1);
			}
			return datos;
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Product producto = new Product();
			List<Product> result = producto.getProducts();
			foreach (Product item in result)
			{
				datos.Add(item.Description);
			}
			return datos;
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Product producto = new Product();
				List<Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
				if (result.Count > 0)
				{
					txtDescripcion.Text = result[0].Description;
					txtPrecio.Text = result[0].Price1.ToString();
					Id = result[0].Id.ToString();
					txtCantidad.Focus();
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Product producto = new Product();
				List<Product> result = producto.getProductByDescription(txtDescripcion.Text);
				if (result.Count > 0)
				{
					txtCodigo.Text = result[0].Code1;
					txtPrecio.Text = result[0].Price1.ToString();
					Id = result[0].Id.ToString();
					txtCantidad.Focus();
				}
			}
		}

		private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
				dtProductos.Rows.Add(Id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtPrecio.Text, total);
				txtCantidad.Text = "";
				txtDescripcion.Text = "";
				txtCodigo.Text = "";
				txtPrecio.Text = "";
				Id = "";
				calcula();
				txtCodigo.Focus();
			}
		}
		private void calcula() {
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				total +=  Convert.ToDouble(row.Cells["total"].Value.ToString());
			}
			txtTotal.Text = total.ToString();
		}

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
				dtProductos.Rows.Add(Id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtPrecio.Text, total);
				txtCantidad.Text = "";
				txtDescripcion.Text = "";
				txtCodigo.Text = "";
				txtPrecio.Text = "";
				Id = "";
				calcula();
				txtCodigo.Focus();
			}
		}
	}
}
