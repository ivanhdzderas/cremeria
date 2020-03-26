using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;

namespace caja.Forms
{
	public partial class form_proveedor : Form
	{
		public static string id;
		public form_proveedor()
		{
			InitializeComponent();
		}

		private void form_proveedor_Load(object sender, EventArgs e)
		{
			txtNombre.Text = "";
			txtRFC.Text = "";
			txtCalle.Text = "";
			txtNumExt.Text = "";
			txtNumInt.Text = "";
			txtColonia.Text = "";
			txtCp.Text = "";
			txtEstado.Text = "";
			txtMunicipio.Text = "";
			txtTelefono.Text = "";
			txtNotas.Text = "";
			txtEmail.Text = "";

			if (id != "'0") {
				Client client = new Client();
				List<Client> result = client.getClientbyId(Convert.ToInt16(id));

				foreach (Client item in result)
				{
					txtNombre.Text = item.Name;
					txtRFC.Text = item.RFC;
					txtCalle.Text = item.Street;
					txtNumExt.Text = item.Ext_number;
					txtNumInt.Text = item.Int_number;
					txtColonia.Text = item.Col;
					txtCp.Text = item.Cp;
					txtEstado.Text = item.State;
					txtMunicipio.Text = item.Muni;
					txtTelefono.Text = item.Tel;
					txtNotas.Text = item.Note;
					txtEmail.Text = item.Email;
				}

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Providers prov = new Providers(
				Convert.ToInt16(id),
				txtNombre.Text,
				txtRFC.Text,
				txtCalle.Text,
				txtNumExt.Text,
				txtNumInt.Text,
				txtColonia.Text,
				txtCp.Text,
				txtEstado.Text,
				txtMunicipio.Text,
				txtTelefono.Text,
				txtNotas.Text,
				txtEmail.Text
				);
			if (id == "0")
			{
				prov.createProvider();
			}
			else {
				prov.saveProvider();
			}
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
