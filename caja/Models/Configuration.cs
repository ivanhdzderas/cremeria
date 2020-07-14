using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Configuration:ConnectDB
	{
		public int Id { get; set; }
		public string Razon_social { get; set; }
		public string Nombre_comercial { get; set; }
		public string RFC { get; set; }
		public string Telefono { get; set; }
		public string Calle { get; set; }
		public string No_ext { get; set; }
		public string No_int { get; set; }
		public string Colonia { get; set; }
		public string Estado { get; set; }
		public string Municipio { get; set; }
		public string Pais { get; set; }
		public string Regimen { get; set; }
		public string Cp { get; set; }
		public string Logo { get; set; }
		public string Key { get; set; }
		public string Cer { get; set; }
		public string Pass { get; set; }
		public string Email { get; set; }
		public string Proveedor { get; set; }
		public string Smtp_serv { get; set; }
		public string Contra_smtp { get; set; }
		public int Ssl { get; set; }
		public int Smtp_Port { get; set; }
		public string Cuerpo_email { get; set; }
		public string Ruta_factura { get; set; }
		public string Impresora { get; set; }
		public int Tipo_Impre { get; set; }
		public string Logo_ticket { get; set; }
		public string Impresora_reportes { get; set; }
		public string Serie { get; set; }
		public int Folio { get; set; }
		public string Pie_ticket { get; set; }
		public string Ruta_reportes { get; set; }
		public double Credito { get; set; }
		public double Debito { get; set; }

		public Configuration(
			int id,
			string razon_social,
			string nombre_comercial,
			string rfc,
			string telefono,
			string calle,
			string no_ext,
			string no_int,
			string colonia,
			string estado,
			string municipio,
			string pais,
			string regimen,
			string cp,
			string logo,
			string key,
			string cer,
			string pass,
			string email,
			string proveedor,
			string smtp_serv,
			string contra_smtp,
			int ssl,
			int smtp_Port,
			string cuerpo_email,
			string ruta_factura,
			string impresora,
			int tipo_Impre,
			string logo_ticket,
			string impresora_reportes,
			string serie,
			int folio,
			string pie_ticket,
			string ruta_reportes,
			double credito,
			double debito
			) {
			Id = id;
			Razon_social = razon_social;
			Nombre_comercial = nombre_comercial;
			RFC = rfc;
			Telefono = telefono;
			Calle = calle;
			No_ext = no_ext;
			No_int = no_int;
			Colonia = colonia;
			Estado = estado;
			Municipio = municipio;
			Pais = pais;
			Regimen = regimen;
			Cp = cp;
			Logo = logo;
			Key = key;
			Cer = cer;
			Pass = pass;
			Email = email;
			Proveedor = proveedor;
			Smtp_serv = smtp_serv;
			Contra_smtp = contra_smtp;
			Ssl = ssl;
			Smtp_Port = smtp_Port;
			Cuerpo_email = cuerpo_email;
			Ruta_factura = ruta_factura;
			Impresora = impresora;
			Tipo_Impre = tipo_Impre;
			Logo_ticket = logo_ticket;
			Impresora_reportes = impresora_reportes;
			Serie = serie;
			Folio = folio;
			Pie_ticket = pie_ticket;
			Ruta_reportes = ruta_reportes;
			Credito = credito;
			Debito = debito;
		}
		public Configuration() { }

		private Configuration buildConfiguration(MySqlDataReader data)
		{
			Configuration item = new Configuration(
				data.GetInt16("id"),
				data.GetString("razonsocial"),
				data.GetString("nombrecomercial"),
				data.GetString("rfc"),
				data.GetString("telefono"),
				data.GetString("calle"),
				data.GetString("noext"),
				data.GetString("noint"),
				data.GetString("colonia"),
				data.GetString("estado"),
				data.GetString("municipio"),
				data.GetString("pais"),
				data.GetString("regimen"),
				data.GetString("cp"),
				data.GetString("logo"),
				data.GetString("key_file"),
				data.GetString("cer"),
				data.GetString("pass"),
				data.GetString("email"),
				data.GetString("proveedor"),
				data.GetString("smtpserv"),
				data.GetString("contra"),
				data.GetInt16("ssl_email"),
				data.GetInt16("smtpport"),
				data.GetString("cuerpoemail"),
				data.GetString("rutafact"),
				data.GetString("impresora"),
				data.GetInt16("tipoimpre"),
				data.GetString("logoticket"),
				data.GetString("reportes_impresora"),
				data.GetString("serie_factura"),
				data.GetInt16("folio_factura"),
				data.GetString("pie_ticket"),
				data.GetString("ruta_reportes"),
				data.GetDouble("credito"),
				data.GetDouble("debito")
				) ;
			return item;
		}

		public void updateConfiguration() {
			string query = "update tbaconfiguracion set ";
			query += "razonsocial='" + this.Razon_social + "', ";
			query += "nombrecomercial='" + this.Nombre_comercial  + "', ";
			query += "rfc='" + this.RFC + "', ";
			query += "telefono='" + this.Telefono + "', ";
			query += "calle='" + this.Calle + "', ";
			query += "noext='" + this.No_ext + "', ";
			query += "noint='" + this.No_int + "', ";
			query += "colonia='" + this.Colonia + "', ";
			query += "estado='" +this.Estado+ "', ";
			query += "municipio='" + this.Municipio + "', ";
			query += "pais='" + this.Pais + "', ";
			query += "regimen='" + this.Regimen + "', ";
			query += "cp='" + this.Cp + "', ";
			query += "logo='" + this.Logo + "', ";
			query += "key_file='" + this.Key + "', ";
			query += "cer='" + this.Cer + "', ";
			query += "pass='" + this.Pass + "', ";
			query += "email='" + this.Email + "', ";
			query += "proveedor='" + this.Proveedor + "', ";
			query += "smtpserv='" + this.Smtp_serv + "', ";
			query += "contra='" + this.Contra_smtp + "', ";
			query += "ssl_email='" + this.Ssl + "', ";
			query += "smtpport='" + this.Smtp_Port + "', ";
			query += "cuerpoemail='" + this.Cuerpo_email + "', ";
			query += "rutafact='" + this.Ruta_factura + "', ";
			query += "impresora='" + this.Impresora + "', ";
			query += "tipoimpre='" + this.Tipo_Impre + "', ";
			query += "logoticket='" + this.Logo_ticket + "', ";
			query += "reportes_impresora='" + this.Impresora_reportes + "', ";
			query += "serie_factura='" + this.Serie + "', ";
			query += "folio_factura='" + this.Folio + "',";
			query += "pie_ticket='" + this.Pie_ticket + "', ";
			query += "ruta_reportes='" + this.Ruta_reportes + "', ";
			query += "credito='" + this.Credito + "', ";
			query += "debito='" + this.Debito + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateImpresoras()
		{
			string query = "update tbaconfiguracion set ";
			
			query += "impresora='" + this.Impresora + "', ";
			query += "tipoimpre='" + this.Tipo_Impre + "', ";
			query += "pie_ticket='" + this.Pie_ticket + "', ";
			query += "reportes_impresora='" + this.Impresora_reportes + "' ";
			
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updatecomisiones()
		{
			string query = "update tbaconfiguracion set ";

			query += "credito='" + this.Credito + "', ";
			query += "debito='" + this.Debito + "' ";

			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void update_reportes() {
			string query = "update tbaconfiguracion set ";

			query += "ruta_reportes='" + this.Ruta_reportes + "'";

			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateEmpresa() {
			string query = "update tbaconfiguracion set ";
			query += "razonsocial='" + this.Razon_social + "', ";
			query += "nombrecomercial='" + this.Nombre_comercial + "', ";
			query += "rfc='" + this.RFC + "', ";
			query += "telefono='" + this.Telefono + "', ";
			query += "calle='" + this.Calle + "', ";
			query += "noext='" + this.No_ext + "', ";
			query += "noint='" + this.No_int + "', ";
			query += "colonia='" + this.Colonia + "', ";
			query += "estado='" + this.Estado + "', ";
			query += "municipio='" + this.Municipio + "', ";
			query += "pais='" + this.Pais + "', ";
			query += "regimen='" + this.Regimen + "', ";
			query += "cp='" + this.Cp + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateLogo() { 
			string query = "update tbaconfiguracion set ";
			query += "logo='" + this.Logo + "', ";
			query += "logoticket='" + this.Logo_ticket + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateCertified() {
			string query = "update tbaconfiguracion set ";
			query += "key_file='" + this.Key + "', ";
			query += "cer='" + this.Cer + "', ";
			query += "pass='" + this.Pass + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateEmail() {
			string query = "update tbaconfiguracion set ";
			query += "email='" + this.Email + "', ";
			query += "proveedor='" + this.Proveedor + "', ";
			query += "smtpserv='" + this.Smtp_serv + "', ";
			query += "contra='" + this.Contra_smtp + "', ";
			query += "ssl_email='" + this.Ssl + "', ";
			query += "smtpport='" + this.Smtp_Port + "', ";
			query += "cuerpoemail='" + this.Cuerpo_email + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}

		public void impresora() {
			string query = "update tbaconfiguracion set ";
			query += "impresora='" + this.Impresora + "', ";
			query += "tipoimpre='" + this.Tipo_Impre + "', ";
			query += "reportes_impresora='" + this.Impresora_reportes + "'";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void updateFactura() {
			string query = "update tbaconfiguracion set ";
			query += "rutafact='" + this.Ruta_factura + "', ";
			query += "serie_factura='" + this.Serie + "', ";
			query += "folio_factura='" + this.Folio + "' ";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public List<Configuration> getConfiguration() {
			string query = "SELECT id, razonsocial,nombrecomercial,rfc,telefono,calle,noext,noint,colonia,estado,municipio,pais,regimen,cp,logo,key_file,cer,pass,email,proveedor,smtpserv,contra,ssl_email,smtpport,cuerpoemail,rutafact,impresora,tipoimpre,logoticket,reportes_impresora,serie_factura, folio_factura, pie_ticket, ruta_reportes, credito, debito FROM tbaconfiguracion; ";
			MySqlDataReader data = runQuery(query);
			List<Configuration> result = new List<Configuration>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Configuration item = buildConfiguration(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
