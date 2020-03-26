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

namespace caja.Forms.Inventario
{
	public partial class Form_ajustes : Form
	{
		public static string folio;
		public static string id;
		public Form_ajustes()
		{
			InitializeComponent();
		}

		private void Form_ajustes_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			txtFolio.Enabled = false;
			dtFecha.Enabled = false;
			if (folio != "0")
			{
				txtCosto.Enabled = false;
				txtCodigo.Enabled = false;
				txtCantidad.Enabled = false;
				txtDescripcion.Enabled = false;
				txtCodigo.Enabled = false;
				btnAgregar.Enabled = false;
				btnGuardar.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
				Ajuste ajuste = new Ajuste();
				List<Ajuste> result = ajuste.getAjustesbyId(Convert.ToInt16(folio));
				foreach (Ajuste item in result) {
					dtFecha.Value = Convert.ToDateTime(item.Fecha);
					txtTotal.Text = item.Total.ToString();
					txtFolio.Text = item.Id.ToString();
				}
				det_ajustes detalles = new det_ajustes();
				Product producto = new Product();
				List<det_ajustes> res = detalles.getDet_ajustes(Convert.ToInt16(folio));
				foreach (det_ajustes it in res) {
					List<Product> prod = producto.getProductById(it.Id_producto);
					dtProductos.Rows.Add(it.Id_producto,it.Cantidad,prod[0].Code1, prod[0].Description, it.P_u, it.Total);
				}
			}
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
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
		private void btnAgregar_Click(object sender, EventArgs e)
		{
			double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtCosto.Text);
			dtProductos.Rows.Add(id, txtCantidad.Text, txtCodigo.Text, txtDescripcion.Text,txtCosto.Text, total);
			txtCantidad.Text = "";
			txtCodigo.Text = "";
			txtDescripcion.Text = "";
			txtCosto.Text = "";
			id = "0";
			calcula();
			txtCantidad.Focus();
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["costo"].Value);
			double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["cantidad"].Value);
			dtProductos.Rows[e.RowIndex].Cells["total"].Value = (p_u * cantidad).ToString();
			calcula();
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Ajuste ajutes = new Ajuste(
				0,
				dtFecha.Text + " 00:00:00",
				Convert.ToDouble(txtTotal.Text),
				"",
				"A"
				);
			ajutes.createAjuste();
			List<Ajuste> general = ajutes.getlastAjustes(dtFecha.Text + " 00:00:00", Convert.ToDouble(txtTotal.Text));
			det_ajustes detalle = new det_ajustes();
			detalle.Id = 0;
			detalle.Id_ajuste = general[0].Id;
			Kardex kardex = new Kardex();
			Product producto = new Product();
			Afecta_inv afecta = new Afecta_inv();
			int nuevo = 0;
			folio = general[0].Id.ToString() ;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				detalle.Id_producto =  Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
				detalle.P_u = Convert.ToDouble(row.Cells["costo"].Value.ToString());
				detalle.Cantidad = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
				detalle.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
				detalle.craeteDet_ajuste();

				List<Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
				nuevo = Convert.ToInt16(row.Cells["cantidad"].Value.ToString());
				while (prod[0].Parent != "0")
				{
					nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
					prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));


				}
				kardex.Fecha = Convert.ToDateTime(dtFecha.Text).ToString();
				kardex.Id_producto = prod[0].Id;
				kardex.Tipo = "A";
				kardex.Cantidad = nuevo;
				kardex.Antes = prod[0].Existencia;
				kardex.Id = 0;
				kardex.Id_documento = Convert.ToInt16(folio);
				kardex.CreateKardex();
				List<Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "A");
				afecta.Ajusta(numeracion[0].Id);

			}
			this.Close();

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
				btnAgregar.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					btnAgregar.Focus();
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
				btnAgregar.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					btnAgregar.Focus();
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
	}
}
