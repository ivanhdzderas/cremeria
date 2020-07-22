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
	public partial class Forms_pagos : Form
	{
		public Forms_pagos()
		{
			InitializeComponent();
		}

		private void Forms_pagos_Load(object sender, EventArgs e)
		{
			lbTotal.Text = "";
			dtfecha.Format = DateTimePickerFormat.Custom;
			dtfecha.CustomFormat = "yyyy-MM-dd"; 
			Folios folios = new Folios();
			using (folios)
			{
				List<Folios> item = folios.getFolios();
				lbFolio.Text = item[0].Pagos.ToString();
			}
			

			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtDescripcion.AutoCompleteCustomSource = cargadatos2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;



			txtidproveedor.AutoCompleteCustomSource = carga_proveedor1();
			txtidproveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtidproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtproveedor.AutoCompleteCustomSource = carga_proveedor2();
			txtproveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;


		}

		private AutoCompleteStringCollection carga_proveedor1()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Providers proveedores = new Providers();
			using (proveedores)
			{
				List<Providers> result = proveedores.getProviders();
				foreach (Providers item in result)
				{
					datos.Add(item.Id.ToString());
				}
			}
			
			return datos;
		}
		private AutoCompleteStringCollection carga_proveedor2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Providers proveedores = new Providers();
			using (proveedores)
			{
				List<Providers> result = proveedores.getProviders();
				foreach (Providers item in result)
				{
					datos.Add(item.Name);
				}
			}
			
			return datos;
		}

		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Fpagos pagos = new Fpagos();
			using (pagos)
			{
				List<Fpagos> result = pagos.getpagos();
				foreach (Fpagos item in result)
				{
					datos.Add(item.Id.ToString());
				}
			}
			
			return datos;
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Fpagos pagos = new Fpagos();
			using (pagos)
			{
				List<Fpagos> result = pagos.getpagos();
				foreach (Fpagos item in result)
				{
					datos.Add(item.Fpago);
				}

			}
			
			return datos;
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{ 
				if (txtCodigo.Text != "")
				{
					Fpagos pagos = new Fpagos();
					using (pagos)
					{
						List<Fpagos> result = pagos.getpagosbyid(string.Format("{0:00}", Convert.ToInt16(txtCodigo.Text)));
						txtDescripcion.Text = result[0].Fpago;
					}
					

				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescripcion.Text != "")
				{
					Fpagos pagos = new Fpagos();
					using (pagos)
					{
						List<Fpagos> result = pagos.getpagosbydescripcion(txtDescripcion.Text);
						txtCodigo.Text = string.Format("{0:00}", Convert.ToInt16(result[0].Id));
					}
					
				}
			}
		}

		private void txtidproveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtidproveedor.Text != "")
				{
					Providers proveedores = new Providers();
					using (proveedores) {
						List<Providers> result = proveedores.getProviderbyId(Convert.ToInt16(txtidproveedor.Text));
						if (result.Count > 0)
						{
							txtproveedor.Text = result[0].Name;
							cbFacturas.Enabled = true;
							carga_facturas();
						}
					}
					
				}
			}
		}
		private void carga_facturas()
		{
			cbFacturas.DataSource = null;
			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);
			Models.Compras compras = new Models.Compras();
			using (compras)
			{
				List<Models.Compras> compra = compras.getCompra_sin_pagar(txtidproveedor.Text);
				foreach (Models.Compras item in compra)
				{
					cbFacturas.Items.Add(item.Folio_doc);
					row = table.NewRow();
					row["Text"] = item.Folio_doc;
					row["Value"] = item.Id.ToString();
					table.Rows.Add(row);
				}
			}
			

			cbFacturas.BindingContext = new BindingContext();
			cbFacturas.DataSource = table;
			cbFacturas.DisplayMember = "Text";
			cbFacturas.ValueMember = "Value";
			cbFacturas.BindingContext = new BindingContext();


			
			
		}
		private void txtproveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtproveedor.Text != "")
				{
					Providers proveedores = new Providers();
					using (proveedores)
					{
						List<Providers> result = proveedores.getProviderbyNombreabsolute(txtproveedor.Text);
						if (result.Count > 0)
						{
							txtidproveedor.Text = result[0].Id.ToString();
							cbFacturas.Enabled = true;
							carga_facturas();
						}
					}
					
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			borrar_error();
			if (validar_campo())
			{
				Pagos_compras pagos = new Pagos_compras();
				using (pagos)
				{
					pagos.Id_compra = Convert.ToInt16(lbFolio.Text);
					pagos.Fpago = Convert.ToInt16(txtCodigo.Text);
					pagos.Folio_pago = txtFolio.Text;
					pagos.Fecha_pago = dtfecha.Text + " 00:00:00";
					pagos.Monto = Convert.ToDouble(lbTotal.Text);
					pagos.create_pago();
					using (pagos)
					{
						List<Pagos_compras> lista = pagos.getcomprabyfolio(lbFolio.Text);

						Det_pagos det_pagos = new Det_pagos();
						det_pagos.Id_pago = Convert.ToInt16(lbFolio.Text);

						Models.Compras compras = new Models.Compras();

						foreach (DataGridViewRow row in dtpagos.Rows)
						{
							using (det_pagos)
							{
								det_pagos.Id_compra = Convert.ToInt16(row.Cells["id"].Value.ToString());
								det_pagos.createPago();
							}

							using (compras)
							{
								compras.Id = Convert.ToInt16(row.Cells["id"].Value.ToString());
								compras.pagar();
							}
							
						}
					}
					
				}
				
				this.Close();
			}
		}

		private bool validar_campo()
		{
			bool ok = true;
			if (txtFolio.Text == "")
			{
				ok = false;
				errorProvider1.SetError(txtFolio, "Ingrese folio de pago");
			}


			if (dtfecha.Text == "")
			{
				ok = false;
				errorProvider1.SetError(dtfecha, "Ingrese fecha de pago");
			}

			if (txtCodigo.Text == "")
			{
				ok = false;
				errorProvider1.SetError(txtCodigo, "Ingrese metodo de pago");
			}
			if (txtidproveedor.Text == "")
			{
				ok = false;
				errorProvider1.SetError(txtidproveedor, "Ingrese proveedor de pago");
			}


			if (dtpagos.Rows.Count ==0)
			{
				ok = false;
				errorProvider1.SetError(dtpagos, "Ingrese facturas a pagar");
			}
			return ok;

		}
		private void borrar_error()
		{
			errorProvider1.SetError(txtFolio, "");
			errorProvider1.SetError(dtfecha, "");
			errorProvider1.SetError(txtCodigo, "");
			errorProvider1.SetError(txtidproveedor, "");
			errorProvider1.SetError(dtpagos, "");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (cbFacturas.SelectedValue == "")
			{
				MessageBox.Show("Seleccione factura a agregar","Pagos",MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				Models.Compras compras = new Models.Compras();
				using (compras)
				{
					List<Models.Compras> compra = compras.getCompraByid(Convert.ToInt16(cbFacturas.SelectedValue));
					dtpagos.Rows.Add(compra[0].Id, compra[0].Folio_doc, compra[0].Fecha_doc, compra[0].Total);
				}
				
				calcula();
			}
		}
		private void calcula()
		{
			double total = 0;
			foreach (DataGridViewRow row in dtpagos.Rows)
			{
				total = total + Convert.ToDouble(row.Cells["monto"].Value.ToString());
			}
			lbTotal.Text = string.Format("{0:#,0.00}", total);
		}

		private void dtpagos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}
	}
}
