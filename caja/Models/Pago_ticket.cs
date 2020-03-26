using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Pago_ticket:ConnectDB
	{
		public int Id { get; set; }
		public int Id_ticket { get; set; }
		public double Monto { get; set; }
		public string Tipo_pago { get; set; }

		public Pago_ticket(
			int id,
			int id_ticket,
			double monto,
			string tipo_pago
			) {
			Id = id;
			Id_ticket = id_ticket;
			Monto = monto;
			Tipo_pago = tipo_pago;
		}

		public Pago_ticket() { }

		public void CreatePago() {
			string query = "insert into tbapagticket (id_ticket, monto, tipo_pago) values ('" + this.Id_ticket + "', '" + this.Monto + "', '" + this.Tipo_pago + "')";
			object result = runQuery(query);
		}
		private Pago_ticket buildPago(MySqlDataReader data) {
			Pago_ticket item = new Pago_ticket(
				data.GetInt16("id"),
				data.GetInt16("id_ticket"),
				data.GetDouble("monto"),
				data.GetString("tipo_pago")
				);
			return item;
		}
		public List<Pago_ticket> get_pago(int id_ticket) {
			string query = "select id, id_ticket, monto, tipo_pago from tbapagticket where id_ticket='"  + id_ticket.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Pago_ticket> result = new List<Pago_ticket>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Pago_ticket item = buildPago(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
