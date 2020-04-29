using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Det_transfers:ConnectDB
	{
		public int Id { get; set; }
		public int Folio { get; set; }
		public string Tipo { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double Precio { get; set; }
		public Det_transfers(
			int id, 
			int folio, 
			string tipo,
			double cantidad,
			int id_producto,
			double precio
			) {
			Id = id;
			Folio = folio;
			Tipo = tipo;
			Cantidad = cantidad;
			Id_producto = id_producto;
			Precio = precio;
		}
		public Det_transfers() { }

		public void CreateDet()
		{
			string query = "insert into tbadettrans(folio, tipo, cantidad, id_producto, precio) values (";
			query += "'" + this.Folio + "', ";
			query += "'" + this.Tipo + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Precio + "' ";
			query += ")";
			object result = runQuery(query);
		}
		private Det_transfers build_detalle(MySqlDataReader data)
		{
			Det_transfers item = new Det_transfers(
				data.GetInt16("id"),
				data.GetInt16("folio"),
				data.GetString("tipo"),
				data.GetDouble("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("precio")
				);
			return item;
		}
		static string maq_query = "SELECT id,folio,tipo,cantidad,id_producto,precio FROM tbadettrans";
		public List<Det_transfers> getDet_trans(int folio)
		{
			string query = maq_query + " where folio='" +  folio.ToString() + "'" ;
			MySqlDataReader data = runQuery(query);
			List<Det_transfers> result = new List<Det_transfers>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_transfers item = build_detalle(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
