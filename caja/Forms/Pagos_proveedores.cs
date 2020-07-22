using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms
{
	public partial class Pagos_proveedores : Form
	{
		public Pagos_proveedores()
		{
			InitializeComponent();
		}

		private void Pagos_proveedores_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga()
		{
			dtPagos.Rows.Clear();
			Pagos_compras pagos = new Pagos_compras();
			using (pagos)
			{
				List<Pagos_compras> pago = pagos.getcompras();
				Models.Compras compras = new Models.Compras();
				foreach (Pagos_compras item in pago)
				{
					List<Models.Compras> compra = compras.getCompraByid(item.Id_compra);
					dtPagos.Rows.Add(item.Id, item.Fecha, compra[0].Proveedor, item.Monto);
				}
			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Forms_pagos pagos = new Forms_pagos();
			pagos.Owner = this;
			pagos.ShowDialog();
			carga();
		}
	}
}
