using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Encaja:ConnectDB
	{
		public double Fondo { get; set; }
		public double Efectivo { get; set; }
		public double Entrada { get; set; }
		public double Abonos { get; set; }
		public double Salidas { get; set; }
		public double Total { get; set; }
		public Encaja(
			double fondo, 
			double efectivo,
			double entrada,
			double abonos, 
			double salidas,
			double total
			) {
			Fondo = fondo;
			Efectivo = efectivo;
			Entrada = entrada;
			Abonos = abonos;
			Salidas = salidas;
			Total = total;
		}

		public Encaja() { }

		private Encaja buildEncaja(MySqlDataReader data) {
			Encaja item = new Encaja(
				data.GetDouble(0),
				data.GetDouble(1),
				data.GetDouble(2),
				data.GetDouble(3),
				data.GetDouble(4),
				data.GetDouble(5)
				);
			return item;
		}
	}
}
