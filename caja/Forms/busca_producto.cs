using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;
namespace caja.Forms
{
	public partial class busca_producto : Form
	{
		public busca_producto()
		{
			InitializeComponent();
		}

		private void busca_producto_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga() {
			dtProductos.Rows.Clear();
			Product producto = new Product();
			List<Product> result = producto.getProducts();
			foreach (Product item in result) {
				dtProductos.Rows.Add(item.Id, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, item.Price1, item.Price2, item.Price3, item.Price4, item.Price5);
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text == "")
				{
					carga();
				}
				else
				{
					dtProductos.Rows.Clear();
					Product producto = new Product();
					List<Product> result = producto.getProductByCode(txtCodigo.Text);
					foreach (Product item in result)
					{
						dtProductos.Rows.Add(item.Id, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, item.Price1, item.Price2, item.Price3, item.Price4, item.Price5);
					}
				}
				
				dtProductos.Focus();
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescripcion.Text == "")
				{
					carga();
				}
				else 
				{
					dtProductos.Rows.Clear();
					Product producto = new Product();
					List<Product> result = producto.getProductByDescription(txtDescripcion.Text);
					foreach (Product item in result)
					{
						dtProductos.Rows.Add(item.Id ,item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, item.Price1, item.Price2, item.Price3, item.Price4, item.Price5);
					}
				}
				
				dtProductos.Focus();
			}
		}

		private void dtProductos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtProductos.CurrentRow.Index;
				string valor = dtProductos.Rows[i].Cells["id"].Value.ToString();

				intercambios.Id_producto = Convert.ToInt16(valor);
				this.Close();
			}
		}
	}
}
