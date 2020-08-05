using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Reports
{
	public class Retiro_proveedores
	{
		public string Proveedor { get; set; }
		public double Monto { get; set; }
		public Retiro_proveedores(
			string proveedor,
			double monto
			)
		{
			Proveedor = proveedor;
			Monto = monto;
		}

		public Retiro_proveedores() { }
	}
}
