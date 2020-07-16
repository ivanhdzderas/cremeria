using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Devolutions:ConnectDB
	{
		public int Id { get; set; }
		public string Fecha { get; set; }
		public int Autorizo { get; set; }
		public double Total { get; set; }
		public Devolutions(
			int id, 
			string fecha, 
			int autorizo,
			double total
			) {
			Id = id;
			Fecha = fecha;
			Autorizo = autorizo;
			Total = total;
		}

		public Devolutions() { }

		private Devolutions buildDevolution(MySqlDataReader data)
		{
			Devolutions item = new Devolutions(
				data.GetInt16("id"),
				data.GetString("fecha"),
				data.GetInt16("autorizo"),
				data.GetDouble("total")
				);
			return item;
		}

		public void create()
		{
			string query = "insert into tbadevoluciones (fecha, autorizo, total) values ('"+this.Fecha+"', '"+this.Autorizo+"', '"+this.Total+"')";
			object result = runQuery(query);
		}

		public List<Devolutions> get_devoluciones()
		{
			string query = "select id, fecha, autorizo, total from tbadevoluciones";
			MySqlDataReader data = runQuery(query);
			List<Devolutions> result = new List<Devolutions>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Devolutions item = buildDevolution(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Devolutions> get_devolucionesbyid( int id)
		{
			string query = "select id, fecha, autorizo, total from tbadevoluciones where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Devolutions> result = new List<Devolutions>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Devolutions item = buildDevolution(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Devolutions> get_lastdevocion(string fecha, int autorizo, double total)
		{
			string query = "select id, fecha, autorizo, total from tbadevoluciones where fecha='" + fecha + "' and autorizo='" + autorizo.ToString() + "' and total='"+ total.ToString() +"'";
			MySqlDataReader data = runQuery(query);
			List<Devolutions> result = new List<Devolutions>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Devolutions item = buildDevolution(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
