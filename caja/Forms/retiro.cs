﻿using System;
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
	public partial class retiro : Form
	{
		double suma;
		public static int usuario;
		public retiro()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			
			retiro_efectivo retiros = new retiro_efectivo();
			retiros.Monto = suma;
			retiros.Usuario = usuario;
			retiros.Monto_proveedor = Convert.ToDouble(txtMonto.Text);
			retiros.Id_proveedor = Convert.ToInt16(txtIdproveedor.Text);
			retiros.createRetiro();
			
			List<retiro_efectivo> reti = retiros.get_lastretiro(usuario);

			det_retiro detalle = new det_retiro();
			detalle.Id_retiro = reti[0].Id;

			detalle.Billete = 1000;
			detalle.Cantidad= Convert.ToInt16(num1000.Value);
			detalle.crate_det_retiro();

			detalle.Billete = 500;
			detalle.Cantidad = Convert.ToInt16(num500.Value);
			detalle.crate_det_retiro();

			detalle.Billete = 200;
			detalle.Cantidad = Convert.ToInt16(num200.Value);
			detalle.crate_det_retiro();

			detalle.Billete = 100;
			detalle.Cantidad = Convert.ToInt16(num100.Value);
			detalle.crate_det_retiro();

			detalle.Billete = 50;
			detalle.Cantidad = Convert.ToInt16(num50.Value);
			detalle.crate_det_retiro();

			detalle.Billete = 20;
			detalle.Cantidad = Convert.ToInt16(num20.Value);
			detalle.crate_det_retiro();

			MessageBox.Show("Retiro efectuado con exito","Retiro",MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();

		}

		private void num1000_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}
		private void calcula()
		{
			suma = 0;
			double mil =  ( Convert.ToDouble(num1000.Value)*1000);
			double quinientos = (Convert.ToDouble(num500.Value) * 500);
			double docientos = (Convert.ToDouble(num200.Value) * 200);
			double cien = (Convert.ToDouble(num100.Value) * 100);
			double cincuenta = (Convert.ToDouble(num50.Value) * 50);
			double veinte = (Convert.ToDouble(num20.Value) * 20);

			suma = mil + quinientos + docientos + cien + cincuenta + veinte;
			lbTotal.Text = "Total $ " + string.Format("{0:#,0.00}", Convert.ToDouble(suma)); ;
		}

		private void retiro_Load(object sender, EventArgs e)
		{
			txtIdproveedor.AutoCompleteCustomSource = cargadatos();
			txtIdproveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtIdproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtProveedor.AutoCompleteCustomSource = cargadatos2();
			txtProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Providers proveedores = new Providers();
			List<Providers> result = proveedores.getProviders();
			foreach (Providers item in result)
			{
				datos.Add(item.Id.ToString());
			}
			return datos;
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Providers proveedores = new Providers();
			List<Providers> result = proveedores.getProviders();
			foreach (Providers item in result)
			{
				datos.Add(item.Name);
			}
			return datos;
		}
		private void num500_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void num200_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void num100_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void num50_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void num20_ValueChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void txtIdproveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtIdproveedor.Text != "")
				{
					Providers proveedores = new Providers();
					List<Providers> proveedor = proveedores.getProviderbyId(Convert.ToInt16(txtIdproveedor.Text));
					if (proveedor.Count > 0)
					{
						txtProveedor.Text = proveedor[0].Name;
					}
				}
			}
		}

		private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Providers proveedores = new Providers();
				List<Providers> proveedor = proveedores.getProviderbyNombreabsolute(txtProveedor.Text);
				if (proveedor.Count > 0)
				{
					txtIdproveedor.Text = proveedor[0].Id.ToString();
				}
			}
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}
	}
}
