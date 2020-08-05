using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Mas_vendidos:ConnectDB
	{
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public double Cantidad { get; set; }

		public Mas_vendidos(
			string codigo,
			string descripcion,
			double cantidad)
		{
			Codigo = codigo;
			Descripcion = descripcion;
			Cantidad = cantidad;
		}

		public Mas_vendidos()
		{

		}

		private Mas_vendidos Build_vendidos(MySqlDataReader data)
		{
			Mas_vendidos item = new Mas_vendidos(
				data.GetString("codigo"),
				data.GetString("descripcion"),
				data.GetDouble("cantidad")
				);
			return item;
		}
		public List<Mas_vendidos> get_masvendidos(string Fecha1, string Fecha2)
		{
			string query = "";
			if (Fecha1 == Fecha2)
			{
				query = "select sum(tbadetticket.cantidad) as cantidad, tbadetticket.descripcion, tbaproductos.codigo from tbadetticket inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id inner join tbatickets on tbadetticket.id_ticket=tbatickets.id where  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d')='" + Fecha1 + "' GROUP by tbadetticket.id_producto order by cantidad DESC limit 5";
			}
			else
			{
				query = "select sum(tbadetticket.cantidad) as cantidad, tbadetticket.descripcion, tbaproductos.codigo from tbadetticket inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id inner join tbatickets on tbadetticket.id_ticket=tbatickets.id where  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN '" + Fecha1 + "' and '" + Fecha2 + "' GROUP by tbadetticket.id_producto order by cantidad DESC limit 5";
			}
			MySqlDataReader data = runQuery(query);
			List<Mas_vendidos> result = new List<Mas_vendidos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Mas_vendidos item = Build_vendidos(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
