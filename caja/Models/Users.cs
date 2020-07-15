using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace caja.Models
{
	public class Users : ConnectDB
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string User { get; set; }
		public string Pass { get; set; }
		public string Tipo { get; set; }
		

		public Users(
			int id,
			string nombre,
			string user,
			string pass,
			string tipo
			)
		{
			Id = id;
			Nombre = nombre;
			User = user;
			Pass = pass;
			Tipo = tipo;
		}

		public Users() { }

		private Users buildUser(MySqlDataReader data) {
			Users item = new Users(
				data.GetInt16("id_usuario"),
				data.GetString("nombre"),
				data.GetString("usser"),
				data.GetString("pass"),
				data.GetString("tipo")
				);
			return item;
		}


		public void createUser() {
			string query = "insert into tbausuario (nombre, usser, pass, tipo) values (";
			query += "'" + this.Nombre + "', ";
			query += "'" + this.User + "', ";
			query += "'" + this.Pass + "', ";
			query += "'" + this.Tipo + "') ";
			object rsult = runQuery(query);
		}
		public void saveUser() {
			string query = "update tbausuario set nombre='" + this.Nombre + "', usser='" + this.User + "', pass='" + this.Pass + "', tipo='" + this.Tipo + "' where id_usuario='" + this.Id + "'";
			object result = runQuery(query);
		}
		public List<Users> getUser(string user) {
			string query = "select id_usuario, nombre, usser, pass, tipo from tbausuario where usser='" + user + "'";
			MySqlDataReader data = runQuery(query);
			List<Users> result = new List<Users>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Users item = buildUser(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Users> getUserbyname(string name)
		{
			string query = "select id_usuario, nombre, usser, pass, tipo from tbausuario where nombre='" + name + "'";
			MySqlDataReader data = runQuery(query);
			List<Users> result = new List<Users>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Users item = buildUser(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Users> getInsertUser(string usuario, string pass) {
			string query = "select id_usuario, nombre, usser, pass, tipo from tbausuario where usser='" + usuario + "' and pass='" + pass + "'";
			MySqlDataReader data = runQuery(query);
			List<Users> result = new List<Users>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Users item = buildUser(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Users> getUsers()
		{
			string query = "select id_usuario, nombre, usser, pass, tipo from tbausuario ";
			MySqlDataReader data = runQuery(query);
			List<Users> result = new List<Users>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Users item = buildUser(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Users> getUserbyid(int id)
		{
			string query = "select id_usuario, nombre, usser, pass, tipo from tbausuario where id_usuario='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Users> result = new List<Users>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Users item = buildUser(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
