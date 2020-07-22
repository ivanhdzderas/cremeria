using System;
using System.Collections.Generic;

namespace caja.Models
{
	public class Afecta_inv:ConnectDB
	{
		public void Agrega(int id_kardex) {
			Kardex kardex = new Kardex();
			Product producto = new Product();
			int nuevo = 0;
			using (kardex)
			{
				List<Kardex> Generales = kardex.getkardexbyid(id_kardex);
				nuevo = Convert.ToInt16(Generales[0].Antes) + Convert.ToInt16(Generales[0].Cantidad);
				
				using (producto)
				{
					producto.Id = Generales[0].Id_producto;
					producto.Existencia = nuevo;
					producto.update_inventary();
				}
				
			}
		}
		public void Disminuye(int id_kardex)
		{
			Kardex kardex = new Kardex();
			Product producto = new Product();
			int nuevo = 0;
			using (kardex)
			{
				List<Kardex> Generales = kardex.getkardexbyid(id_kardex);
				using (producto)
				{
					nuevo = Convert.ToInt16(Generales[0].Antes) - Convert.ToInt16(Generales[0].Cantidad);
					producto.Id = Generales[0].Id_producto;
					producto.Existencia = nuevo;

					producto.update_inventary();
				}
				
			}
			
		}
		public void Ajusta(int id_kardex)
		{
			Kardex kardex = new Kardex();
			Product producto = new Product();
			int nuevo = 0;
			using (kardex)
			{
				List<Kardex> Generales = kardex.getkardexbyid(id_kardex);
				using (producto)
				{
					nuevo = Convert.ToInt16(Generales[0].Cantidad);
					producto.Id = Generales[0].Id_producto;
					producto.Existencia = nuevo;

					producto.update_inventary();
				}
				
			}
			
		}
	}
}
