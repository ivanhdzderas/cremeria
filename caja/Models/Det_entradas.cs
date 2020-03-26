using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Det_entradas:ConnectDB
	{
		public int Id { get; set; }
		public int Id_entrada { get; set; }
		public int Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double P_u { get; set; }
		public double Total { get; set; }

		public Det_entradas(
			int id,
			int id_entrada,
			int cantidad,
			int id_producto,
			double p_u,
			double total
			)
		{
			Id = id;
			Id_entrada = id_entrada;
			Cantidad = cantidad;
			Id_producto = id_producto;
			P_u = p_u;
			Total = total;
		}
		public Det_entradas() { }

		private Det_entradas buildDetalles(MySqlDataReader data) {
			Det_entradas item = new Det_entradas(
				data.GetInt16("id"),
				data.GetInt16("id_entrada"),
				data.GetInt16("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("p_u"),
				data.GetDouble("total")
				);
			return item;
		}

		public void craeteDet_entrada() {
			string query = "insert into tbadetentradas (id_entrada, cantidad, id_producto, p_u, total) values (";
			query += "'" + this.Id_entrada + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.P_u + "', ";
			query += "'" + this.Total + "'";
			query += ")";
			object rsult = runQuery(query);
		}
		public List<Det_entradas> getDet_entradas(int id) {
			string query = "select id, id_entrada, cantidad, id_producto, p_u, total from tbadetentradas where id_entrada='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Det_entradas> result = new List<Det_entradas>();
			if (data.HasRows) {
				while (data.Read()) {
					Det_entradas item = buildDetalles(data);
					result.Add(item);
				}
			}
			return result;
		}


	}
}
