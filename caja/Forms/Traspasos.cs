using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using caja.Models;

namespace caja.Forms
{
	public partial class Traspasos : Form
	{
		public Traspasos()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtTraspasos.Rows.Clear();
			Transfers transferencias = new Transfers();
			List<Transfers> lista = transferencias.getTransfers();

			Offices oficinas = new Offices();


			foreach(Transfers item in lista)
			{
				List<Offices> sucursal = oficinas.GetOfficesbyid(Convert.ToInt16(item.Sucursal));
				dtTraspasos.Rows.Add(item.Id, item.Folio, sucursal[0].Name, item.Fecha, item.Total);
			}
		}
		private void Traspasos_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Transfer_forms.id_transfer = 0;
			Transfer_forms Producto = new Transfer_forms();

			Producto.ShowDialog();
			carga();
		}

		private void dtTraspasos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtTraspasos.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtTraspasos.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Transfer_forms.id_transfer =Convert.ToInt16(codigo);
			Transfer_forms Producto = new Transfer_forms();

			Producto.ShowDialog();
			carga();
		}
	
		private void button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog archivo = new OpenFileDialog();
			archivo.Filter = "Image files (*.xml) | *.xml";
			archivo.Title = "Transferencia";
			if (archivo.ShowDialog() == DialogResult.OK)
			{

				carga_xml(archivo.FileName.ToString());
			}
			archivo.Dispose();
			
		}
		private void carga_xml(string archivo)
		{
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(archivo);
			XmlNodeList transferencia = xDoc.GetElementsByTagName("transferencia");

			string nfolio = "";
			string fecha = "";
			string emisor = "";
			string receptor = "";
			double monto = 0;

			string nCantidad = "";
			string codigo1 = "";
			string codigo2 = "";
			string codigo3 = "";
			string codigo4 = "";
			string codigo5 = "";
			string descripcion = "";
			double pu = 0;

			foreach (XmlElement nodo in transferencia)
			{
				nfolio = nodo.GetElementsByTagName("Folio")[0].InnerText;
				fecha = nodo.GetElementsByTagName("Fecha")[0].InnerText;
				emisor = nodo.GetElementsByTagName("Emisor")[0].InnerText;
				receptor = nodo.GetElementsByTagName("Receptor")[0].InnerText;
				monto = Convert.ToDouble(nodo.GetElementsByTagName("Monto")[0].InnerText);
			}
			XmlNodeList productos = ((XmlElement)transferencia[0]).GetElementsByTagName("Productos");
			XmlNodeList producto = ((XmlElement)productos[0]).GetElementsByTagName("Producto");
			foreach (XmlElement any in producto)
			{
				nCantidad = any.GetElementsByTagName("Cantidad")[0].InnerText;
				codigo1 = any.GetElementsByTagName("Codigo1")[0].InnerText;
				codigo2 = any.GetElementsByTagName("Codigo2")[0].InnerText;
				codigo3 = any.GetElementsByTagName("Codigo3")[0].InnerText;
				codigo4 = any.GetElementsByTagName("Codigo4")[0].InnerText;
				codigo5 = any.GetElementsByTagName("Codigo5")[0].InnerText;
				descripcion = any.GetElementsByTagName("Descripcion")[0].InnerText;
				pu = Convert.ToDouble(any.GetElementsByTagName("Pu")[0].InnerText);
			}



			Transfers transferencias = new Transfers();
			transferencias.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd HH:mm:ss",null);
			transferencias.Folio = Convert.ToInt16(nfolio);
			transferencias.Tipo_trapaso = "R";
			Offices oficinas = new Offices();
			List<Offices> oficina = oficinas.GetOfficesbyrfc(emisor);
			transferencias.Sucursal = oficina[0].Id.ToString();
			transferencias.Subtotal = (monto/1.16);
			transferencias.Iva = (monto/1.16)*0.16;
			transferencias.Total = monto;
			transferencias.Facturado = Convert.ToInt16(false) ;
			transferencias.CreateTransfer();


		
			List<Transfers> ultimo = transferencias.getTransferbyfolio(Convert.ToInt16(nfolio), "R");
			Det_transfers detalles = new Det_transfers();


			detalles.Folio = Convert.ToInt16(ultimo[0].Id);
			detalles.Tipo = "R";
			double antes = 0;
			Product prod = new Product();
			foreach (XmlElement any in producto)
			{
				nCantidad = any.GetElementsByTagName("Cantidad")[0].InnerText;
				codigo1 = any.GetElementsByTagName("Codigo1")[0].InnerText;
				codigo2 = any.GetElementsByTagName("Codigo2")[0].InnerText;
				codigo3 = any.GetElementsByTagName("Codigo3")[0].InnerText;
				codigo4 = any.GetElementsByTagName("Codigo4")[0].InnerText;
				codigo5 = any.GetElementsByTagName("Codigo5")[0].InnerText;
				descripcion = any.GetElementsByTagName("Descripcion")[0].InnerText;
				pu = Convert.ToDouble(any.GetElementsByTagName("Pu")[0].InnerText);


				detalles.Cantidad = Convert.ToInt16(any.GetElementsByTagName("Cantidad")[0].InnerText);

				string codigo = "";
				int numerico = 1;

				int id_produto = 0;
				while (id_produto==0 || numerico<6)
				{
					
					codigo= any.GetElementsByTagName("Codigo" + numerico)[0].InnerText; ;
					List<Product> list_producto = prod.getProductByCodeAbsolute(codigo);
					if (list_producto.Count > 0)
					{
						id_produto = list_producto[0].Id;
						antes = list_producto[0].Existencia;
					}
					else
					{
						numerico = numerico + 1;
					}
				}
				if (id_produto == 0)
				{
					DialogResult resultado = MessageBox.Show("El producto " + descripcion + ", no se encuentra en la base de datos ¿Desea agregarlo?", "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (resultado== DialogResult.Yes)
					{
						prod.Code1 = codigo1;
						prod.Code2 = codigo2;
						prod.Code3 = codigo3;
						prod.Code4 = codigo4;
						prod.Code5 = codigo5;
						prod.Description = descripcion;
						prod.Parent = "0";
						prod.Price1 = pu;
						prod.createProduct();

						List<Product> list_producto = prod.getProductByCodeAbsolute(codigo1);
						id_produto = list_producto[0].Id;
						antes = 0;
					}
				}

				detalles.Id_producto = id_produto;
				detalles.Precio = pu;
				detalles.CreateDet();

				Kardex kardex = new Kardex();
				kardex.Id_producto = id_produto;
				kardex.Tipo = "I";
				kardex.Id_documento = ultimo[0].Id;
				kardex.Cantidad = Convert.ToDouble(nCantidad);
				kardex.Antes = antes;
				kardex.CreateKardex();
				List<Kardex> ultimo_kardez = kardex.getidKardex(id_produto, ultimo[0].Id, "I");



				Afecta_inv afecta = new Afecta_inv();
				afecta.Agrega(ultimo_kardez[0].Id);


			}
		}
	}
}
