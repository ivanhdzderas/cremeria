using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Payment_Form:ConnectDB
	{
		public string Method { get; set; }
		public string Description { get; set; }

		public Payment_Form(string method, string description)
		{
			Method = method;
			Description = description;
		}
		public Payment_Form() { }

		private Payment_Form build_payment(MySqlDataReader data)
		{
			Payment_Form item = new Payment_Form(
				data.GetString("c_metodopago"),
				data.GetString("descripcion")
				);
			return item;
		}


		public List<Payment_Form> get_method()
		{
			string query = "select c_metodopago, descripcion from zz33_metodopago";
			MySqlDataReader data = runQuery(query);
			List<Payment_Form> result = new List<Payment_Form>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Payment_Form item = build_payment(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Payment_Form> get_methodbymethod(string method)
		{
			string query = "select c_metodopago, descripcion from zz33_metodopago where c_metodopago='" + method + "'";
			MySqlDataReader data = runQuery(query);
			List<Payment_Form> result = new List<Payment_Form>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Payment_Form item = build_payment(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Payment_Form> get_methodbyDescription(string description)
		{
			string query = "select c_metodopago, descripcion from zz33_metodopago where descripcion='" + description + "'";
			MySqlDataReader data = runQuery(query);
			List<Payment_Form> result = new List<Payment_Form>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Payment_Form item = build_payment(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
