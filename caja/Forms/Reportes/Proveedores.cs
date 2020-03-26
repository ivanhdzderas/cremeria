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
namespace caja.Forms.Reportes
{
	public partial class Proveedores : Form
	{
		public Proveedores()
		{
			InitializeComponent();
		}

		private void Proveedores_Load(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			dtReporte.DataSource = dtbl;
		}

		DataTable maketable()
		{
			DataTable tabla = new DataTable();

			tabla.Columns.Add("Nombre");
			tabla.Columns.Add("RFC");
			tabla.Columns.Add("telefono");
			tabla.Columns.Add("Correo");

			Providers proveedores = new Providers();
			List<Providers> prov = proveedores.getProviders();
			foreach (Providers item in prov)
			{
				tabla.Rows.Add(item.Name, item.RFC, item.Tel, item.Email);
			}
			return tabla;
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			Export_pdf pdf = new Export_pdf();
			pdf.ExportDatatablePdf(dtbl, "Proveedores.pdf", "Proveedores");
			MessageBox.Show("Terminado");
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			Export_excel excel = new Export_excel();
			excel.ExportToExcel(dtbl, "Proveedores");
			MessageBox.Show("Terminado");
		}
	}
}
