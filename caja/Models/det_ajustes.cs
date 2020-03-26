using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class det_ajustes:ConnectDB
	{
		public int Id { get; set; }
		public int Id_ajuste { get; set; }
		public int Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double P_u { get; set; }
		public double Total { get; set; }

		public det_ajustes(
			int id,
			int id_ajuste,
			int cantidad,
			int id_producto,
			double p_u,
			double total
			)
		{
			Id = id;
			Id_ajuste = id_ajuste;
			Cantidad = cantidad;
			Id_producto = id_producto;
			P_u = p_u;
			Total = total;
		}

		public det_ajustes() { }

		private det_ajustes buildDetalles(MySqlDataReader data)
		{
			det_ajustes item = new det_ajustes(
				data.GetInt16("id"),
				data.GetInt16("id_ajuste"),
				data.GetInt16("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("p_u"),
				data.GetDouble("total")
				);
			return item;
		}

		public void craeteDet_ajuste()
		{
			string query = "insert into tbadetajustes (id_ajuste, cantidad, id_producto, p_u, total) values (";
			query += "'" + this.Id_ajuste + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.P_u + "', ";
			query += "'" + this.Total + "'";
			query += ")";
			object rsult = runQuery(query);
		}

		public List<det_ajustes> getDet_ajustes(int id)
		{
			string query = "select id, id_ajuste, cantidad, id_producto, p_u, total from tbadetajustes where id_ajuste='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<det_ajustes> result = new List<det_ajustes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_ajustes item = buildDetalles(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
