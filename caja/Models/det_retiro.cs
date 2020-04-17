using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class det_retiro:ConnectDB
	{
		public int Id { get; set; }
		public int Id_retiro { get; set; }
		public int Billete { get; set; }
		public int Cantidad { get; set; }

		public det_retiro(
			int id,
			int id_retiro, 
			int billete,
			int cantidad
			)
		{
			Id = id;
			Id_retiro = id_retiro;
			Billete = billete;
			Cantidad = cantidad;
		}

		public det_retiro()
		{

		}

		private det_retiro builddet_retiro(MySqlDataReader data)
		{
			det_retiro item = new det_retiro(
				data.GetInt16("id"),
				data.GetInt16("id_retiro"),
				data.GetInt16("billete"),
				data.GetInt16("cantidad")
				);
			return item;
		}

		public void crate_det_retiro()
		{
			string query = "insert into det_retiro (id_retiro, billete, cantidad) values ('" + this.Id_retiro + "', '" + this.Billete + "', '" + this.Cantidad + "')";
			object result = runQuery(query);
		}

		public List<det_retiro> get_det_retiro(int id_ret)
		{
			string query = "select id, id_retiro, billete, cantidad from det_retiro where id_retiro='" + id_ret.ToString()  + "'";
			MySqlDataReader data = runQuery(query);
			List<det_retiro> result = new List<det_retiro>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_retiro item = builddet_retiro(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
