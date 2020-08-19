using Microsoft.Reporting.WinForms;
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
	public partial class vendido : Form
	{
		public vendido()
		{
			InitializeComponent();
		}

		private void vendido_Load(object sender, EventArgs e)
		{
			Finicial.Format = DateTimePickerFormat.Custom;
			Finicial.CustomFormat = "yyyy-MM-dd";
			Ffinal.Format = DateTimePickerFormat.Custom;
			Ffinal.CustomFormat = "yyyy-MM-dd";
			this.reportViewer1.RefreshReport();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Reports.Mas_vendidos mas_vedidos = new Models.Reports.Mas_vendidos();

			using (mas_vedidos)
			{
				this.reportViewer1.LocalReport.ReportEmbeddedResource = "caja.Reports.Mas_vendido.rdlc";
				this.reportViewer1.LocalReport.DataSources.Clear();
				List<Models.Reports.Mas_vendidos> vendidos= mas_vedidos.get_todosmasvendidos(Finicial.Text, Ffinal.Text);
				ReportDataSource datasource = new ReportDataSource("Mas_vendido", vendidos);
				this.reportViewer1.LocalReport.DataSources.Add(datasource);
				this.reportViewer1.RefreshReport();
			}
		}
	}
}
