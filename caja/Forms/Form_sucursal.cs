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
	public partial class Form_sucursal : Form
	{
		public static int id;
		public Form_sucursal()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form_sucursal_Load(object sender, EventArgs e)
		{
			if (id != 0)
			{
				Offices oficinas = new Offices();
				using (oficinas)
				{
					List<Offices> oficina = oficinas.GetOfficesbyid(id);
					txtNombre.Text = oficina[0].Name;
					txtDomicilio.Text = oficina[0].Domicilio;
					txtTelefono.Text = oficina[0].Telefono;
					txtServidor.Text = oficina[0].Servidor;
					txtCone.Text = oficina[0].Connection;
					txtNotas.Text = oficina[0].Notas;

					txtFacturacion.Text = oficina[0].Factura;
					txtRfc.Text = oficina[0].Rfc;
					txtInterior.Text = oficina[0].Interior;
					txtExterior.Text = oficina[0].Exterior;
					txtCalle.Text = oficina[0].Calle;
					txtColonia.Text = oficina[0].Colonia;
					txtCp.Text = oficina[0].Cp;
					txtMunicipio.Text = oficina[0].Municipio;
					txtEstado.Text = oficina[0].Estado;
				}
				
			}
			else
			{
				txtNombre.Text = "";
				txtDomicilio.Text = "";
				txtTelefono.Text = "";
				txtServidor.Text = "";
				txtCone.Text = "";
				txtNotas.Text = "";

				txtFacturacion.Text = "";
				txtRfc.Text = "";
				txtInterior.Text = "";
				txtExterior.Text = "";
				txtCalle.Text = "";
				txtColonia.Text = "";
				txtCp.Text = "";
				txtMunicipio.Text = "";
				txtEstado.Text = "";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Offices oficinas = new Offices();
			using (oficinas)
			{
				oficinas.Name = txtNombre.Text;
				oficinas.Domicilio = txtDomicilio.Text;
				oficinas.Telefono = txtTelefono.Text;
				oficinas.Servidor = txtServidor.Text;
				oficinas.Connection = txtCone.Text;
				oficinas.Notas = txtNotas.Text;
				oficinas.Factura = txtFacturacion.Text;
				oficinas.Rfc = txtRfc.Text;
				oficinas.Interior = txtInterior.Text;
				oficinas.Exterior = txtExterior.Text;
				oficinas.Calle = txtCalle.Text;
				oficinas.Colonia = txtColonia.Text;
				oficinas.Cp = txtCp.Text;
				oficinas.Municipio = txtMunicipio.Text;
				oficinas.Estado = txtEstado.Text;
				if (id != 0)
				{
					oficinas.Id = id;
					oficinas.SaveOffice();
				}
				else
				{
					oficinas.CreateOffice();
				}
			}
			
			this.Close();
		}

		private void txtServidor_Leave(object sender, EventArgs e)
		{
			string valor = txtServidor.Text;
			txtCone.Text = "datasource=" + valor.Trim() + ";port=3306;username=root;database=caja;pooling = false;Allow Zero Datetime=true;";
		}
	}
}
