﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja.Models.Reports
{
	public class Totales
	{
		public double Total { get; set; }
		public Totales(
			double total
			) {
			Total = total;
		}
		public Totales() { }
	}
}
