using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caja.Models;
namespace caja.Forms
{
	public partial class autentificar : Form
	{
		public autentificar()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string usuario = txtUsuario.Text;
			string contra = txtContra.Text;
			Users usuarios = new Users();
			List<Users> result = usuarios.getUser(usuario);
			if (result.Count > 0)
			{
				using (MD5 md5Hash = MD5.Create())
				{
					if ((Forms.intercambios.VerifyMd5Hash(md5Hash, contra, result[0].Pass)) || (contra == result[0].Pass))
					{
						Permisos permisos = new Permisos();
						List<Permisos> permiso = permisos.getPermiso(result[0].Id);
						if (permiso.Count > 0)
						{
							if (Convert.ToBoolean(permiso[0].Retiro_efectivo) == true)
							{

							}
							else
							{
								MessageBox.Show("El usuario no tiene permiso de efectuar retiro de caja", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
					}
					else
					{

						MessageBox.Show("Usuario y/o contraseña invalidos");
					}
				}
			}
			else
			{
				MessageBox.Show("No se encontro usuario", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			

		}

		private void txtContra_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button2.PerformClick();
			}
		}
	}
}
