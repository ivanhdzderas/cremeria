using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class retiro_efectivo:ConnectDB
	{
		public int Id { get; set; }
		public double Monto { get; set; }
		public int Usuario { get; set; }
		public string Fecha { get; set; }
		public retiro_efectivo(
			int id,
			double monto,
			int usuario,
			string fecha
			) {
			Id = id;
			Monto = monto;
			Usuario = usuario;
			Fecha = fecha;
		}

		public retiro_efectivo() { }

		private retiro_efectivo buildretiro(MySqlDataReader data)
		{
			retiro_efectivo item = new retiro_efectivo(
				data.GetInt16("id"),
				data.GetDouble("monto"),
				data.GetInt16("usuario"),
				data.GetString("fecha")
				);
			return item;
		}
		public void createRetiro()
		{
			string query = "insert into retiros (monto, usuario, fecha) values ('" + this.Monto + "', '" + this.Usuario + "', NOW())";
			object result = runQuery(query);
		}
		public List<retiro_efectivo> get_retirosbyuser(int user)
		{
			string query = "select id, monto, usuario, fecha from retiros where usuario='" + user.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<retiro_efectivo> get_lastretiro(int user)
		{
			string query = "select id, monto, usuario, fecha from retiros where usuario='" + user.ToString() + "' order by id desc";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<retiro_efectivo> get_retirostoday()
		{
			string fecha=DateTime.Now.ToString("yyyy-MM-dd");
			string query = "select id, monto, usuario, fecha from retiros where fecha like '%" + fecha + "%'";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
