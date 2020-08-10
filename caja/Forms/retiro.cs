using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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

			double monto;
			if (txtMonto.Text == "")
			{
				monto = 0;
			}
			else
			{
				monto = Convert.ToDouble(txtMonto.Text);
			}
			int id_proveedor;
			if (txtIdproveedor.Text == "")
			{
				id_proveedor = 0;
			}
			else
			{
				id_proveedor = Convert.ToInt16(txtIdproveedor.Text);
			}
			retiro_efectivo retiros = new retiro_efectivo();
			using (retiros)
			{
				retiros.Monto = suma;
				retiros.Usuario = usuario;
				retiros.Monto_proveedor =monto;
				retiros.Id_proveedor =id_proveedor;
				retiros.createRetiro();
				
				List<retiro_efectivo> reti = retiros.get_lastretiro(usuario);

				det_retiro detalle = new det_retiro();
				using (detalle)
				{
					detalle.Id_retiro = reti[0].Id;

					detalle.Billete = 1000;
					detalle.Cantidad = Convert.ToInt16(num1000.Value);
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
				}
				
			}
			



			
			MessageBox.Show("Retiro efectuado con exito","Retiro",MessageBoxButtons.OK, MessageBoxIcon.Information);
			printDocument1 = new PrintDocument();
			PrinterSettings ps = new PrinterSettings();
			Configuration configuracion = new Configuration();
			using (configuracion)
			{
				List<Configuration> config = configuracion.getConfiguration();

				printDocument1.PrinterSettings = ps;
				printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
				printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
				printDocument1.PrinterSettings.Copies = 2;
				printDocument1.Print();
			}
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
			using (proveedores)
			{
				List<Providers> result = proveedores.getProviders();
				foreach (Providers item in result)
				{
					datos.Add(item.Id.ToString());
				}
			}
			
			return datos;
		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Providers proveedores = new Providers();
			using (proveedores)
			{
				List<Providers> result = proveedores.getProviders();
				foreach (Providers item in result)
				{
					datos.Add(item.Name);
				}
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
					using (proveedores)
					{
						List<Providers> proveedor = proveedores.getProviderbyId(Convert.ToInt16(txtIdproveedor.Text));
						if (proveedor.Count > 0)
						{
							txtProveedor.Text = proveedor[0].Name;
						}
					}
					
				}
			}
		}

		private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Providers proveedores = new Providers();
				using (proveedores) {
					List<Providers> proveedor = proveedores.getProviderbyNombreabsolute(txtProveedor.Text);
					if (proveedor.Count > 0)
					{
						txtIdproveedor.Text = proveedor[0].Id.ToString();
					}
				}
				
			}
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}
		private string formato(string numero)
		{
			double valor = 0;
			string resultado = "";
			valor = Convert.ToDouble(numero);
			resultado = valor.ToString("0.00");
			return resultado;
		}
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Configuration configuracion = new Configuration();
			using (configuracion)
			{
				List<Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };
				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].RFC, font, Brushes.Black, 125, y, format);
				y = y + 10;
				string calle = config[0].Calle + " " + config[0].No_ext;
				if (config[0].No_int != "")
				{
					calle += "-" + config[0].No_int;
				}
				e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Municipio + " " + config[0].Estado, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString("Telefono" + config[0].Telefono, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				format = new StringFormat() { Alignment = StringAlignment.Far };
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				double total_retirado = 0;
				y = y + 15;
				e.Graphics.DrawString("Retiro de dinero ", font, Brushes.Black, 0, y);

				if (txtMonto.Text == "")
				{
					y = y + 15;
					
					e.Graphics.DrawString("Cantidad", font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString("Total", font, Brushes.Black, 220, y, format);
					y = y + 10;
					e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
					y = y + 30;


					e.Graphics.DrawString("$ 1000", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num1000.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num1000.Value * 1000)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num1000.Value * 1000);
					y = y + 15;
					e.Graphics.DrawString("$ 500", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num500.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num500.Value * 500)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num500.Value * 500);
					y = y + 15;
					e.Graphics.DrawString("$ 200", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num200.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num200.Value * 200)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num200.Value * 200);
					y = y + 15;
					e.Graphics.DrawString("$ 100", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num100.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num100.Value * 100)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num100.Value * 100);
					y = y + 15;
					e.Graphics.DrawString("$ 50", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num50.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num50.Value * 50)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num50.Value * 50);
					y = y + 15;
					e.Graphics.DrawString("$ 20", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString(num20.Value.ToString(), font, Brushes.Black, 150, y, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", (num20.Value * 20)), font, Brushes.Black, 220, y, format);
					total_retirado = total_retirado + Convert.ToDouble(num20.Value * 20);
					y = y + 15;
					e.Graphics.DrawString("Total retirado $ " + string.Format("{0:#,0.00}", total_retirado), font, Brushes.Black, 150, y, format);
				}
				else
				{
					y = y + 15;
					e.Graphics.DrawString("Pago a proveedor", font, Brushes.Black, 50, y);
					y = y + 15;
					e.Graphics.DrawString(txtProveedor.Text, font, Brushes.Black, 50, y);
					y = y + 15;
					e.Graphics.DrawString("Monto", font, Brushes.Black, 50, y);
					y = y + 15;
					e.Graphics.DrawString(string.Format("{0:#,0.00}", Convert.ToDouble(txtMonto.Text)), font, Brushes.Black, 50, y);
				}
				y = y + 30;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				y = y + 10;
				e.Graphics.DrawString("Recibido", font, Brushes.Black, 150, y);
			}
		}
	}
}
