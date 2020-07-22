using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caja.Forms.Reportes
{
	public partial class Ganancias : Form
	{
		public Ganancias()
		{
			InitializeComponent();
		}

		private void Ganancias_Load(object sender, EventArgs e)
		{
			fInicial.Format = DateTimePickerFormat.Custom;
			fInicial.CustomFormat = "yyyy-MM-dd";
			fFinal.Format = DateTimePickerFormat.Custom;
			fFinal.CustomFormat = "yyyy-MM-dd";



		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Reports.Ganancias reporte = new Models.Reports.Ganancias();
			using (reporte)
			{
				List<Models.Reports.Ganancias> ganancia = reporte.getganancias(fInicial.Text, fFinal.Text);
				if (ganancia.Count > 0)
				{
					dtGanancias.Rows.Clear();
					foreach (Models.Reports.Ganancias item in ganancia)
					{
						dtGanancias.Rows.Add(item.Producto, item.Costo, item.Ganancia, item.Bruto);
					}
				}
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Models.Configuration config = new Models.Configuration();
			using (config)
			{
				List<Models.Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = maketable();
				Models.Export_excel excel = new Models.Export_excel();
				excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "/Ganancias");
				MessageBox.Show("Terminado");
			}
			
		}

		DataTable maketable()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Producto");
			inventario.Columns.Add("Costo");
			inventario.Columns.Add("Ganancia");
			inventario.Columns.Add("Bruto");

			Models.Reports.Ganancias reporte = new Models.Reports.Ganancias();
			using (reporte)
			{
				List<Models.Reports.Ganancias> ganancia = reporte.getganancias(fInicial.Text, fFinal.Text);
				if (ganancia.Count > 0)
				{
					dtGanancias.Rows.Clear();
					foreach (Models.Reports.Ganancias item in ganancia)
					{
						inventario.Rows.Add(item.Producto, item.Costo, item.Ganancia, item.Bruto);
					}
				}
				return inventario;
			}
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Models.Configuration config = new Models.Configuration();
			using (config)
			{
				List<Models.Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = maketable();
				Models.Export_pdf pdf = new Models.Export_pdf();
				pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/Ganancias.pdf", "Ganancias");
				MessageBox.Show("Terminado");
			}
			
		}
	}
}
