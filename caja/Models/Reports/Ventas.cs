using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Reports
{
	public class Ventas
	{
		public double Efectivo { get; set; }
		public double Tarjeta { get; set; }
		public double Total { get; set; }
		public Ventas(
			double efectivo,
			double tarjeta,
			double total
			) {
			Efectivo = efectivo;
			Tarjeta = tarjeta;
			Total = total;
		}

		public Ventas() { }
	}
}
