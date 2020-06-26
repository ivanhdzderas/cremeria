using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Forma_pago:ConnectDB
	{
		public string Formapago { get; set; }
		public string Descripcion { get; set; }
		public Forma_pago(string formapago, string descripcion)
		{
			Formapago = formapago;
			Descripcion = descripcion;
		}
		public Forma_pago() { }

		private Forma_pago build_pagos(MySqlDataReader data)
		{
			Forma_pago item = new Forma_pago(
				data.GetString("c_formapago"),
				data.GetString("descripcion")
				) ;
			return item;
		}

		public List<Forma_pago> getFpagos()
		{
			string query = "select c_formapago, descripcion from zz33_formapago";
			MySqlDataReader data = runQuery(query);
			List<Forma_pago> result = new List<Forma_pago>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Forma_pago item = build_pagos(data);
					result.Add(item);
				}
			}
			return result;
		}


		public List<Forma_pago> getFpagosbyforma(string forma)
		{
			string query = "select c_formapago, descripcion from zz33_formapago where c_formapago='" + forma + "'";
			MySqlDataReader data = runQuery(query);
			List<Forma_pago> result = new List<Forma_pago>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Forma_pago item = build_pagos(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Forma_pago> getFpagosbydescripcion(string descr)
		{
			string query = "select c_formapago, descripcion from zz33_formapago where descripcion='" + descr + "'";
			MySqlDataReader data = runQuery(query);
			List<Forma_pago> result = new List<Forma_pago>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Forma_pago item = build_pagos(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
