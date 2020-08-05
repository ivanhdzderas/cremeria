using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Tickets:ConnectDB
	{
		public string Folio { get; set; }
		public double Total { get; set; }
		public double Ganancias { get; set; }
		public double S_iva { get; set; }
		public double C_iva { get; set; }
		public Tickets (
			string folio, 
			double total, 
			double gancias,
			double s_iva,
			double c_iva
			)
		{
			Folio = folio;
			Total = total;
			Ganancias = gancias;
			S_iva = s_iva;
			C_iva = c_iva;
		}

		public Tickets() { 
		}

		private Tickets build_ticket(MySqlDataReader data)
		{
			Tickets item = new Tickets(
				data.GetString("id"),
				data.GetDouble("total"),
				data.GetDouble(2),
				data.GetDouble("s_iva"),
				data.GetDouble("c_iva")
				);
			return item;
		}

		public List<Tickets> get_tickets(string Fecha1, string Fecha2)
		{
			string query = "";
			if (Fecha1 == Fecha2)
			{
				query = "select tbatickets.id,tbatickets.total,  (select IFNULL(sum(((tbadetticket.pu-tbadetticket.costo)*tbadetticket.cantidad)),0) as ganancia from tbadetticket where tbadetticket.id_ticket=tbatickets.id), tbatickets.c_iva, tbatickets.s_iva from tbatickets where status='A' and DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') = '" + Fecha1 + "'";
			}
			else
			{
				query = "select tbatickets.id,tbatickets.total,  (select IFNULL(sum(((tbadetticket.pu-tbadetticket.costo)*tbadetticket.cantidad)),0) as ganancia from tbadetticket where tbadetticket.id_ticket=tbatickets.id), tbatickets.c_iva, tbatickets.s_iva from tbatickets where status='A' and DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' ";
			}
			
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = build_ticket(data);
					result.Add(item);
				}
			}
			return result;
		}

		
	}
}
