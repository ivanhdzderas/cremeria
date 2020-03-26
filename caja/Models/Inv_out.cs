using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Inv_out:ConnectDB
	{
		public int Id { get; set; }
		public string Date { get; set; }
		public string Note { get; set; }
		public double Total { get; set; }
		public string Status { get; set; }

		public Inv_out(
			int id,
			string date,
			string note,
			double total,
			string status
			) {
			Id = id;
			Date = date;
			Note = note;
			Total = total;
			Status = status;
		}

		public Inv_out() { }

		public void createInv_out()
		{
			string query = "insert into tbainvsalidas (fecha,notas, total,  Estado) values (";
			query += "'" + this.Date + "', ";
			query += "'" + this.Note + "', ";
			query += "'" + this.Total.ToString() + "',";
			query += "'" + this.Status + "'";
			query += ")";
			object result = runQuery(query);
		}

		private Inv_out buildInv_out(MySqlDataReader data)
		{
			Inv_out item = new Inv_out(
				data.GetInt16("id"),
				data.GetString("fecha"),
				data.GetString("notas"),
				data.GetDouble("total"),
				data.GetString("Estado")
				);
			return item;
		}


		public string maq_query = "select id, fecha, notas, total, Estado from tbainvsalidas";
		public List<Inv_out> getLista()
		{
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Inv_out> result = new List<Inv_out>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Inv_out item = buildInv_out(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Inv_out> getListabyId(string id)
		{
			string query = maq_query + " where id='" + id + "'";
			MySqlDataReader data = runQuery(query);
			List<Inv_out> result = new List<Inv_out>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Inv_out item = buildInv_out(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Inv_out> getListabyAll(string fecha, double total)
		{
			string query = maq_query + " where fecha='" + fecha + "' and total='" + total.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Inv_out> result = new List<Inv_out>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Inv_out item = buildInv_out(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
