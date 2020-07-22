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
	public partial class configuracion : Form
	{
        private static int Id;
		public configuracion()
		{
			InitializeComponent();
		}

		private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
		{
            Graphics g = e.Graphics;
            Brush _textBrush;
            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];
            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);
            
            _tabPage.BackColor = Color.LightGray;
           
            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)12.0, FontStyle.Regular, GraphicsUnit.Pixel);
            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog logo = new OpenFileDialog();
            logo.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; ; *.png";
            logo.Title= "Logo";
            if (logo.ShowDialog() == DialogResult.OK) {
                txtLogo.Text = logo.FileName;
            }
            logo.Dispose();
            if (File.Exists(txtLogo.Text)) {
                pbLogo.Image = Image.FromFile(txtLogo.Text);
            }
        }
        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbProveedor.Text)
            {
                case "YAHOO":
                    txtSmtp.Text = "smtp.mail.yahoo.com";
                    txtSmtpPort.Text = "25";

                    break;
                case "HOTMAIL":
                    txtSmtp.Text = "smtp-mail.outlook.com";
                    txtSmtpPort.Text = "25";
                    break;
                case "GMAIL":
                    txtSmtp.Text = "smtp.gmail.com";
                    txtSmtpPort.Text = "25";
                    break;
                case "OTRO":
                    txtSmtp.Text = "";
                    txtSmtpPort.Text = "";
                    break;
            }
        }
        private void configuracion_Load(object sender, EventArgs e)
        {
            txtDebito.TextAlign = HorizontalAlignment.Right;
            txtCredito.TextAlign = HorizontalAlignment.Right;

            DataTable table = new DataTable();
            DataRow row;
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));
            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);
            // cboMarca.Items.Clear();
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                row = table.NewRow();
                row["Text"] = pkInstalledPrinters;
                row["Value"] = pkInstalledPrinters;
                table.Rows.Add(row);
            }
            cbImpresora.BindingContext = new BindingContext();
            cbImpresora.DataSource = table;
            cbImpresora.DisplayMember = "Text";
            cbImpresora.ValueMember = "Value";
            cbImpresora.BindingContext = new BindingContext();


            cbImpreReportes.BindingContext = new BindingContext();
            cbImpreReportes.DataSource = table;
            cbImpreReportes.DisplayMember = "Text";
            cbImpreReportes.ValueMember = "Value";
            cbImpreReportes.BindingContext = new BindingContext();


            DataTable table2 = new DataTable();
            DataRow row2;
            table2.Columns.Add("Text", typeof(string));
            table2.Columns.Add("Value", typeof(string));
            row2 = table2.NewRow();
            row2["Text"] = "";
            row2["Value"] = "";
            table2.Rows.Add(row2);

            row2 = table2.NewRow();
            row2["Text"] = "YAHOO";
            row2["Value"] = "YAHOO";
            table2.Rows.Add(row2);

            row2 = table2.NewRow();
            row2["Text"] = "HOTMAIL";
            row2["Value"] = "HOTMAIL";
            table2.Rows.Add(row2);

            row2 = table2.NewRow();
            row2["Text"] = "GMAIL";
            row2["Value"] = "GMAIL";
            table2.Rows.Add(row2);

            row2 = table2.NewRow();
            row2["Text"] = "OTRO";
            row2["Value"] = "OTRO";
            table2.Rows.Add(row2);

            cbProveedor.BindingContext = new BindingContext();
            cbProveedor.DataSource = table2;
            cbProveedor.DisplayMember = "Text";
            cbProveedor.ValueMember = "Value";
            cbProveedor.BindingContext = new BindingContext();


            Configuration config = new Configuration();
            using (config)
            {
                List<Configuration> item = config.getConfiguration();
                Id = item[0].Id;
                txtRazon.Text = item[0].Razon_social;
                txtComercial.Text = item[0].Nombre_comercial;
                txtRFC.Text = item[0].RFC;
                txtCalle.Text = item[0].Calle;
                txtExterior.Text = item[0].No_ext;
                txtInterior.Text = item[0].No_int;
                txtColonia.Text = item[0].Colonia;
                txtPoblacion.Text = item[0].Municipio;
                txtEstado.Text = item[0].Estado;
                txtPais.Text = item[0].Pais;
                txtTelefono.Text = item[0].Telefono;
                txtRegimen.Text = item[0].Regimen;
                txtSerie.Text = item[0].Serie;
                txtFolio.Text = item[0].Folio.ToString();
                txtRuta.Text = item[0].Ruta_factura;
                txtLogo.Text = item[0].Logo;
                txtPieTicket.Text = item[0].Pie_ticket;
                if (File.Exists(txtLogo.Text))
                {
                    pbLogo.Image = Image.FromFile(txtLogo.Text);
                }
                txtLogoTicket.Text = item[0].Logo_ticket;
                if (File.Exists(txtLogoTicket.Text))
                {
                    pbLogoTicket.Image = Image.FromFile(txtLogoTicket.Text);
                }
                txtKey.Text = item[0].Key;
                txtCer.Text = item[0].Cer;
                txtContra.Text = item[0].Pass;
                txtEmail.Text = item[0].Email;
                chkSsl.Checked = Convert.ToBoolean(item[0].Ssl);
                txtPassEmail.Text = item[0].Contra_smtp;
                cbProveedor.SelectedValue = item[0].Proveedor;
                txtSmtp.Text = item[0].Smtp_serv;
                txtSmtpPort.Text = item[0].Smtp_Port.ToString();
                txtCuerpo.Text = item[0].Cuerpo_email;
                chkticket.Checked = Convert.ToBoolean(item[0].Tipo_Impre);
                cbImpresora.SelectedValue = item[0].Impresora;
                cbImpreReportes.SelectedValue = item[0].Impresora_reportes;
                txtRutas.Text = item[0].Ruta_reportes;

                txtCredito.Text = item[0].Credito.ToString();
                txtDebito.Text = item[0].Debito.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog logo = new OpenFileDialog();
            logo.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; ; *.png";
            logo.Title = "Logo";
            if (logo.ShowDialog() == DialogResult.OK)
            {
                txtLogoTicket.Text = logo.FileName;
            }
            logo.Dispose();
            if (File.Exists(txtLogoTicket.Text))
            {
                pbLogoTicket.Image = Image.FromFile(txtLogoTicket.Text);
            }
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog key = new OpenFileDialog();
            key.Filter = "Key files (*.key) | *.key";
            key.Title = "Archivo Key";
            if (key.ShowDialog() == DialogResult.OK)
            {
                txtKey.Text = key.FileName;
            }
            key.Dispose();
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            OpenFileDialog cer = new OpenFileDialog();
            cer.Filter = "Cer files (*.cer) | *.cer";
            cer.Title = "Archivo Key";
            if (cer.ShowDialog() == DialogResult.OK)
            {
                txtCer.Text = cer.FileName;
            }
            cer.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration(
                Id,
                txtRazon.Text,
                txtComercial.Text,
                txtRFC.Text,
                txtTelefono.Text,
                txtCalle.Text,
                txtExterior.Text,
                txtInterior.Text,
                txtColonia.Text,
                txtEstado.Text,
                txtPoblacion.Text,
                txtPais.Text,
                txtRegimen.Text,
                txtCp.Text,
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                0,
                0,
                "",
                "",
                "",
                0,
                "",
                "",
                "",
                0,
                "",
                "",
                0,0
                );
            using (config)
            {
                config.updateEmpresa();
            }
            MessageBox.Show("Actualización exitosa");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            using (config)
            {
                config.Id = Id;
                config.Serie = txtSerie.Text;
                config.Folio = Convert.ToInt16(txtFolio.Text);
                string ruta = txtRuta.Text;
                config.Ruta_factura = ruta.Replace("\\", "/");
                config.updateFactura();
            }
            MessageBox.Show("Actualización exitosa");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            using (config)
            {
                config.Id = Id;
                string logo = txtLogo.Text;
                string logo_ticket = txtLogoTicket.Text;
                config.Logo = logo.Replace("\\", "/");
                config.Logo_ticket = logo_ticket.Replace("\\", "/");
                config.updateLogo();
            }
            
            MessageBox.Show("Actualización exitosa");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strkey = txtKey.Text;
            string strcer = txtCer.Text;
            Configuration config = new Configuration();
            using (config)
            {
                config.Id = Id;
                config.Key = strkey.Replace("\\", "/");
                config.Cer = strcer.Replace("\\", "/");
                config.Pass = txtContra.Text;
                config.updateCertified();

            }
            
            MessageBox.Show("Actualización exitosa");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            using (config)
            {
                config.Id = Id;
                config.Email = txtEmail.Text;
                config.Contra_smtp = txtPassEmail.Text;
                config.Proveedor = cbProveedor.SelectedValue.ToString();
                config.Ssl = Convert.ToInt16(chkSsl.Checked);
                config.Smtp_serv = txtSmtp.Text;
                config.Smtp_Port = Convert.ToInt16(txtSmtpPort.Text);
                config.Cuerpo_email = txtCuerpo.Text;
                config.updateEmail();
            }
            
            MessageBox.Show("Actualización exitosa");
        }

        private void chkSsl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSsl.Checked == true)
            {
                switch (cbProveedor.Text)
                {
                    case "YAHOO":
                        txtSmtpPort.Text = "465";
                        break;
                    case "HOTMAIL":
                        txtSmtpPort.Text = "587";
                        break;
                    case "GMAIL":
                        txtSmtpPort.Text = "465";
                        break;
                    case "OTRO":
                        txtSmtpPort.Text = "";
                        break;
                }
            }
            else {

                switch (cbProveedor.Text)
                {
                    case "YAHOO":
                        txtSmtpPort.Text = "25";

                        break;
                    case "HOTMAIL":
                        txtSmtpPort.Text = "25";
                        break;
                    case "GMAIL":
                        txtSmtpPort.Text = "25";
                        break;
                    case "OTRO":
                        txtSmtpPort.Text = "";
                        break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            using (config)
            {
                config.Id = Id;
                config.Tipo_Impre = Convert.ToInt16(chkticket.Checked);
                config.Impresora = cbImpresora.SelectedValue.ToString();
                config.Impresora_reportes = cbImpreReportes.SelectedValue.ToString();
                config.Pie_ticket = txtPieTicket.Text;
                config.updateImpresoras();
            }
            
            MessageBox.Show("Actualización exitosa");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    txtRutas.Text = fd.SelectedPath;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtRutas.Text != "")
            {
                Configuration config = new Configuration();
                using (config)
                {
                    config.Id = Id;
                    string ruta = txtRutas.Text;
                    config.Ruta_reportes = ruta.Replace("\\", "/");
                    config.update_reportes();
                }
                
                MessageBox.Show("Actualización exitosa");
            }
            else
            {
                MessageBox.Show("no puede guardar un campo vacio");
            }
           

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Configuration configuracion = new Configuration();
            using (configuracion)
            {
                configuracion.Id = Id;
                configuracion.Credito = Convert.ToDouble(txtCredito.Text);
                configuracion.Debito = Convert.ToDouble(txtDebito.Text);
                configuracion.updatecomisiones();
            }
            
            MessageBox.Show("Actualizacion exitosa");
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtCredito.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtDebito.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
