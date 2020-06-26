using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Uso_Cfdi : ConnectDB
	{
		public string Clave { get; set; }
		public string Descripcion { get; set; }
		public Uso_Cfdi(
			string clave,
			string descripcion
			) {
			Clave = clave;
			Descripcion = descripcion;
		}
		public Uso_Cfdi() { }

		private Uso_Cfdi build_uso(MySqlDataReader data) {
			Uso_Cfdi item = new Uso_Cfdi(
				data.GetString("clave"),
				data.GetString("descripcion")
				);
			return item;
		}

		public List<Uso_Cfdi> get_Usos()
		{
			string query = "select clave, descripcion from tbausocfdi";
			MySqlDataReader data = runQuery(query);
			List<Uso_Cfdi> result = new List<Uso_Cfdi>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Uso_Cfdi item = build_uso(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Uso_Cfdi> get_Usosbycodigo(string codigo)
		{
			string query = "select clave, descripcion from tbausocfdi where clave='" + codigo + "'";
			MySqlDataReader data = runQuery(query);
			List<Uso_Cfdi> result = new List<Uso_Cfdi>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Uso_Cfdi item = build_uso(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Uso_Cfdi> get_Usosbydescripcion( string descripcion)
		{
			string query = "select clave, descripcion from tbausocfdi where descripcion='" + descripcion + "'";
			MySqlDataReader data = runQuery(query);
			List<Uso_Cfdi> result = new List<Uso_Cfdi>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Uso_Cfdi item = build_uso(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
