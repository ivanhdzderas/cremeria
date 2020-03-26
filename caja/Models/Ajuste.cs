using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Ajuste:ConnectDB
	{
		public int Id { get; set; }
		public string Fecha { get; set; }
		public double Total { get; set; }
		public string Notas { get; set; }
		public string Estado { get; set; }

		public Ajuste(
			int id,
			string fecha,
			double total,
			string notas,
			string estado
			) {
			Id = id;
			Fecha = fecha;
			Total = total;
			Notas = notas;
			Estado = estado;
		}

		public Ajuste() { }

		private Ajuste buildAjuste(MySqlDataReader data) {
			Ajuste item = new Ajuste(
				data.GetInt16("id"),
				data.GetString("fecha"),
				data.GetDouble("total"),
				data.GetString("notas"),
				data.GetString("estado")
				);
			return item;
		}

		public void createAjuste() {
			string query = "insert into tbaajuste (fecha, total, notas, estado) values (";
			query += "'" + this.Fecha + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Notas + "', ";
			query += "'" + this.Estado + "') ";
			object result = runQuery(query);
		}

		public List<Ajuste> getAjustes() {
			string query = "select id, fecha, total, notas, estado from tbaajuste ";
			MySqlDataReader data = runQuery(query);
			List<Ajuste> result = new List<Ajuste>();
			if (data.HasRows) {
				while (data.Read()) {
					Ajuste item = buildAjuste(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Ajuste> getAjustesbyId(int id)
		{
			string query = "select id, fecha, total, notas, estado from tbaajuste where id='" + id.ToString() + "' ";
			MySqlDataReader data = runQuery(query);
			List<Ajuste> result = new List<Ajuste>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ajuste item = buildAjuste(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Ajuste> getlastAjustes(string fecha, Double total)
		{
			string query = "select id, fecha, total, notas, estado from tbaajuste where fecha='" + fecha + "' and total='" + total.ToString() + "' ";
			MySqlDataReader data = runQuery(query);
			List<Ajuste> result = new List<Ajuste>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ajuste item = buildAjuste(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
