using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Compras:ConnectDB
	{
		public int Id { get; set; }
		public string Folio_doc { get; set; }
		public string Fecha { get; set; }
		public string Fecha_doc { get; set; }
		public string Proveedor { get; set; }
		public string Status { get; set; }
		public int Dias { get; set; }
		public string Fecha_credito { get; set; }
		public string Pagado { get; set; }
		public double Subtotal { get; set; }
		public double Iva { get; set; }
		public double Total { get; set; }
		public double Descuento { get; set; }

		public Compras(
			int id,
			string folio_doc,
			string fecha,
			string fecha_doc,
			string proveedor, 
			string status,
			int dias,
			string fecha_credito,
			string pagado,
			double subtotal,
			double iva,
			double total,
			double descuento
			) {
			Id = id;
			Folio_doc = folio_doc;
			Fecha = fecha;
			Fecha_doc = fecha_doc;
			Proveedor = proveedor;
			Status = status;
			Dias = dias;
			Fecha_credito = fecha_credito;
			Pagado = pagado;
			Subtotal = subtotal;
			Iva = iva;
			Total = total;
			Descuento = descuento;
		}
		public Compras() { }

		public void crateCompra() {
			string query = "insert into tbacompras (fecha, fecha_doc, id_proveedor, status, dias, fecha_credito, pagado, subtotal, iva, total, descuento, documento) values (";
			query += "'" + this.Fecha + "', ";
			query += "'" + this.Fecha_doc + "', ";
			query += "'" + this.Proveedor + "', ";
			query += "'" + this.Status + "', ";
			query += "'" + this.Dias + "', ";
			query += "'" + this.Fecha_credito + "', ";
			query += "'" + this.Pagado + "', ";
			query += "'" + this.Subtotal + "', ";
			query += "'" + this.Iva	 + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Descuento + "', ";
			query += "'" + this.Folio_doc + "') ";
			object result = runQuery(query);
		}

		public void pagar()
		{
			string query = "update tbacompras set pagado='SI' where id='" + this.Id + "'";
			object result = runQuery(query);
		}

		private Compras buildCompra(MySqlDataReader data) {
			Compras item = new Compras(
				data.GetInt16("id"),
				data.GetString("documento"),
				Convert.ToString(data.GetDateTime("fecha")),
				Convert.ToString(data.GetDateTime("fecha_doc")),
				data.GetString("proveedor"),
				data.GetString("status"),
				data.GetInt16("dias"),
				Convert.ToString(data.GetDateTime("fecha_credito")),
				data.GetString("pagado"),
				data.GetDouble("subtotal"),
				data.GetDouble("iva"),
				data.GetDouble("total"),
				data.GetDouble("descuento")
				) ;
			return item;
		}

		public List<Compras> GetCompras()
		{
			string query = "select tbacompras.id, tbacompras.fecha,tbacompras.documento ,  tbacompras.fecha_doc, tbaproveedores.nombre as proveedor ,tbacompras.status, tbacompras.dias, tbacompras.fecha_credito, tbacompras.pagado, tbacompras.subtotal, tbacompras.iva, tbacompras.total, tbacompras.descuento from tbacompras inner join tbaproveedores on tbacompras.id_proveedor=tbaproveedores.id";
			MySqlDataReader data = runQuery(query);
			List<Compras> result = new List<Compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Compras item = buildCompra(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Compras> GetlastCompras(string fecha, string fecha_doc, string proveedor,double total)
		{
			string query = "select tbacompras.id, tbacompras.documento, tbacompras.fecha, tbacompras.fecha_doc, tbaproveedores.nombre as proveedor ,tbacompras.status, tbacompras.dias, tbacompras.fecha_credito, tbacompras.pagado, tbacompras.subtotal, tbacompras.iva, tbacompras.total, tbacompras.descuento from tbacompras inner join tbaproveedores on tbacompras.id_proveedor=tbaproveedores.id";
			query += "  where tbacompras.fecha='" + fecha + "' and tbacompras.fecha_doc='" + fecha_doc + "' and tbacompras.id_proveedor='" + proveedor + "' and tbacompras.total='" + total.ToString() + "'";

			MySqlDataReader data = runQuery(query);
			List<Compras> result = new List<Compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Compras item = buildCompra(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Compras> getCompraByid(int id)
		{
			string query = "select tbacompras.id, tbacompras.fecha, tbacompras.documento, tbacompras.fecha_doc, tbaproveedores.nombre as proveedor ,tbacompras.status, tbacompras.dias, tbacompras.fecha_credito, tbacompras.pagado, tbacompras.subtotal, tbacompras.iva, tbacompras.total, tbacompras.descuento from tbacompras inner join tbaproveedores on tbacompras.id_proveedor=tbaproveedores.id";
			query += "  where tbacompras.id='" + id + "'";

			MySqlDataReader data = runQuery(query);
			List<Compras> result = new List<Compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Compras item = buildCompra(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Compras> getCompra_sin_pagar(string proveedor)
		{
			string query = "select tbacompras.id, tbacompras.fecha, tbacompras.documento, tbacompras.fecha_doc, tbaproveedores.nombre as proveedor ,tbacompras.status, tbacompras.dias, tbacompras.fecha_credito, tbacompras.pagado, tbacompras.subtotal, tbacompras.iva, tbacompras.total, tbacompras.descuento from tbacompras inner join tbaproveedores on tbacompras.id_proveedor=tbaproveedores.id";
			query += "  where tbaproveedores.id='" + proveedor + "' and tbacompras.pagado='NO'";

			MySqlDataReader data = runQuery(query);
			List<Compras> result = new List<Compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Compras item = buildCompra(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Compras> getCompras_sin_pagar()
		{
			string query = "select tbacompras.id, tbacompras.fecha,  tbacompras.documento, tbacompras.fecha_doc, tbaproveedores.nombre as proveedor ,tbacompras.status, tbacompras.dias, tbacompras.fecha_credito, tbacompras.pagado, tbacompras.subtotal, tbacompras.iva, tbacompras.total, tbacompras.descuento from tbacompras inner join tbaproveedores on tbacompras.id_proveedor=tbaproveedores.id";
			query += "  where tbacompras.pagado='NO' and fecha_credito  BETWEEN CONCAT(DATE_SUB(CURDATE(),INTERVAL 3 DAY),'  00:00:00') AND CONCAT(DATE_ADD(CURDATE(),INTERVAL 3 DAY),' 00:00:00')";

			MySqlDataReader data = runQuery(query);
			List<Compras> result = new List<Compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Compras item = buildCompra(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
