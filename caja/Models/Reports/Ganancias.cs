using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Ganancias:ConnectDB
	{
		public string Producto { get; set; }
		public double Costo { get; set; }
		public double Ganancia { get; set; }
		public double Bruto { get; set; }
		public Ganancias(
			string producto, 
			double costo, 
			double ganancia, 
			double bruto
			) {
			Producto = producto;
			Costo = costo;
			Ganancia = ganancia;
			Bruto = bruto;
		}

		public Ganancias() { }
		private Ganancias buildganancia(MySqlDataReader data)
		{
			Ganancias item = new Ganancias(
				data.GetString("descripcion"),
				data.GetDouble("costo"),
				data.GetDouble("ganancia"),
				data.GetDouble("bruto")
				);
			return item;
		}
		public List<Ganancias> getganancias(string fecha_inicial, string fecha_final)
		{
			string query = "select tbaproductos.descripcion, tbadetticket.costo, (tbadetticket.pu-tbadetticket.costo) as ganancia, ((tbadetticket.pu-tbadetticket.costo)*tbadetticket.cantidad) as bruto from tbadetticket inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id inner join tbatickets on tbadetticket.id_ticket=tbatickets.id where DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + fecha_inicial + "' and  '" + fecha_final + "'";
			MySqlDataReader data = runQuery(query);
			List<Ganancias> result = new List<Ganancias>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ganancias item = buildganancia(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
