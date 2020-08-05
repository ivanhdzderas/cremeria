using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Reports
{
	public class Totales
	{
		public double Total { get; set; }
		public double Ganancias { get; set; }
		public Totales(
			double total, 
			double ganancias
			) {
			Total = total;
			Ganancias = ganancias;
		}
		public Totales() { }
	}
}
