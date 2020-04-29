using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Purchases:ConnectDB
	{
		public int Id { get; set; }
		public int Id_compra { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double P_u { get; set; }
		public double Total { get; set; }

		public Purchases(
			int id,
			int id_compra,
			double cantidad,
			int id_producto,
			double p_u,
			double total
			) {
			Id = id;
			Id_compra = id_compra;
			Cantidad = cantidad;
			Id_producto = id_producto;
			P_u = p_u;
			Total = total;
		}

		public Purchases() { }

		private Purchases buildPurchases(MySqlDataReader data) {
			Purchases item = new Purchases(
				data.GetInt16("id"),
				data.GetInt16("id_compra"),
				data.GetDouble("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("p_u"),
				data.GetDouble("total")
				);
			return item;
		}

		public void createPurchases() {
			string query = "insert into tbadetcompras (id_compra, cantidad, id_producto, p_u, total ) values (";
			query += "'" + this.Id_compra + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Id_producto +"', ";
			query += "'" + this.P_u + "', ";
			query += "'" + this.Total +"' ";
			query += ")";
			object result = runQuery(query);
		}

		public List<Purchases> getPurchases(int id)
		{
			string query = "select id, id_compra, cantidad, id_producto, p_u,total from tbadetcompras where id_compra='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Purchases> result = new List<Purchases>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Purchases item = buildPurchases(data);
					result.Add(item);
				}
			}
			return result;
		}
	}


}
