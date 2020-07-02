using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
	
namespace caja.Models
{
	public class Facturas:ConnectDB
	{
		public int Id { get; set; }
		public int Folio { get; set; }
		public string Serie { get; set; }
		public int Cliente { get; set; }
		public double Subtotal { get; set; }
		public double Total { get; set; }
		public string Cadena { get; set; }
		public string Sello { get; set; }
		public string Uuid { get; set; }
		public string Estado { get; set; }
		public string Pago { get; set; }
		public  string Xml { get; set; }
		public string Id_invoi { get; set; }

		public Facturas(
			int id,
			int folio,
			string serie,
			int cliente,
			double subtotal,
			double total,
			string cadena,
			string sello,
			string uuid,
			string estado,
			string pago,
			string xml,
			string id_invoi
			)
		{
			Id = id;
			Folio = folio;
			Serie = serie;
			Cliente = cliente;
			Subtotal = subtotal;
			Total = total;
			Cadena = cadena;
			Sello = sello;
			Uuid = uuid;
			Estado = estado;
			Pago = pago;
			Xml = xml;
			Id_invoi = id_invoi;
		}

		public Facturas() { }

		private Facturas buildFacturas(MySqlDataReader data) {
			Facturas item = new Facturas(
				data.GetInt16("id"),
				data.GetInt16("folio"),
				data.GetString("serie"),
				data.GetInt16("id_cliente"),
				data.GetDouble("subtotal"),
				data.GetDouble("total"),
				data.GetString("cadena"),
				data.GetString("sello"),
				data.GetString("uuid"),
				data.GetString("estado"),
				data.GetString("pago"),
				data.GetString("xml"),
				data.GetString("id_invoice")
				);
			return item;
		}

		public void create()
		{
			string query = "INSERT INTO tbafacturas (folio,serie,id_cliente,subtotal,total,cadena_original,sello,uuid,status,pago,xml,id_invoice)VALUES(";
			query += "'" + this.Folio + "', ";
			query += "'" + this.Serie + "', ";
			query += "'" + this.Cliente + "', ";
			query += "'" + this.Subtotal + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Cadena + "', ";
			query += "'" + this.Sello + "', ";
			query += "'" + this.Uuid + "', ";
			query += "'" + this.Estado + "', ";
			query += "'" + this.Pago + "', ";
			query += "'" + this.Xml + "', ";
			query += "'" + this.Id_invoi + "')";
			object result = runQuery(query);
		}
		string maq_query= "SELECT id,folio,serie,id_cliente,subtotal,total,cadena_original,sello,uuid,status,pago,xml,id_invoice FROM tbafacturas";
		public List<Facturas> get_factura()
		{
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Facturas> result = new List<Facturas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Facturas item = buildFacturas(data);
					result.Add(item);
				}
			}
			return result;
		}



	}
}
