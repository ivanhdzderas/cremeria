using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Folios:ConnectDB
	{
		public int Transferencia { get; set; }
		public int Pagos { get; set; }
		public int Facturas { get; set; }
		public int Ticket { get; set; }
		public string Serie { get; set; }
		public Folios(
			int transferencia,
			int pagos,
			int facturas,
			int ticket,
			string serie) 
		{
			Transferencia = transferencia;
			Pagos = pagos;
			Facturas = facturas;
			Ticket = ticket;
			Serie = serie;
		}
		public Folios() { }

		public Folios build_folio(MySqlDataReader data)
		{
			Folios item = new Folios(
				data.GetInt16("transf"),
				data.GetInt16("pagos"),
				data.GetInt16("factura"),
				data.GetInt16("Ticket"),
				data.GetString("serie")
				);
			return item;
		}
		public void saveticket()
		{
			string query = "update tbafolios set ticket='" + this.Ticket + "'";
			object result = runQuery(query);
		}
		public void savenewTransfer()
		{
			string query = "update tbafolios set transf='" + this.Transferencia + "'";
			object result = runQuery(query);
		}
		public void savePagos()
		{
			string query = "update tbafolios set pagos='" + this.Pagos + "'";
			object result = runQuery(query);
		}
		public void saveFacturas()
		{
			string query = "update tbafolios set factura=factura+1";
			object result = runQuery(query);
		}
		public List<Folios> getFolios()
		{
			string query = "select transf, pagos, factura,ticket, serie from tbafolios";
			MySqlDataReader data = runQuery(query);
			List<Folios> result = new List<Folios>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Folios item = build_folio(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
