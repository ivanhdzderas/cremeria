using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Ticket_a_facturas:ConnectDB
	{
		public int Id { get; set; }
		public int Factura { get; set; }
		public int Ticket { get; set; }

		public Ticket_a_facturas(
			int id, 
			int factura, 
			int ticket
			) {
			Id = id;
			Factura = factura;
			Ticket = ticket;
		}

		public Ticket_a_facturas()
		{
		}

		private Ticket_a_facturas build_relacion(MySqlDataReader data) {
			Ticket_a_facturas item = new Ticket_a_facturas(
				data.GetInt16("id"),
				data.GetInt16("factura"),
				data.GetInt16("ticket")
				) ;
			return item;
		}

		public void createrelacion()
		{
			string query = "insert into tbatickafact (factura, ticket) values ('" + this.Factura + "', '" + this.Ticket + "')";
			runQuery(query);
		}
		string maq_query = "select id,factura, ticket from tbatickafact";

		public List<Ticket_a_facturas> get_realcionbyfactura(string factura)
		{
			string query = maq_query + " where factura='" + factura + "'";
			MySqlDataReader data = runQuery(query);
			List<Ticket_a_facturas> result = new List<Ticket_a_facturas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ticket_a_facturas item = build_relacion(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Ticket_a_facturas> get_realcionbyticket(string ticket)
		{
			string query = maq_query + " where ticket='" + ticket + "'";
			MySqlDataReader data = runQuery(query);
			List<Ticket_a_facturas> result = new List<Ticket_a_facturas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ticket_a_facturas item = build_relacion(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
