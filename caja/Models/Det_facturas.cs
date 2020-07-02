using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Det_facturas:ConnectDB
	{
		public int Id { get; set; }
		public int Factura { get; set; }
		public int Id_producto { get; set; }
		public double Cantidad { get; set; }
		public double P_u { get; set; }



		public Det_facturas(
			int id,
			int factura, 
			int id_producto,
			double cantidad, 
			double p_u
			)
		{
			Id = id;
			Factura = factura;
			Id_producto = id_producto;
			Cantidad = cantidad;
			P_u = p_u;
		}
		public Det_facturas()
		{

		}


		private Det_facturas build_Detalle(MySqlDataReader data)
		{
			Det_facturas item = new Det_facturas(
				data.GetInt16("id"),
				data.GetInt16("factura"),
				data.GetInt16("id_producto"),
				data.GetDouble("cantidad"),
				data.GetDouble("p_u")
				);
			return item;
		}

		public void create()
		{
			string query = "INSERT INTO tbadetfact (factura,id_producto,cantidad,p_u)VALUES(";
			query += "'" + this.Factura + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.P_u + "')";
			object result = runQuery(query);
		}

		string maq_query = "SELECT id,factura,id_producto,cantidad,p_u FROM tbadetfact";
		public List<Det_facturas> get_factura()
		{
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Det_facturas> result = new List<Det_facturas>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_facturas item = build_Detalle(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}