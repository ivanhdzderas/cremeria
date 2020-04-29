using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Det_salidas: ConnectDB
	{
		public int Id { get; set; }
		public int Id_salida { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double P_u { get; set; }
		public double Total { get; set; }

		public Det_salidas(
			int id,
			int id_salida,
			double cantidad,
			int id_producto,
			double p_u,
			double total
			)
		{
			Id = id;
			Id_salida = id_salida;
			Cantidad = cantidad;
			Id_producto = id_producto;
			P_u = p_u;
			Total = total;
		}
		public Det_salidas() { }

		private Det_salidas buildDetalles(MySqlDataReader data)
		{
			Det_salidas item = new Det_salidas(
				data.GetInt16("id"),
				data.GetInt16("id_salida"),
				data.GetDouble("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("p_u"),
				data.GetDouble("total")
				);
			return item;
		}

		public void craeteDet_salida()
		{
			string query = "insert into tbadetsalidas (id_salida, cantidad, id_producto, p_u, total) values (";
			query += "'" + this.Id_salida + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.P_u + "', ";
			query += "'" + this.Total + "'";
			query += ")";
			object rsult = runQuery(query);
		}

		public List<Det_salidas> getDet_salidas(int id)
		{
			string query = "select id, id_salida, cantidad, id_producto, p_u, total from tbadetsalidas where id_salida='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Det_salidas> result = new List<Det_salidas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_salidas item = buildDetalles(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
