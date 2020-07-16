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
		public string origen;
		public autentificar()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			caja.cancelado = true;
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
							if (origen == "retiro")
							{
								if (Convert.ToBoolean(permiso[0].Retiro_efectivo) == true)
								{
									retiro ret = new retiro();
									retiro.usuario = result[0].Id;
									ret.Owner = this;
									ret.ShowDialog();
									this.Close();
								}
								else
								{
									MessageBox.Show("El usuario no tiene permiso de efectuar retiro de caja", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
							}
							if (origen == "transferencia")
							{
								if (Convert.ToBoolean(permiso[0].Transferencias) == true)
								{
									
									this.Close();
								}
								else
								{
									MessageBox.Show("El usuario no tiene permiso de efectuar transferencias", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
							}
							if (origen== "Cancelar")
							{
								if (Convert.ToBoolean(permiso[0].Cancelar_ticket) == true)
								{

									this.Close();
								}
								else
								{
									MessageBox.Show("El usuario no tiene permiso para cancelar Ticket", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
							}
							if (origen == "ver")
							{
								if (Convert.ToBoolean(permiso[0].Cancelar_ticket) == true)
								{
									caja.autorizado = true;
									this.Close();
								}
								else
								{
									MessageBox.Show("El usuario no tiene permiso de ver Tickets", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
							}
							if (origen== "Devollucion")
							{
								if (Convert.ToBoolean(permiso[0].Cancelar_ticket) == true)
								{
									devoluciones.id_usuario = result[0].Id;
									this.Close();
								}
								else
								{
									MessageBox.Show("El usuario no tiene permiso para devoluciones", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
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
