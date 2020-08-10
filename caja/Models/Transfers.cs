using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace caja.Models
{
	public class Transfers : ConnectDB
	{
		public int Id { get; set; }
		public int Folio { get; set; }
		public string Tipo_trapaso { get; set; }
		public string Sucursal { get; set; }
		public double Subtotal { get; set; }
		public double Iva { get; set; }
		public double Total { get; set; }
		public DateTime Fecha { get; set; }
		public int Facturado { get; set; }

		public Transfers(
			int id,
			int folio,
			string tipo_trapaso,
			string sucursal,
			double subtotal,
			double iva,
			double total,
			DateTime fecha,
			int facturado)
		{

			Id = id;
			Folio = folio;
			Tipo_trapaso = tipo_trapaso;
			Sucursal = sucursal;
			Subtotal = subtotal;
			Iva = iva;
			Total = total;
			Fecha = fecha;
			Facturado = facturado;
		}
		public Transfers() { }
	
		public void CreateTransfer()
		{
			string query = "insert into tbatraspasos (folio, tipo, sucursal, subtotal, iva, total, fecha, facturado) values (";
			query += "'" + this.Folio + "', ";
			query += "'" + this.Tipo_trapaso + "', ";
			query += "'" + this.Sucursal + "', ";
			query += "'" + this.Subtotal + "', ";
			query += "'" + this.Iva + "', ";
			query += "'" + this.Total + "', ";
			query += "NOW(), ";
			query += "'" + this.Facturado + "'";
			query += ")";
			object result = runQuery(query);
		}
		private Transfers build_transfer(MySqlDataReader data)
		{
			Transfers item = new Transfers(
				data.GetInt16("id"),
				data.GetInt16("folio"),
				data.GetString("tipo"), 
				data.GetString("sucursal"),
				data.GetDouble("subtotal"),
				data.GetDouble("iva"),
				data.GetDouble("total"),
				data.GetDateTime("fecha"),
				data.GetInt16("facturado")
				);
			return item;
		}
		static string maq_query = "SELECT id,folio,tipo,sucursal,subtotal,iva,total,fecha,facturado FROM tbatraspasos";
		public List<Transfers> getTransfers()
		{
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Transfers> result = new List<Transfers>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Transfers item = build_transfer(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Transfers> getTransferbyid(int id)
		{
			string query = maq_query + " where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Transfers> result = new List<Transfers>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Transfers item = build_transfer(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Transfers> getTransferbysucursal(int id_sucursal)
		{
			string query = maq_query + " where sucursal='" + id_sucursal + "' and tipo='E'";
			MySqlDataReader data = runQuery(query);
			List<Transfers> result = new List<Transfers>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Transfers item = build_transfer(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Transfers> getTransferbyfolio(int folio, string tipo)
		{
			string query = maq_query + " where folio='" + folio.ToString() + "' and tipo='" + tipo + "'";
			MySqlDataReader data = runQuery(query);
			List<Transfers> result = new List<Transfers>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Transfers item = build_transfer(data);
					result.Add(item);
				}
			}
			return result;
		}

		

		

	}
}
