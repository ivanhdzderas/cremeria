using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Tickets:ConnectDB
	{
		public int Id { get; set; }
		public int Id_cliente { get; set; }
		public string Fecha { get; set; }
		public double Subtotal { get; set; }
		public double Descuento { get; set; }
		public double Iva { get; set; }
		public double Total { get; set; }
		public string Status { get; set; }
		public double C_iva { get; set; }
		public double S_iva { get; set; }
		public int Id_usuario { get; set; }
		public Tickets(
			int id,
			int id_cliente,
			string fecha, 
			double subtotal,
			double descuento,
			double iva,
			double total,
			string status,
			double c_iva,
			double s_iva,
			int id_usuario
			) {
			Id = id;
			Id_cliente = id_cliente;
			Fecha = fecha;
			Subtotal = subtotal;
			Descuento = descuento;
			Iva = iva;
			Total = total;
			Status = status;
			C_iva = c_iva;
			S_iva = s_iva;
			Id_usuario = id_usuario;

		}
		public Tickets() { }

		public void CreateTicket()
		{
			string query = "insert into tbatickets (id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario) values (";
			query += "'" + this.Id_cliente + "', ";
			query += "'" + this.Fecha + "', ";
			query += "'" + this.Subtotal + "', ";
			query += "'" + this.Descuento + "', ";
			query += "'" + this.Iva + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Status + "', ";
			query += "'" + this.C_iva + "', ";
			query += "'" + this.S_iva + "', ";
			query += "'" + this.Id_usuario + "')";

			object result = runQuery(query);
		}
		private Tickets buildTicket(MySqlDataReader data) {
			Tickets item = new Tickets(
				data.GetInt16("id"),
				data.GetInt16("id_cliente"),
				data.GetString("fecha"),
				data.GetDouble("subtotal"),
				data.GetDouble("descuento"),
				data.GetDouble("iva"),
				data.GetDouble("total"),
				data.GetString("status"),
				data.GetDouble("c_iva"),
				data.GetDouble("s_iva"),
				data.GetInt16("id_usuario")
				);
			return item;
		}

		public List<Tickets> getTickets() {
			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario from tbatickets";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsbyId(int id)
		{
			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario from tbatickets where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsToday(string fecha)
		{
			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva,id_usuario from tbatickets where fecha like '%" + fecha + "%'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsbyFechas(string fecha1, string fecha2)
		{
			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva,id_usuario from tbatickets where fecha BETWEEN '" + fecha1 + "' and '" + fecha2 + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getLastTicket(string fecha, double subtotal, double descuento, double iva, double total, int cliente)
		{
			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario from tbatickets where fecha='" + fecha + "' and subtotal='" + subtotal.ToString() + "' and iva='" + iva.ToString() + "' and descuento='" + descuento.ToString() + "' and total='" + total.ToString() + "' and id_cliente='" + cliente + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Tickets> getbyUser(int id_perosna)
		{
			DateTime thisDay = DateTime.Today;

			string query = "select id, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario from tbatickets where id_usuario='" + id_perosna.ToString() + "' and fecha like '%" + thisDay.ToString("yyyy-MM-dd") + "%'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
