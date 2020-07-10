using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using caja.Models;
namespace caja.Forms.Reportes
{
	public partial class Inventario : Form
	{
		public Inventario()
		{
			InitializeComponent();
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = maketable();
			Export_pdf pdf = new Export_pdf();
			pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
			MessageBox.Show("Terminado");

		}
		private void btnExcel_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = maketable();
			Export_excel excel = new Export_excel();
			excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes+ "/inventario");
			MessageBox.Show("Terminado");
		}
		private void button2_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = minimos();
			Export_pdf pdf = new Export_pdf();
			pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
			MessageBox.Show("Terminado");
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			List<Configuration> configuracion = config.getConfiguration();
			DataTable dtbl = minimos();
			Export_excel excel = new Export_excel();
			excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes+"inventario");
			MessageBox.Show("Terminado");
		}
		DataTable maketable()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Total");

			Product producto = new Product();
			List<Product> productos = producto.getProducts();
			foreach (Product item in productos)
			{
				inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia,"     ");
			}
			return inventario;
		}
		DataTable minimos() {
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Total");

			Product producto = new Product();
			List<Product> productos = producto.getMinProduct();
			foreach (Product item in productos)
			{
				inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia, "     ");
			}
			return inventario;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DataTable dtbl = minimos();
			dtReporte.DataSource = dtbl;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			dtReporte.DataSource = dtbl;
		}

		private void Inventario_Load(object sender, EventArgs e)
		{

		}
	}
}
