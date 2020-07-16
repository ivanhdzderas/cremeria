using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace caja.Models
{
	public class Caducidades : ConnectDB
	{
		public int Id { get; set; }
		public int Id_producto {get;set;}
		public double Cantidad { get; set; }
		public string Caducidad { get; set; }
		public string Lote { get; set; }
		public int Id_compra { get; set; }
		public Caducidades(
			int id,
			int id_producto,
			double cantidad,
			string caducidad,
			string lote	,
			int id_compra	
			)
		{
			Id = id;
			Id_producto = id_producto;
			Cantidad = cantidad;
			Caducidad = caducidad;
			Lote = lote;
			Id_compra = id_compra;
		}

		public Caducidades() { }

		private Caducidades buildCaduciddes(MySqlDataReader data) {
			Caducidades item = new Caducidades(
				data.GetInt16("id"),
				data.GetInt16("id_producto"),
				data.GetDouble("cantidad"),
				data.GetString("caducidad"),
				data.GetString("lote"),
				data.GetInt16("id_compra")
				);
			return item;
		}
		public void createCaducidad() {
			string query = "insert into tbacaducidad (id_producto, cantidad, caducidad,lote , id_compra ) values (";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Caducidad + "', ";
			query += "'" + this.Lote + "', ";
			query += "'" + this.Id_compra + "' ";
			query += ")";
			object result = runQuery(query);
		}
		public List<Caducidades> GetCaducidades(int id) {
			string query = "select id, id_producto, cantidad, caducidad, lote, id_compra from tbacaducidad where id_producto='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Caducidades> result = new List<Caducidades>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Caducidades item = buildCaduciddes(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Caducidades> GetCaducidadesbyCompra(int id_compra, int id_producto)
		{
			string query = "select id, id_producto, cantidad, caducidad, lote, id_compra from tbacaducidad where id_compra='" + id_compra.ToString() + "' and id_producto='" + id_producto.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Caducidades> result = new List<Caducidades>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Caducidades item = buildCaduciddes(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
