using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using caja.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using caja.Forms;
using System.Text;

namespace caja
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (File.Exists("logo.png")) {
                Logo.Image = Image.FromFile("logo.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicial.exit = true;
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string usuario;
            string contra;

            usuario = textBox1.Text;
            contra = textBox2.Text;
           
            if (contra == ""  || usuario=="")
            {
                string message = "Ingrese usuario y/o contraseña";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                Users usuarios = new Users();

                using (usuarios)
                {
                    List<Users> result = usuarios.getUser(usuario);


                    using (MD5 md5Hash = MD5.Create())
                    {
                        if ((Forms.intercambios.VerifyMd5Hash(md5Hash, contra, result[0].Pass)) || (contra == result[0].Pass))
                        {
                            if (result[0].Tipo == "Cajero")
                            {
                                inicial.cajero = true;
                            }
                            inicial.id_usario = result[0].Id.ToString();
                            inicial.nombre = result[0].Nombre;
                            inicial.tipo_usuario = result[0].Tipo;
                            this.Close();
                        }
                        else
                        {

                            MessageBox.Show("Usuario y/o contraseña invalidos");
                        }
                    }
                }
                    
                
                

            }
        }

      

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                inicial.exit = true;
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                inicial.exit = true;
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
