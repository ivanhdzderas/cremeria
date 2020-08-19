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
		public string Status { get; set; }
		public double S_iva { get; set; }
		public double C_iva { get; set; }
		public Tickets (
			string folio, 
			double total, 
			string status,
			double s_iva,
			double c_iva
			)
		{
			Folio = folio;
			Total = total;
			Status = status;
			S_iva = s_iva;
			C_iva = c_iva;
		}

		public Tickets() { 
		}

		private Tickets build_ticket(MySqlDataReader data)
		{
			Tickets item = new Tickets(
				data.GetString("folio"),
				data.GetDouble("total"),
				data.GetString("status"),
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
				query = "select tbatickets.folio,tbatickets.total, tbatickets.status,tbatickets.c_iva,tbatickets.s_iva  from tbatickets where status<>'G' and folio<>0 and DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') = '" + Fecha1 + "'";
			}
			else
			{
				//query = "select tbatickets.folio,tbatickets.total,(select IFNULL(sum(((tbadetticket.pu-tbadetticket.costo)*tbadetticket.cantidad)),0) from tbadetticket where tbadetticket.id_ticket=tbatickets.id) as ganancia, tbatickets.status,tbatickets.c_iva,tbatickets.s_iva  from tbatickets where status<>'G' and folio<>0 and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' ";
				query = "select tbatickets.folio,tbatickets.total, tbatickets.status,tbatickets.c_iva,tbatickets.s_iva  from tbatickets where status<>'G' and folio<>0 and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' ";
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
