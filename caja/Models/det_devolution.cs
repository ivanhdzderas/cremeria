using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
	public class det_devolution:ConnectDB
	{
		public int Id { get; set; }
		public int Id_devolucion { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double Pu { get; set; }
		public det_devolution(
			int id, 
			int id_devolucion, 
			double cantidad,
			int id_producto, 
			double pu
			)
		{
			Id = id;
			Id_devolucion = id_devolucion;
			Cantidad = cantidad;
			Id_producto = id_producto;
			Pu = pu;
		}

		public det_devolution() { }

		private det_devolution build_detdevo(MySqlDataReader data)
		{
			det_devolution item = new det_devolution(
				data.GetInt16("id"),
				data.GetInt16("id_devolucion"),
				data.GetDouble("cantidad"),
				data.GetInt16("id_producto"),
				data.GetDouble("pu")
				) ;
			return item;
		}

		public void create_det()
		{
			string query = "insert into tbadetdevo (id_devolucion, cantidad, id_producto, pu) values ('" + this.Id_devolucion + "', '" + this.Cantidad + "', '" + this.Id_producto + "', '" + this.Pu + "')";
			object result = runQuery(query);
		}

		public List<det_devolution> get_detalle(int id_devo)
		{
			string query = "select id, id_devoluciones, cantidad, id_producto, pu from tbadetdevo where id_devolucion='" + id_devo.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<det_devolution> result = new List<det_devolution>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_devolution item = build_detdevo(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
