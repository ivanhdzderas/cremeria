using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Offices : ConnectDB
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Domicilio { get; set; }
		public string Telefono { get; set; }
		public string Servidor { get; set; }
		public string Connection { get; set; }
		public string Notas { get; set; }
		public string Factura { get; set; }
		public string Rfc { get; set; }
		public string Interior { get; set; }
		public string Exterior { get; set; }
		public string Calle { get; set; }
		public string Colonia { get; set; }
		public string Cp { get; set; }
		public string Municipio { get; set; }
		public string Estado { get; set; }
		public Offices(
			int id,
			string name,
			string domicilio,
			string telefono,
			string servidor,
			string connection,
			string notas,
			string factura,
			string rfc,
			string interior,
			string exterior,
			string calle,
			string colonia,
			string cp,
			string municipio,
			string estado
			) {
			Id = id;
			Name = name;
			Domicilio = domicilio;
			Telefono = telefono;
			Servidor = servidor;
			Connection = connection;
			Notas = notas;
			Factura = factura;
			Rfc = rfc;
			Interior = interior;
			Exterior = exterior;
			Calle = calle;
			Colonia = colonia;
			Cp = cp;
			Municipio = municipio;
			Estado = estado;
		}
		public Offices() { }
		public void CreateOffice() {
			string query = "insert into tbasucursales (nombre, domicilio, telefono, servidor, conect, notas, factura, rfc, interior, exterior, calle, colonia, cp, municipio, estado) values (";
			query += "'" + this.Name + "', ";
			query += "'" + this.Domicilio + "', ";
			query += "'" + this.Telefono + "', ";
			query += "'" + this.Servidor + "', ";
			query += "'" + this.Connection + "', ";
			query += "'" + this.Notas + "', ";
			query += "'" + this.Factura + "', ";
			query += "'" + this.Rfc + "', ";
			query += "'" + this.Interior + "', ";
			query += "'" + this.Exterior + "', ";
			query += "'" + this.Calle + "', ";
			query += "'" + this.Colonia + "', ";
			query += "'" + this.Cp + "', ";
			query += "'" + this.Municipio + "', ";
			query += "'" + this.Estado + "') ";
			object resulto = runQuery(query);
		}
		public void SaveOffice() {
			string query = "update tbasucursales set ";
			query += "name='" + this.Name + "', ";
			query += "domicilio='" + this.Domicilio + "', ";
			query += "telefono='" + this.Telefono + "', ";
			query += "servidor='" + this.Servidor + "', ";
			query += "conect='" + this.Connection + "', ";
			query += "notas='" + this.Notas + "', ";
			query += "factura='" + this.Factura + "', ";
			query += "rfc='" + this.Rfc + "', ";
			query += "interior='" + this.Interior + "', ";
			query += "exterior='" + this.Exterior + "', ";
			query += "calle='" + this.Calle + "', ";
			query += "colonia='" + this.Colonia + "', ";
			query += "cp='" + this.Cp + "', ";
			query += "municipio='" + this.Municipio + "', ";
			query += "estado='" + this.Estado + "' ";
			query += "where id='" + this.Id + "'";
			object resulto = runQuery(query);
		}
		private Offices buildOffice(MySqlDataReader data) {
			Offices item = new Offices(
				data.GetInt16("id"),
				data.GetString("nombre"),
				data.GetString("domicilio"),
				data.GetString("telefono"),
				data.GetString("servidor"),
				data.GetString("conect"),
				data.GetString("notas"),
				data.GetString("factura"),
				data.GetString("rfc"),
				data.GetString("interior"),
				data.GetString("exterior"),
				data.GetString("calle"),
				data.GetString("colonia"),
				data.GetString("cp"),
				data.GetString("municipio"),
				data.GetString("estado")
				);
			return item;
		}
		private string maq_query = "select id, nombre, domicilio, telefono, servidor, conect, notas, factura, rfc, interior, exterior, calle, colonia, cp, municipio, estado from tbasucursales";
		public List<Offices> GetOffices()
		{
			string query = maq_query;
			MySqlDataReader data = runQuery(query);
			List<Offices> result = new List<Offices>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Offices item = buildOffice(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Offices> GetOfficesbyid(int id)
		{
			string query = maq_query + " where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Offices> result = new List<Offices>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Offices item = buildOffice(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
