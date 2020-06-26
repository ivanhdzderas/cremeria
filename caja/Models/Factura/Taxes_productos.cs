using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Factura
{
	public class Taxes_productos
	{
		public Decimal rate { get; set; }
		public string type { get; set; }
		public Boolean withholding { get; set; }

	}
}
