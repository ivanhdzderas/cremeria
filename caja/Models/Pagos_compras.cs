using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class Pagos_compras : ConnectDB
	{
		public int Id { get; set; }
		public int Fpago { get; set; }
		public int Id_compra { get; set; }
		public DateTime Fecha { get; set; }
		public double Monto { get; set; }

		public Pagos_compras(
			int id,
			int fpago,
			int id_compra,
			DateTime fecha,
			double monto
			)
		{
			Id = id;
			Fpago = fpago;
			Id_compra = id_compra;
			Fecha = fecha;
			Monto = monto;
		}

		public Pagos_compras() { } 

		public void create_pago()
		{
			string query = "insert into tbapagos (idfpago, id_compra, fecha, monto ) values ('" + this.Fpago + "', '" + this.Id_compra + "', '" + this.Fecha + "',  '" + this.Monto + "')";
			object result = runQuery(query);
		}
		private Pagos_compras buildcompras(MySqlDataReader data)
		{
			Pagos_compras item = new Pagos_compras(
				data.GetInt16("id"),
				data.GetInt16("idfpago"),
				data.GetInt16("id_compra"),
				data.GetDateTime("fecha"),
				data.GetDouble("monto")
				);
			return item;
		}

		public List<Pagos_compras> getcompras()
		{
			string query = "select id, idfpago, id_compra, fecha, monto from tbapagos";
			MySqlDataReader data = runQuery(query);
			List<Pagos_compras> result = new List<Pagos_compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Pagos_compras item = buildcompras(data);
					result.Add(item);

				}
			}
			return result;
		}

		public List<Pagos_compras> getcomprasbyid(int id)
		{
			string query = "select id, idfpago, id_compra, fecha, monto from tbapagos where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Pagos_compras> result = new List<Pagos_compras>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Pagos_compras item = buildcompras(data);
					result.Add(item);

				}
			}
			return result;
		}
	}
}
