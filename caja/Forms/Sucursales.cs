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
	public partial class Sucursales : Form
	{
		public Sucursales()
		{
			InitializeComponent();
		}

		private void Sucursales_Load(object sender, EventArgs e)
		{
			carga();
		}
		public void carga()
		{
			dtOficinas.Rows.Clear();
			Offices oficinas = new Offices();
			List<Offices> lista = oficinas.GetOffices();
			foreach (Offices item in lista)
			{
				dtOficinas.Rows.Add(item.Id, item.Name, item.Telefono, item.Domicilio);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_sucursal.id = 0;
			Form_sucursal sucursal = new Form_sucursal();
			sucursal.ShowDialog();
			carga();
		}
	}
}
