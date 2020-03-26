using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Venta_grupo:ConnectDB
	{
		public string Tipo { get; set; }
		public double Monto { get; set; }

		public Venta_grupo(
			string tipo,
			double monto
			)
		{
			Tipo = tipo;
			Monto = monto;
		}

		public Venta_grupo() { }
		private Venta_grupo buildVentas(MySqlDataReader data) {
			Venta_grupo item = new Venta_grupo(
				data.GetString("tipo"),
				data.GetDouble("monto")
				);
			return item;
		}
		public List<Venta_grupo> get_ventas() {
			DateTime thisDay = DateTime.Today;
			string query = "select tbadetticket.total as monto, tbagrupo.grupo as tipo from tbadetticket inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id	 inner join tbagrupo on tbaproductos.grupo=tbagrupo.id inner join tbatickets on tbadetticket.id_ticket=tbatickets.id where tbatickets.id_usuario='" + inicial.id_usario + "' and tbatickets.fecha like '%" + thisDay.ToString("yyyy-MM-dd") + "%' ";
			MySqlDataReader data = runQuery(query);
			List<Venta_grupo> result = new List<Venta_grupo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Venta_grupo item = buildVentas(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
