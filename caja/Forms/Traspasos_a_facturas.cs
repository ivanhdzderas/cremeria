using caja.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace caja.Forms
{
	public partial class Traspasos_a_facturas : Form
	{
		public Traspasos_a_facturas()
		{
			InitializeComponent();
		}

		private void Traspasos_a_facturas_Load(object sender, EventArgs e)
		{
			txtIdSucursal.AutoCompleteCustomSource = cargadatos();
			txtIdSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtIdSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtSucursal.AutoCompleteCustomSource = cargadatos2();
			txtSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Offices oficinas = new Offices();
			using (oficinas)
			{
				List<Offices> oficina = oficinas.GetOffices();
				foreach (Offices item in oficina)
				{
					datos.Add(item.Id.ToString());
				}
			}
			
			return datos;
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Offices oficinas = new Offices();
			using (oficinas)
			{
				List<Offices> oficina = oficinas.GetOffices();
				foreach (Offices item in oficina)
				{
					datos.Add(item.Name);
				}
			}
			
			return datos;
		}

		private void txtIdSucursal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Offices oficinas = new Offices();
				using (oficinas)
				{
					List<Offices> oficina = oficinas.GetOfficesbyid(Convert.ToInt16(txtIdSucursal.Text));
					txtSucursal.Text = oficina[0].Name;

					Transfers traspasos = new Transfers();
					List<Transfers> traspaso = traspasos.getTransferbysucursal(Convert.ToInt16(txtIdSucursal.Text));
					foreach (Transfers item in traspaso)
					{
						dtTrasferencias.Rows.Add(item.Id, item.Folio, item.Fecha, item.Total);
					}
				}
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_factura form_interface = this.Owner as Form_factura;
			foreach (DataGridViewRow row in dtTrasferencias.Rows)
			{
				if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
				{

					form_interface.dtdocumentos.Rows.Add(row.Cells["id"].Value.ToString(),"traspaso");
				}
			}
			form_interface.txtIdCliente.Text = txtIdSucursal.Text;
			form_interface.txtCliente.Text = txtSucursal.Text;

			this.Close();
		}
	}
}
