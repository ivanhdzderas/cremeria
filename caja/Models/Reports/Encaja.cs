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
		public double Retiros { get; set; }
		
		public Encaja(
			double fondo,
			double retiros
			) {
			Fondo = fondo;
			Retiros = retiros;
		}

		public Encaja() { }

		
	}
}
