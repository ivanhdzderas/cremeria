using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Factura
{
	public class items
	{
		public double quantity { get; set; }
		public Productos product { get; set; }
		public decimal discount { get; set; }
	}
}
