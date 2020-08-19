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
	public partial class Sucursal : Form
	{
		public Sucursal()
		{
			InitializeComponent();
		}

		private void Sucursal_Load(object sender, EventArgs e)
		{
			DataTable table = new DataTable();
			DataRow row;

			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);

			Offices oficinas = new Offices();
			using (oficinas)
			{
				List<Offices> oficina = oficinas.GetOffices();
				foreach (Offices ofi in oficina)
				{
					row = table.NewRow();
					row["Text"] = ofi.Name;
					row["Value"] = ofi.Id;
					table.Rows.Add(row);
				}
			}
				
			
			
			cbOficinas.BindingContext = new BindingContext();
			cbOficinas.DataSource = table;
			cbOficinas.DisplayMember = "Text";
			cbOficinas.ValueMember = "Value";
			cbOficinas.BindingContext = new BindingContext();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show(cbOficinas.SelectedValue.ToString());
			if (cbOficinas.SelectedValue.ToString() != "")
			{
				caja.sucursal = cbOficinas.SelectedValue.ToString();
				this.Close();
			}
			else
			{
				MessageBox.Show("debe sele3ccionar una sucursal");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			caja.cancelado = true;
			this.Close();
		}
	}
}
