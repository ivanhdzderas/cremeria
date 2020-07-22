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
	public partial class Grupos : Form
	{
		public Grupos()
		{
			InitializeComponent();
		}

		private void Grupos_Load(object sender, EventArgs e)
		{
			tvGrupos.ImageList = imageList1;
			tvGrupos.SelectedImageIndex = 1;
			
			carga();
			carga_cbtodos();
			
		}
		TreeNode parentNode = null;
		public void carga() {
			tvGrupos.Nodes.Clear();
			
			Groups grupos = new Groups();
			using (grupos)
			{
				List<Groups> grupo = grupos.getGroupsonly();
				foreach (Groups item in grupo)
				{
					TreeNode nodo = new TreeNode(item.Group.ToString());
					nodo.Tag = item.Id.ToString();
					nodo.ImageIndex = 0;
					tvGrupos.Nodes.Add(nodo);
					generarNodes(item.Id, nodo);
				}
			}
			
			tvGrupos.ExpandAll();
		}
		public void generarNodes(int parentId, TreeNode parentNode) {
			Groups grupo = new Groups();
			using (grupo)
			{
				List<Groups> sub = grupo.getSubgrups(parentId);
				TreeNode childNode;
				foreach (Groups item in sub)
				{
					if (parentNode == null)
					{
						TreeNode nodo = new TreeNode(item.Group.ToString());
						;

						childNode = tvGrupos.Nodes.Add(item.Group);
						childNode.Tag = item.Id.ToString();
						childNode.ImageIndex = 0;
					}
					else
					{
						childNode = parentNode.Nodes.Add(item.Group);
						childNode.Tag = item.Id.ToString();
						childNode.ImageIndex = 0;
						generarNodes(item.Id, childNode);
					}
				}
			}
			
		}

		private void carga_cbtodos() {
			cbTodos.DataSource = null;
			cbTodos.Items.Clear();
			cbTodos.Text = "";
			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "0";
			table.Rows.Add(row);
			// cboMarca.Items.Clear();
			Groups grup = new Groups();
			using (grup)
			{
				List<Groups> result = grup.getGroup();
				foreach (Groups item in result)
				{
					row = table.NewRow();
					row["Text"] = item.Group;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}
			
			cbTodos.BindingContext = new BindingContext();
			cbTodos.DataSource = table;
			cbTodos.DisplayMember = "Text";
			cbTodos.ValueMember = "Value";
			cbTodos.BindingContext = new BindingContext();
		}

		private void tvGrupos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{


			Groups grupo = new Groups();
			using (grupo)
			{
				List<Groups> grup = grupo.getGroupbyId(e.Node.Tag.ToString());
				foreach (Groups item in grup)
				{
					txtNombre.Text = item.Group;
					cbTodos.SelectedValue = item.Master;
					idGrupo.Text = item.Id.ToString();
				}
			}
			
		
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			txtNombre.Text = "";
			txtDescripcion.Text = "";
			cbTodos.SelectedIndex = 0;

		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			Groups grupos = new Groups(
				0,
				txtNombre.Text,
				Convert.ToInt16(cbTodos.SelectedValue)
				) ;
			using (grupos)
			{
				grupos.createGroup();
			}
			
			carga();
			carga_cbtodos();
			idGrupo.Text = "";

		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (idGrupo.Text != "") {
				Groups grupo = new Groups();
				grupo.Id = Convert.ToInt16(idGrupo.Text);
				grupo.deleteGroup();
				carga();
				carga_cbtodos();
				txtNombre.Text = "";
				idGrupo.Text = "";
			}
		}
	}
}
