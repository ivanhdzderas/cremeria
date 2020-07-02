using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caja.Forms
{
	public partial class Levantar_inventario : Form
	{
		static int id_producto = 0;
		public Levantar_inventario()
		{
			InitializeComponent();
		}

		private void Levantar_inventario_Load(object sender, EventArgs e)
		{
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			List<Models.Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
			foreach (Models.Product item in result)
			{
				datos.Add(item.Code1);
			}
			return datos;
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				List<Models.Product> producto = productos.getProductByCode(txtCodigo.Text);
				if (producto.Count > 0)
				{
					txtDescripcion.Text = producto[0].Description;
					id_producto = producto[0].Id;
					txtCantidad.Focus();
				}

			}
		}

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			Boolean encontrado = false;

			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "")
				{
					if (txtCantidad.Text == "")
					{
						foreach (DataGridViewRow row in dtPoroductos.Rows)
						{
							if (row.Cells["id"].Value.ToString()==id_producto.ToString()) {
								encontrado = true;
								row.Cells["cantidad"].Value = Convert.ToInt16(row.Cells["cantidad"].Value) + 1;
								break;
							}
						}
						if (encontrado == false)
						{
							dtPoroductos.Rows.Add(id_producto, txtCodigo.Text, txtDescripcion.Text, "1");
						}
						
					}
					else
					{
						foreach (DataGridViewRow row in dtPoroductos.Rows)
						{
							if (row.Cells["id"].Value.ToString() == id_producto.ToString())
							{
								encontrado = true;
								row.Cells["cantidad"].Value = Convert.ToInt16(row.Cells["cantidad"].Value) + Convert.ToInt16(txtCantidad.Text);
								break;
							}
						}
						if (encontrado == false)
						{
							dtPoroductos.Rows.Add(id_producto, txtCodigo.Text, txtDescripcion.Text, txtCantidad.Text);
						}
					}

					txtCantidad.Text = "";
					txtDescripcion.Text = "";
					txtCodigo.Text = "";
					txtCodigo.Focus();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Deseas efecturar el inventario", "Inventario", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				DateTime today = DateTime.Today;
				string fecha = today.ToString("dd/MM/yyyy") + " 00:00:00";
				Models.Ajuste ajutes = new Models.Ajuste(
						0,
						fecha,
						Convert.ToDouble(0),
						"",
						"A"
						);
				ajutes.createAjuste();
				List<Models.Ajuste> general = ajutes.getlastAjustes(fecha, Convert.ToDouble(0));
				Models.det_ajustes detalle = new Models.det_ajustes();
				detalle.Id = 0;
				detalle.Id_ajuste = general[0].Id;
				Models.Kardex kardex = new Models.Kardex();
				Models.Product producto = new Models.Product();
				Models.Afecta_inv afecta = new Models.Afecta_inv();
				int nuevo = 0;
				string folio = general[0].Id.ToString();
				foreach (DataGridViewRow row in dtPoroductos.Rows)
				{
					detalle.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
					detalle.P_u = Convert.ToDouble(row.Cells["costo"].Value.ToString());
					detalle.Cantidad = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
					detalle.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
					detalle.craeteDet_ajuste();

					List<Models.Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
					nuevo = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
					while (prod[0].Parent != "0")
					{
						nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
						prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));


					}
					kardex.Fecha = Convert.ToDateTime(today.ToString("dd/MM/yyyy")).ToString();
					kardex.Id_producto = prod[0].Id;
					kardex.Tipo = "A";
					kardex.Cantidad = nuevo;
					kardex.Antes = prod[0].Existencia;
					kardex.Id = 0;
					kardex.Id_documento = Convert.ToInt16(folio);
					kardex.CreateKardex();
					List<Models.Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "A");
					afecta.Ajusta(numeracion[0].Id);
				}
			}
		}
	}
}
