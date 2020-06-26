using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Factura
{
	public class Productos
	{
		public string description { get; set; }
		public string product_key { get; set; }
		public double price { get; set; }
		public Boolean tax_included { get; set; }
		public Taxes_productos Taxes { get; set; }
		//public local_taxes local_taxes { get; set; }
		public string unit_key { get; set; }
		public string unit_name { get; set; }
	}
}
