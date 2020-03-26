using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms.Inventario
{
	public partial class Form_salida : Form
	{
		public static string Entrada;
		public static string folio;
		public static string id;
		public Form_salida()
		{
			InitializeComponent();
		}

		private void Form_salida_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";

			if (folio == "0")
			{
				txtCantidad.Text = "";
				txtCodigo.Text = "";
				txtDescripcion.Text = "";
				txtTotal.Text = "";
				txtFolio.Text = "";
				txtCosto.Text = "";
				id = "0";
			}
			else
			{
				Inv_out inv_out = new Inv_out();
				List<Inv_out> data = inv_out.getListabyId(folio);
				foreach (Inv_out item in data)
				{
					txtFolio.Text = folio;
					txtTotal.Text = item.Total.ToString();
					dtFecha.Text = item.Date.ToString();

				}

				Product producto = new Product();

				Det_salidas detalles = new Det_salidas();
				List<Det_salidas> det = detalles.getDet_salidas(Convert.ToInt16(folio));
				foreach (Det_salidas item in det)
				{
					List<Product> det_producto = producto.getProductById(item.Id_producto);
					foreach (Product res in det_producto)
					{
						dtProductos.Rows.Add(item.Id_producto, res.Code1, item.Cantidad, res.Description, item.P_u, item.Total.ToString());
					}
				}
				txtCantidad.Enabled = false;
				txtCodigo.Enabled = false;
				txtDescripcion.Enabled = false;
				button1.Enabled = false;
				button2.Enabled = false;
				dtFecha.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				busca_producto busca = new busca_producto();
				busca.ShowDialog();

				Product producto = new Product();
				List<Product> result = producto.getProductById(intercambios.Id_producto);
				foreach (Product item in result)
				{
					id = item.Id.ToString();
					txtCodigo.Text = item.Code1;
					txtDescripcion.Text = item.Description;
					txtCosto.Text = item.Cost.ToString();
				}
				button1.Focus();
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

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				busca_producto busca = new busca_producto();
				busca.ShowDialog();

				Product producto = new Product();
				List<Product> result = producto.getProductById(intercambios.Id_producto);
				foreach (Product item in result)
				{
					id = item.Id.ToString();
					txtCodigo.Text = item.Code1;
					txtDescripcion.Text = item.Description;
					txtCosto.Text = item.Cost.ToString();
				}
				button1.Focus();
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

		private void button1_Click(object sender, EventArgs e)
		{
			double total1 = (Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtCosto.Text));
			dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtCosto.Text, total1.ToString());
			id = "";
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtCosto.Text = "";
			calcula();
			txtCantidad.Focus();
		}
		public void calcula()
		{
			double totales = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				totales = totales + Convert.ToDouble(row.Cells["total"].Value.ToString());
			}
			txtTotal.Text = totales.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Inv_out salida = new Inv_out(
				Convert.ToInt16(folio),
				dtFecha.Text + " 00:00:00",
				"",
				Convert.ToDouble(txtTotal.Text),
				"A"
				);

			Det_salidas det = new Det_salidas();
			Kardex kardex = new Kardex();
			Product producto = new Product();
			Afecta_inv afecta = new Afecta_inv();
			int nuevo = 0;
			det.Id = 0;

			if (folio == "0")
			{
				salida.createInv_out();
				List<Inv_out> result = salida.getListabyAll(dtFecha.Text + " 00:00:00", Convert.ToDouble(txtTotal.Text));
				folio = result[0].Id.ToString();
				det.Id_salida = Convert.ToInt16(folio);
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					det.Cantidad = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
					det.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
					det.P_u = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
					det.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
					det.craeteDet_salida();
					List<Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
					nuevo = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
					while (prod[0].Parent != "0")
					{
						nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
						prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));
					}
					kardex.Fecha = Convert.ToDateTime(dtFecha.Text).ToString();
					kardex.Id_producto = prod[0].Id;
					kardex.Tipo = "S";
					kardex.Cantidad = nuevo;
					kardex.Antes = prod[0].Existencia;
					kardex.Id = 0;
					kardex.Id_documento = Convert.ToInt16(folio);
					kardex.CreateKardex();
					List<Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "S");
					afecta.Disminuye(numeracion[0].Id);
				}

			}
			if (Entrada == "")
			{
				Entradas formInterface = this.Owner as Entradas;
				formInterface.carga();
			}

			this.Close();
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["p_u"].Value);
			double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["cantidad"].Value);
			dtProductos.Rows[e.RowIndex].Cells["total"].Value = (p_u * cantidad).ToString();
			calcula();
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}
	}
}
