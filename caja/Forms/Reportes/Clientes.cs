using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms.Reportes
{
	public partial class Clientes : Form
	{
		public Clientes()
		{
			InitializeComponent();
		}

		private void Clientes_Load(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			dtReporte.DataSource = dtbl;
		}
		private DataTable maketable() 
		{
			DataTable tabla = new DataTable();

			tabla.Columns.Add("Nombre");
			tabla.Columns.Add("RFC");
			tabla.Columns.Add("telefono");
			tabla.Columns.Add("Correo");

			Client clientes = new Client();
			List<Client> clie = clientes.getClients();
			foreach (Client item in clie)
			{
				tabla.Rows.Add(item.Name, item.RFC, item.Tel, item.Email);
			}
			return tabla;
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = maketable();
			Export_pdf pdf = new Export_pdf();
			pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/Clientes.pdf", "Clientes");
			MessageBox.Show("Terminado");
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = maketable();
			Export_excel excel = new Export_excel();
			excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "/Clientes");
			MessageBox.Show("Terminado");
		}
	}
}
