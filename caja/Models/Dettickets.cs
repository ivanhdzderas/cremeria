using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Dettickets:ConnectDB
	{
		public int Id { get; set; }
		public string Fecha { get; set; }
		public int Id_ticket { get; set; }
		public int Id_producto { get; set; }
		public string Descripcion { get; set; }
		public double Cantidad { get; set; }
		public double Descuento { get; set; }
		public double Pu { get; set; }
		public double Total { get; set; }
		public string Grabado { get; set; }
		public Dettickets(
			int id,
			string fecha,
			int id_ticket,
			int id_producto, 
			string descripcion,
			double cantidad,
			double descuento,
			double pu,
			double total,
			string grabado
			) {
			Id = id;
			Fecha = fecha;
			Id_ticket = id_ticket;
			Id_producto = id_producto;
			Descripcion = descripcion;
			Cantidad = cantidad;
			Descuento = descuento;
			Pu = pu;
			Total = total;
			Grabado = grabado;
		}

		public Dettickets() { }

		public void CrateDetTicket()
		{
			string query = "insert into tbadetticket (fecha, id_ticket, id_producto, descripcion, cantidad,descuento, pu, total, grabado) values (";
			query += "'" + this.Fecha + "', ";
			query += "'" + this.Id_ticket + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Descripcion + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Descuento + "', ";
			query += "'" + this.Pu + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Grabado + "') ";
			object result = runQuery(query);
		}
		private Dettickets buildDetalles(MySqlDataReader data) {
			Dettickets item = new Dettickets(
				data.GetInt16("id"),
				data.GetString("fecha"),
				data.GetInt16("id_ticket"),
				data.GetInt16("id_producto"),
				data.GetString("descripcion"),
				data.GetDouble("cantidad"),
				data.GetDouble("descuento"),
				data.GetDouble("pu"),
				data.GetDouble("total"),
				data.GetString("grabado")
				);
			return item;
		}
		public List<Dettickets> getDetalles(int id) {
			string query = "select id, fecha, id_ticket, id_producto, descripcion, cantidad,descuento, pu, total, grabado from tbadetticket  where id_ticket='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Dettickets> result = new List<Dettickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Dettickets item = buildDetalles(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
