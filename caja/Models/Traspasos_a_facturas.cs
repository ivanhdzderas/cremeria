using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Traspasos_a_facturas: ConnectDB
	{
		public int Id { get; set; }
		public int Traspaso { get; set; }
		public int Factura { get; set; }

		public Traspasos_a_facturas(
			int id, 
			int traspaso, 
			int factura
			)
		{
			Id = id;
			Traspaso = traspaso;
			Factura = factura;
		}

		public Traspasos_a_facturas() {  }

		private Traspasos_a_facturas build_relacion(MySqlDataReader data)
		{
			Traspasos_a_facturas item = new Traspasos_a_facturas(
				data.GetInt16("id"),
				data.GetInt16("traspaso"),
				data.GetInt16("factura")
				);
			return item;
		}

		public void create_relacion()
		{
			string query = "insert into tbatrasafact (traspaso, factura	) values ('" + this.Traspaso + "', '" + this.Factura + "')";
			runQuery(query);
		}

		string maq_query = "select id,factura, traspaso from tbatrasafact";


		public List<Traspasos_a_facturas> get_realcionbyfactura(string factura)
		{
			string query = maq_query + " where factura='" + factura + "'";
			MySqlDataReader data = runQuery(query);
			List<Traspasos_a_facturas> result = new List<Traspasos_a_facturas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Traspasos_a_facturas item = build_relacion(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
