﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;

namespace caja
{
    public partial class form_cliente : Form
    {
        public static string id;
        public form_cliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text != "" || txtCp.Text != "") {
                Client client = new Client(
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
                    client.createClient();
                }
                else
                {
                    client.saveClient();
                }
                this.Close();
            }
            
        }

        private void form_cliente_Load(object sender, EventArgs e)
        {
            if (id == "0")
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
            }
            else {
                Client client = new Client();
                List<Client> result = client.getClientbyId(Convert.ToInt16(id));
                foreach (Client item in result) {
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
    }
}
