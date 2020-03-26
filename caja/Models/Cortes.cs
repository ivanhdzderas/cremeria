using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Cortes:ConnectDB
	{
		public int Id { get; set; }
		public int Id_usuario { get; set; }
		public DateTime Fecha { get; set; }
		public double Caja_inicial { get; set; }
		public double Caja_fin { get; set; }
		public DateTime Fecha_corte { get; set; }
		public double Diferencia { get; set; }
		public Boolean Terminado { get; set; }
		public Cortes(
			int id,
			int id_usuario,
			DateTime fecha, 
			double caja_inicial,
			double caja_fin,
			DateTime fecha_corte,
			double diferencia,
			Boolean terminado
			)
		{
			Id = id;
			Id_usuario = id_usuario;
			Fecha = fecha;
			Caja_inicial = caja_inicial;
			Caja_fin = caja_fin;
			Fecha_corte = fecha_corte;
			Diferencia = diferencia;
			Terminado = terminado;
		}
		public Cortes() { }
		private Cortes Buildcortes(MySqlDataReader data)
		{
			Cortes item = new Cortes(
				data.GetInt16("id"),
				data.GetInt16("id_usuario"),
				data.GetDateTime("fecha"),
				data.GetDouble("caja_inicial"),
				data.GetDouble("caja_fin"),
				data.GetDateTime("fecha_corte"),
				data.GetDouble("diferencia"),
				data.GetBoolean("terminado")
				);
			return item;

		}
		public void start_caja() {
			string query = "insert into tbacortes (id_usuario, fecha, caja_inicial, fecha_corte) values ('" + this.Id_usuario + "', NOW(), '" + this.Caja_inicial + "', NOW())";
			object result = runQuery(query);
		}

		public void end_caja() {
			string query = "update tbacortes set caja_fin='" + this.Caja_fin + "', fecha_corte=NOW(), diferencia='" + this.Diferencia + "', terminado=1 where id_usuario='" + this.Id_usuario + "' and caja_fin=0";
			object result = runQuery(query);
		}
		public List<Cortes> getCortes() {
			string query = "select id, id_usuario, fecha, caja_inicial, caja_fin, fecha_corte, diferencia, terminado from tbacortes";
			MySqlDataReader data = runQuery(query);
			List<Cortes> result = new List<Cortes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Cortes item = Buildcortes(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Cortes> getCortesbydatecorte(string fechainician, string fechafin)
		{
			string query = "select id, id_usuario, fecha, caja_inicial, caja_fin, fecha_corte, diferencia, terminado from tbacortes where fecha_corte  BETWEEN CAST('" + fechainician + "' AS DATE) AND CAST('" + fechafin + "' AS DATE);";
			MySqlDataReader data = runQuery(query);
			List<Cortes> result = new List<Cortes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Cortes item = Buildcortes(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Cortes> getbyPerson(int id_person) {
			string query = "select id, id_usuario, fecha, caja_inicial, caja_fin, fecha_corte, diferencia, terminado from tbacortes where id_usuario='" + id_person.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Cortes> result = new List<Cortes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Cortes item = Buildcortes(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Cortes> getbypersonanddate(string fechainician, string fechafin, int id_persona)
		{
			string query = "select id, id_usuario, fecha, caja_inicial, caja_fin, fecha_corte, diferencia, terminado from tbacortes where id_usuario='" + id_persona.ToString() + "' and fecha_corte  BETWEEN CAST('" + fechainician + "' AS DATE) AND CAST('" + fechafin + "' AS DATE);";
			MySqlDataReader data = runQuery(query);
			List<Cortes> result = new List<Cortes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Cortes item = Buildcortes(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Cortes> getnoclose(int id_persona)
		{
			string query = "select id, id_usuario, fecha, caja_inicial, caja_fin, fecha_corte, diferencia, terminado from tbacortes where id_usuario='" + id_persona.ToString() + "' and terminado=0";
			MySqlDataReader data = runQuery(query);
			List<Cortes> result = new List<Cortes>();

			if (data.HasRows)
			{
				while (data.Read())
				{
					Cortes item = Buildcortes(data);
					result.Add(item);

				}
			}

			return result;
		}
	}
}
