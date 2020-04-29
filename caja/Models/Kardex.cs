using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace caja.Models
{
	public class Kardex:ConnectDB
	{
		public int Id { get; set; }
		public int Id_producto { get; set; }
		public string Tipo { get; set; }
		public int Id_documento { get; set; }
		public  double Cantidad { get; set; }
		public int Antes { get; set; }
		public string Fecha { get; set; }
		public Kardex(
			int id,
			int id_producto,
			string tipo,
			int id_documento,
			double cantidad,
			int antes,
			string fecha
			)
		{
			Id = id;
			Id_producto = id_producto;
			Tipo = tipo;
			Id_documento = id_documento;
			Cantidad = cantidad;
			Antes = antes;
			Fecha = fecha;
		}
		public Kardex() { }

		private Kardex buildKardex(MySqlDataReader data) {
			Kardex item = new Kardex(
				data.GetInt16("id"),
				data.GetInt16("id_producto"),
				data.GetString("tipo_movimiento"),
				data.GetInt16("id_documento"),
				data.GetDouble("cantidad"),
				data.GetInt16("antes"),
				data.GetString("fecha")
				);
			return item;
		}
		public void CreateKardex() {
			string query = "insert into tbakardex (id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha ) values (";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Tipo + "', ";
			query += "'" + this.Id_documento + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Antes + "', ";
			query += "curdate()";
			query += ")";
			object result = runQuery(query);
		}

		public List<Kardex> getKardex(int id_producto) {
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id_producto='" + id_producto.ToString() + "' order by id";
			MySqlDataReader data = runQuery(query);
			List<Kardex> result = new List<Kardex>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Kardex> getidKardex(int id_producto, int id_documento, string tipo)
		{
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id_producto='" + id_producto.ToString() + "' and id_documento='" + id_documento + "' and tipo_movimiento='" + tipo + "'";
			MySqlDataReader data = runQuery(query);
			List<Kardex> result = new List<Kardex>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Kardex> getkardexbyid(int id)
		{
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Kardex> result = new List<Kardex>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
