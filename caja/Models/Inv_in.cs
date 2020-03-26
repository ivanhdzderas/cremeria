using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Inv_in:ConnectDB
	{
		public int Id { get; set; }
		public string Date { get; set; }
		public string Note { get; set; }
		public double Total { get; set; }
		public string Status { get; set; }
		public Inv_in(
			int id,
			string date,
			string note,
			double total,
			string status
			)
		{
			Id = id;
			Date = date;
			Note = note;
			Total = total;
			Status = status;
		}
		public Inv_in() { }

		public void createInv_in() {
			string query = "insert into tbainventrada (fecha,notas, total,  Estado) values (";
			query += "'" + this.Date + "', ";
			query += "'" + this.Note + "', ";
			query += "'" + this.Total.ToString() + "',";
			query += "'" + this.Status + "'";
			query += ")";
			object result = runQuery(query);
		}

		private Inv_in buildInv_in(MySqlDataReader data) {
			Inv_in item = new Inv_in(
				data.GetInt16("id"),
				data.GetString("fecha"),
				data.GetString("notas"),
				data.GetDouble("total"),
				data.GetString("Estado")
				);
			return item;
		}
		public string maq_query = "select id, fecha, notas, total, Estado from tbainventrada";
		public List<Inv_in> getLista() {
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Inv_in> result = new List<Inv_in>();
			if (data.HasRows) {
				while (data.Read()) {
					Inv_in item = buildInv_in(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Inv_in> getListabyId(string id)
		{
			string query = maq_query + " where id='" + id + "'";
			MySqlDataReader data = runQuery(query);
			List<Inv_in> result = new List<Inv_in>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Inv_in item = buildInv_in(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Inv_in> getListabyAll(string fecha, double total )
		{
			string query = maq_query + " where fecha='" + fecha + "' and total='" + total.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Inv_in> result = new List<Inv_in>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Inv_in item = buildInv_in(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
