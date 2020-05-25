using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Det_pagos:ConnectDB
	{
		public int Id { get; set; }
		public int Id_pago { get; set; }
		public int Id_compra { get; set; }

		public Det_pagos(
			int id, 
			int id_pago,
			int id_compra
			)
		{
			Id = id;
			Id_pago = id_pago;
			Id_compra = id_compra;
		}
		
		public Det_pagos() { }

		private Det_pagos buildDet_pagos(MySqlDataReader data)
		{
			Det_pagos item = new Det_pagos(
				data.GetInt16("id"),
				data.GetInt16("id_pago"),
				data.GetInt16("id_compra")
				);
			return item;
		}

		public void createPago()
		{
			string query = "insert into tbadetpagos (id_pago, id_compra) values ('" + this.Id_pago + "' , '" + this.Id_compra + "')";
			object result = runQuery(query);
		}

		public List<Det_pagos> get_pagos()
		{
			string query = "select id, id_pago,  id_compra from tbadetpagos";
			MySqlDataReader data = runQuery(query);
			List<Det_pagos> result = new List<Det_pagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_pagos item = buildDet_pagos(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Det_pagos> get_pagosbyid(string id_pago)
		{
			string query = "select id, id_pago,  id_compra from tbadetpagos where id='" + id_pago + "'";
			MySqlDataReader data = runQuery(query);
			List<Det_pagos> result = new List<Det_pagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_pagos item = buildDet_pagos(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
