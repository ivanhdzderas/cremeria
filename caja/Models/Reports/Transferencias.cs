using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models.Reports
{
	public class Transferencias:ConnectDB
	{
		public int Folio { get; set; }
		public string Sucursal { get; set; }
		public double Monto { get; set; }

		public Transferencias(
			int folio,
			string sucursal,
			double monto
			)
		{
			Folio = folio;
			Sucursal = sucursal;
			Monto = monto;
		}

		public Transferencias()
		{

		}
		private Transferencias build_transfer(MySqlDataReader data)
		{
			Transferencias item = new Transferencias(
				data.GetInt16("folio"),
				data.GetString("sucursal"),
				data.GetDouble("total")
				);
			return item;
		}
		public List<Transferencias> getTransferbyDate(string Fecha1, string Fecha2, string tipo)
		{
			string query = "select folio, sucursal, total from tbatraspasos";
			if (Fecha1 == Fecha2)
			{
				query = query + " where DATE_FORMAT(fecha,'%Y-%m-%d')='" + Fecha1 + "' and tipo='" + tipo + "'";
			}
			else
			{
				query = query + " where  tipo='" + tipo + "' and DATE_FORMAT(fecha,'%Y-%m-%d') BETWEEN '" + Fecha1 + "' and '" + Fecha2 + "' ";
			}
			MySqlDataReader data = runQuery(query);
			List<Transferencias> result = new List<Transferencias>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Transferencias item = build_transfer(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
