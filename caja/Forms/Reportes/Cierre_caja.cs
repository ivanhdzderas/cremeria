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
using caja.Models.Reports;
using Microsoft.Reporting.WinForms;

namespace caja.Forms.Reportes
{
	public partial class Cierre_caja : Form
	{
		public Cierre_caja()
		{
			InitializeComponent();
		}

		private void Cierre_caja_Load(object sender, EventArgs e)
		{
			Venta_grupo venta_grupos = new Venta_grupo();
			using (venta_grupos)
			{
				List<Venta_grupo> item = venta_grupos.get_ventas();
				ReportDataSource datasource = new ReportDataSource("VentaGrupo", item);
				Ventas general = new Ventas();
				general.Efectivo = 0;
				general.Tarjeta = 0;
				general.Total = 0;

				this.reportViewer1.LocalReport.ReportEmbeddedResource = "caja.Reports.caja.rdlc";
				this.reportViewer1.LocalReport.DataSources.Clear();
				this.reportViewer1.LocalReport.DataSources.Add(datasource);

				Encaja en_encaja = new Encaja();
				Tickets ticket = new Tickets();
				using (ticket)
				{
					List<Tickets> lista = ticket.getbyUser(Convert.ToInt16(inicial.id_usario));
					double total = 0;
					Cortes cortes = new Cortes();
					using (cortes)
					{
						List<Cortes> ultimo = cortes.getnoclose(Convert.ToInt16(inicial.id_usario));
						if (ultimo.Count > 0)
						{
							en_encaja.Fondo = Convert.ToDouble(ultimo[0].Caja_inicial);
							foreach (Tickets it in lista)
							{
								total += it.Total;
							}
							en_encaja.Efectivo = total;
							en_encaja.Entrada = 0;
							en_encaja.Abonos = 0;
							en_encaja.Salidas = 0;
							en_encaja.Total = (total + ultimo[0].Caja_inicial);
						}
						List<Encaja> enca = new List<Encaja>();
						enca.Add(en_encaja);
						List<Ventas> vent = new List<Ventas>();
						vent.Add(general);
						general = null;
						en_encaja = null;
						ReportDataSource ven = new ReportDataSource("Ventas", vent);
						ReportDataSource data = new ReportDataSource("Aldia", enca);
						this.reportViewer1.LocalReport.DataSources.Add(data);
						this.reportViewer1.LocalReport.DataSources.Add(ven);
						this.reportViewer1.RefreshReport();
					}
					
				}
				
			}
			

			
		}
	}
}
