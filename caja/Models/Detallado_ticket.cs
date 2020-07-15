using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Detallado_ticket:ConnectDB
	{
		public int Folio { get; set; }
		public string Fecha { get; set; }
		public int Cantidad { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public double Total { get; set; }

		public Detallado_ticket(
			int folio, 
			string fecha, 
			int cantidad, 
			string codigo, 
			string descripcion, 
			double total
			) {
			Folio = folio;
			Fecha = fecha;
			Cantidad = cantidad;
			Codigo = codigo;
			Descripcion = descripcion;
			Total = total;
		}

		public Detallado_ticket() { }

		private Detallado_ticket build_detallado(MySqlDataReader data) {
			Detallado_ticket item = new Detallado_ticket(
				data.GetInt16("folio"),
				data.GetString("fecha"),
				data.GetInt16("cantidad"),
				data.GetString("codigo"),
				data.GetString("descripcion"),
				data.GetDouble("total")
				);
			return item;
		}

		public List<Detallado_ticket> get_detallado(string fecha_inicial, string fecha_final, int cliente)
		{
			string query = "select tbadetticket.id_ticket as folio, tbadetticket.cantidad, tbadetticket.total, tbatickets.fecha,tbaproductos.codigo, tbaproductos.descripcion  from tbadetticket inner join tbatickets on tbadetticket.id_ticket=tbatickets.id inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id where  tbatickets.id_cliente='" + cliente.ToString() + "' and DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + fecha_inicial + "' and  '" + fecha_final + "' ";
			MySqlDataReader data = runQuery(query);
			List<Detallado_ticket> result = new List<Detallado_ticket>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Detallado_ticket item = build_detallado(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
