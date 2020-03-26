using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using caja.Models;
using caja.Forms;

namespace caja
{
    public partial class producto : Form
    {
        public static string Codigo;
        public static string SubProducto;
        public static string SubSubProducto;
        public producto()
        {
            InitializeComponent();
        }
       
        public void carga_marcas()
        {
            DataTable table = new DataTable();
            DataRow row;
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));
            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);
            // cboMarca.Items.Clear();
            Marcas marca = new Marcas();
            List<Marcas> result = marca.getMarcas();
            foreach (Marcas item in result)
            {
                row = table.NewRow();
                row["Text"] = item.Marca;
                row["Value"] = item.Marca;
                table.Rows.Add(row);
            }
            cboMarca.BindingContext = new BindingContext();
            cboMarca.DataSource = table;
            cboMarca.DisplayMember = "Text";
            cboMarca.ValueMember = "Value";
            cboMarca.BindingContext = new BindingContext();
        }

        public void carga_box ()
        {

            Product sub = new Product();
            List<Product> item = sub.getProduct(Convert.ToInt32(SubProducto));
            if (item.Any() == true)
            {
                chkCarton.Checked = true;
                foreach (Product prod in item)
                {
                    SubSubProducto = prod.Id.ToString();
                    txtCodigoCarton.Text = prod.Code1;
                    txtSkuCarton.Text = prod.Sku;
                    txtDescripcionCarton.Text = prod.Description;
                    txtCostoCarton.Text = prod.Cost.ToString();
                    txtUtilidad1Ct.Text = prod.Utility1.ToString();
                    txtUtilidad2Ct.Text = prod.Utility2.ToString();
                    txtUtilidad3Ct.Text = prod.Utility3.ToString();

                    txtPrecio1Ct.Text = prod.Price1.ToString();
                    txtPrecio2Ct.Text = prod.Price2.ToString();
                    txtPrecio3Ct.Text = prod.Price3.ToString();
                    txtp_carton.Text = prod.C_unidad;
                }
            }

        }
        public void carga_grupos()
        {
            tvGrupos.Nodes.Clear();
            tvGrupos.ImageList = imageList1;
            tvGrupos.SelectedImageIndex = 1;

            Groups grupos = new Groups();
            List<Groups> grupo = grupos.getGroupsonly();
            foreach (Groups item in grupo)
            {
                TreeNode nodo = new TreeNode(item.Group.ToString());
                nodo.Tag = item.Id.ToString();
                nodo.ImageIndex = 0;
                tvGrupos.Nodes.Add(nodo);

                generarNodes(item.Id, nodo);
            }
            tvGrupos.ExpandAll();
        }
        public void generarNodes(int parentId, TreeNode parentNode)
        {
            Groups grupo = new Groups();
            List<Groups> sub = grupo.getSubgrups(parentId);
            TreeNode childNode;
            foreach (Groups item in sub)
            {
                if (parentNode == null)
                {
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
        private void carga_kardex() {
            Kardex historia = new Kardex();
            List<Kardex> result = historia.getKardex(Convert.ToInt16(Codigo));
            foreach (Kardex item in result) {
                string id = item.Id.ToString();
                string fecha = item.Fecha;
                string folio_documento = item.Id_documento.ToString();
                string antes = item.Antes.ToString();
                string cantidad = item.Cantidad.ToString();
                string tipo = "";
                switch (item.Tipo) {
                    case "E":
                        tipo = "Entrada";
                        break;
                    case "S":
                        tipo = "Salida";
                        break;
                    case "A":
                        tipo = "Ajuste";
                        break;
                    case "V":
                        tipo = "Venta";
                        break;
                    case "T":
                        tipo = "Traspaso";
                        break;
                    case "C":
                        tipo = "Compra";
                        break;
                }
                dtKardex.Rows.Add(id, fecha, tipo, folio_documento, antes, cantidad);
            }
        }
        public void carga_pack(int id)
        {

            Product sub = new Product();
            List<Product> item = sub.getProduct(id);
            if (item.Any()==true) {
                chkCaja.Checked = true;
                foreach (Product prod in item) {
                    SubProducto = prod.Id.ToString();
                    txtCodigoCaja.Text = prod.Code1;
                    txtSkuCaja.Text = prod.Sku;
                    txtDescripcionCaja.Text = prod.Description;
                    txtCostoCaja.Text = prod.Cost.ToString();
                    txtUtilidad1C.Text = prod.Utility1.ToString();
                    txtUtilidad2C.Text = prod.Utility2.ToString();
                    txtUtilidad3C.Text = prod.Utility3.ToString();

                    txtPrecio1C.Text = prod.Price1.ToString();
                    txtPrecio2C.Text = prod.Price2.ToString();
                    txtPrecio3C.Text = prod.Price3.ToString();
                    txtPCaja.Text = prod.C_unidad;
                }
            }
        
        }
        private void CallRecursive(TreeView treeView, string selector)
        {
            // Print each node recursively.  
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n, selector);
            }
        }

        private void PrintRecursive(TreeNode treeNode, string selector)
        {
            // Print the node.  
            System.Diagnostics.Debug.WriteLine(treeNode.Text);
            if (treeNode.Tag.ToString() == selector) {
                tvGrupos.SelectedNode = treeNode;
            }
            //MessageBox.Show(treeNode.Text);
            // Print each node recursively.  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn, selector);
            }
        }

        private void producto_Load(object sender, EventArgs e)
        {

            carga_marcas();
            carga_grupos();

            DataTable table = new DataTable();
            DataRow row;

            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));

            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Pieza";
            row["Value"] = "PZAS";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Kilogramo";
            row["Value"] = "KG";
            table.Rows.Add(row);

            cboUnidad.BindingContext = new BindingContext();

            cboUnidad.DataSource = table;

            cboUnidad.DisplayMember = "Text";

            cboUnidad.ValueMember = "Value";
            cboUnidad.BindingContext = new BindingContext();



            cboVenta.Items.Add("EXENTO IMPUESTOS");
            cboVenta.Items.Add("IVA 11");
            cboVenta.Items.Add("IVA 16");
            cboVenta.Items.Add("IVA TASA CERO");


            cboCompra.Items.Add("EXENTO IMPUESTOS");
            cboCompra.Items.Add("IVA 11");
            cboCompra.Items.Add("IVA 16");
            cboCompra.Items.Add("IVA TASA CERO");

           


            cboVenta.SelectedIndex = 2;
            cboCompra.SelectedIndex = 2;
            if (Codigo != "")
            {
                Product product = new Product();
                List<Product> result = product.getProductById(Convert.ToInt32(Codigo));

                foreach (Product item in result) {
                    txtCodigo1.Text = item.Code1;
                    txtCodigo2.Text = item.Code2;
                    txtCodigo3.Text = item.Code3;
                    txtCodigo4.Text = item.Code4;
                    txtCodigo5.Text = item.Code5;
                    txtDescripcion.Text = item.Description;
                    txtCosto.Text = item.Cost.ToString();
                    txtPercentPrice1.Text = item.Utility1.ToString();
                    txtPercentPrice2.Text = item.Utility2.ToString();
                    txtPercentPrice3.Text = item.Utility3.ToString();
                    txtPercentPrice4.Text = item.Utility4.ToString();
                    txtPercentPrice5.Text = item.Utility5.ToString();
                    txtPrice1.Text = item.Price1.ToString();
                    txtPrice2.Text = item.Price2.ToString();
                    txtPrice3.Text = item.Price3.ToString();
                    txtPrice4.Text = item.Price4.ToString();
                    txtPrice5.Text = item.Price5.ToString();
                    txtExistencia.Text = item.Existencia.ToString();
                    cboMarca.SelectedValue = item.Brand;

                    CallRecursive(tvGrupos, item.Group);


                    cboUnidad.SelectedValue = item.Unit;
                    txtSAT.Text = item.Code_sat;
                    txtUnidadSat.Text = item.Medida_sat;
                    txtMinimo.Text = item.Min.ToString();
                    txtMaximo.Text = item.Max.ToString();
                    chkDescuento.Checked = Convert.ToBoolean(item.Discount);
                    txtDescuento.Text = item.Mount_discount.ToString();

                    if (Convert.ToBoolean(item.Discount) == true)
                    {
                        txtDescuento.Enabled = false;
                    }
                    else
                    {
                        txtDescuento.Enabled = true;
                    }
                    chkLote.Checked = Convert.ToBoolean(item.Lote);

                    txtdias.Text = item.Dias_alerta.ToString();
                    carga_pack(Convert.ToUInt16(Codigo));
                    carga_box();
                    carga_kardex();
                }
            }
            
           


        }

      

        private void textBox8_Leave(object sender, EventArgs e)
        {
           if (Convert.ToDouble(txtPercentPrice1.Text)==0.00)
            {
                txtPrice1.Text = "0.00";
                txtPercentPrice1.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtPercentPrice1.Text)/100)+1;
                txtPrice1.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text)*porcentaje));
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice2.Text.IndexOf('.')))
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice3.Text.IndexOf('.')))
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice4.Text.IndexOf('.')))
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice5.Text.IndexOf('.')))
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

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice2.Text) == 0.00)
            {
                txtPrice2.Text = "0.00";
                txtPercentPrice2.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtPercentPrice2.Text) / 100) + 1;
                txtPrice2.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) * porcentaje));
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice3.Text) == 0.00)
            {
                txtPrice3.Text = "0.00";
                txtPercentPrice3.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtPercentPrice3.Text) / 100) + 1;
                txtPrice3.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) * porcentaje));
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice4.Text) == 0.00)
            {
                txtPrice4.Text = "0.00";
                txtPercentPrice4.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtPercentPrice4.Text) / 100) + 1;
                txtPrice4.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) * porcentaje));
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice5.Text) == 0.00)
            {
                txtPrice5.Text = "0.00";
                txtPercentPrice5.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtPercentPrice5.Text) / 100) + 1;
                txtPrice5.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) * porcentaje));
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice1.Text.IndexOf('.')))
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

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice2.Text.IndexOf('.')))
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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice3.Text.IndexOf('.')))
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

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice4.Text.IndexOf('.')))
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

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice5.Text.IndexOf('.')))
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

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice1.Text) == 0.00)
            {
                txtPrice1.Text = "0.00";
                txtPercentPrice1.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrice1.Text) / Convert.ToDouble(txtCosto.Text)) - 1) * 100;
                txtPercentPrice1.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice2.Text) == 0.00)
            {
                txtPrice2.Text = "0.00";
                txtPercentPrice2.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrice2.Text) / Convert.ToDouble(txtCosto.Text)) - 1) * 100;
                txtPercentPrice2.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice3.Text) == 0.00)
            {
                txtPrice3.Text = "0.00";
                txtPercentPrice3.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrice3.Text) / Convert.ToDouble(txtCosto.Text)) - 1) * 100;
                txtPercentPrice3.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice4.Text) == 0.00)
            {
                txtPrice4.Text = "0.00";
                txtPercentPrice4.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrice4.Text) / Convert.ToDouble(txtCosto.Text)) - 1) * 100;
                txtPercentPrice4.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice5.Text) == 0.00)
            {
                txtPrice5.Text = "0.00";
                txtPercentPrice4.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrice5.Text) / Convert.ToDouble(txtCosto.Text)) - 1) * 100;
                txtPercentPrice4.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {



   
            
            Product product = new Product(
                0,
                txtDescripcion.Text,
                txtCodigo1.Text,
                txtCodigo2.Text,
                txtCodigo3.Text,
                txtCodigo4.Text,
                txtCodigo5.Text,
                0,
                tvGrupos.SelectedNode.Tag.ToString(),
                cboMarca.SelectedValue.ToString(),
                cboUnidad.SelectedValue.ToString(),
                Convert.ToDouble(txtPrice1.Text),
                Convert.ToDouble(txtPrice2.Text),
                Convert.ToDouble(txtPrice3.Text),
                Convert.ToDouble(txtPrice4.Text),
                Convert.ToDouble(txtPrice5.Text),
                Convert.ToDouble(txtPercentPrice1.Text),
                Convert.ToDouble(txtPercentPrice2.Text),
                Convert.ToDouble(txtPercentPrice3.Text),
                Convert.ToDouble(txtPercentPrice4.Text),
                Convert.ToDouble(txtPercentPrice5.Text),
                Convert.ToDouble(txtCosto.Text),
                Convert.ToUInt16(true),
                txtSAT.Text,
                txtSKU.Text,
                txtUnidadSat.Text,
                cboVenta.SelectedItem.ToString(),
                cboCompra.SelectedItem.ToString(),
                Convert.ToUInt16(chkDescuento.Checked),
                Convert.ToUInt16(txtDescuento.Text),
                Convert.ToUInt16(txtMinimo.Text),
                Convert.ToUInt16(txtMaximo.Text),
                "0",
                "0",
                Convert.ToUInt16(txtdias.Text),
                Convert.ToUInt16(chkLote.Checked),
                0,
                0,
                0,
                0,
                0
                );

            if (Codigo == "")
            {
                product.createProduct();
                List<Product> result = product.getProductByCode(txtCodigo1.Text);
                foreach (Product item in result) {
                    Codigo = item.Id.ToString();
                }
            }
            else
            {
                product.Id = Convert.ToInt32(Codigo);
                product.saveProduct();
            }

            if (chkCaja.Checked == true )
            {

                

                Product subproduct = new Product(
                0,
                txtDescripcionCaja.Text,
                txtCodigoCaja.Text,
                "",
                "",
                "",
                "",
                0,
                tvGrupos.SelectedNode.Tag.ToString(),
                cboMarca.SelectedValue.ToString(),
                cboUnidad.SelectedValue.ToString(),
                Convert.ToDouble(txtPrecio1C.Text),
                Convert.ToDouble(txtPrecio2C.Text),
                Convert.ToDouble(txtPrecio3C.Text),
                Convert.ToDouble("0"),
                Convert.ToDouble("0"),
                Convert.ToDouble(txtUtilidad1C.Text),
                Convert.ToDouble(txtUtilidad2C.Text),
                Convert.ToDouble(txtUtilidad3C.Text),
                Convert.ToDouble("0"),
                Convert.ToDouble("0"),
                Convert.ToDouble(txtCostoCaja.Text),
                Convert.ToUInt16(true),
                txtSAT.Text,
                txtSkuCaja.Text,
                txtUnidadSat.Text,
                cboVenta.SelectedItem.ToString(),
                cboCompra.SelectedItem.ToString(),
                Convert.ToUInt16("0"),
                Convert.ToUInt16("0"),
                Convert.ToUInt16("0"),
                Convert.ToUInt16("0"),
                Codigo.ToString(),
                txtPCaja.Text,
                Convert.ToUInt16(txtdias.Text),
                Convert.ToUInt16(chkLote.Checked),
                0,
                0,
                0,
                0,
                0
                );

                if (Codigo == "")
                {
                    subproduct.createProduct();
                    List<Product> result = product.getProductByCode(txtCodigo1.Text);
                    foreach (Product item in result)
                    {
                        SubProducto = item.Id.ToString();
                    }
                }
                else {
                    subproduct.Id = Convert.ToInt16(SubProducto);
                    subproduct.saveProduct();
                }
                    

               

            }
            if (chkCarton.Checked == true) {
                Product subsub = new Product(
                   0,
                   txtDescripcionCarton.Text,
                   txtCodigoCarton.Text,
                   "",
                   "",
                   "",
                   "",
                   0,
                   tvGrupos.SelectedNode.Tag.ToString(),
                   cboMarca.SelectedValue.ToString(),
                   cboUnidad.SelectedValue.ToString(),
                   Convert.ToDouble(txtPrecio1Ct.Text),
                   Convert.ToDouble(txtPrecio2Ct.Text),
                   Convert.ToDouble(txtPrecio3Ct.Text),
                   Convert.ToDouble("0"),
                   Convert.ToDouble("0"),
                   Convert.ToDouble(txtUtilidad1Ct.Text),
                   Convert.ToDouble(txtUtilidad2Ct.Text),
                   Convert.ToDouble(txtUtilidad3Ct.Text),
                   Convert.ToDouble("0"),
                   Convert.ToDouble("0"),
                   Convert.ToDouble(txtCostoCarton.Text),
                   Convert.ToUInt16(true),
                   txtSAT.Text,
                   txtSkuCarton.Text,
                   txtUnidadSat.Text,
                   cboVenta.SelectedItem.ToString(),
                   cboCompra.SelectedItem.ToString(),
                   Convert.ToUInt16("0"),
                   Convert.ToUInt16("0"),
                   Convert.ToUInt16("0"),
                   Convert.ToUInt16("0"),
                   SubProducto.ToString(),
                   txtp_carton.Text,
                   Convert.ToUInt16(txtdias.Text),
                   Convert.ToUInt16(chkLote.Checked),
                   0,
                   0,
                   0,
                   0,
                   0
                   );
                if (Codigo == "")
                {
                    subsub.createProduct();
                }
                else
                {
                    subsub.Id = Convert.ToInt16(SubSubProducto);
                    subsub.saveProduct();
                }

            }
            
            this.Close();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            string mensaje, titulo;
            object myValue;
            mensaje = "Ingrese la nueva marca a agregar";
            titulo = "Nueva Marca";
            myValue = Interaction.InputBox(mensaje, titulo);
            if (myValue.ToString() != "")
            {

               
                Marcas marca = new Marcas(
                    0,
                    myValue.ToString()
                    );
                marca.createMarca();
                carga_marcas();
                cboMarca.Text = myValue.ToString();
                
            }
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDescuento.Checked == true)
            {
                txtDescuento.Enabled = true;
            }
            else
            {
                txtDescuento.Enabled = false;
            }
            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
            }
        }

        private void txtSAT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            busca_ClaveSAT clave_sat = new busca_ClaveSAT();
            clave_sat.Owner = this;
            clave_sat.Show();
        }

        private void txtUnidadSat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            busca_unidadSAT unidad_Sat = new busca_unidadSAT();
            unidad_Sat.Owner = this;
            unidad_Sat.Show();
        }

      

        private void chkCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCaja.Checked == true) {
                txtCodigoCaja.Enabled = true;
                txtDescripcionCaja.Enabled = true;
                txtSkuCaja.Enabled = true;
                txtPCaja.Enabled = true;
                txtCostoCaja.Enabled = true;
                txtUtilidad1C.Enabled = true;
                txtUtilidad2C.Enabled = true;
                txtUtilidad3C.Enabled = true;
                txtPrecio1C.Enabled = true;
                txtPrecio2C.Enabled = true;
                txtPrecio3C.Enabled = true;
            }
            else
            {
                txtCodigoCaja.Enabled = false;
                txtDescripcionCaja.Enabled = false;
                txtSkuCaja.Enabled = false;
                txtPCaja.Enabled = false;
                txtCostoCaja.Enabled = false;
                txtUtilidad1C.Enabled = false;
                txtUtilidad2C.Enabled = false;
                txtUtilidad3C.Enabled = false;
                txtPrecio1C.Enabled = false;
                txtPrecio2C.Enabled = false;
                txtPrecio3C.Enabled = false;
            }
        }

        private void txtPercentPrice1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice1.Text.IndexOf('.')))
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

        private void txtUtilidad1C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad1C.Text.IndexOf('.')))
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

        private void txtUtilidad2C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad2C.Text.IndexOf('.')))
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

        private void txtUtilidad3C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad3C.Text.IndexOf('.')))
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

        private void txtPrecio1C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio1C.Text.IndexOf('.')))
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

        private void txtPrecio2C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio2C.Text.IndexOf('.')))
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

        private void txtPrecio3C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio3C.Text.IndexOf('.')))
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

        private void txtUtilidad1C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad1C.Text) == 0.00)
            {
                txtPrecio1C.Text = "0.00";
                txtUtilidad1C.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad1C.Text) / 100) + 1;
                txtPrecio1C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) * porcentaje));
            }
        }

        private void txtUtilidad2C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad2C.Text) == 0.00)
            {
                txtPrecio2C.Text = "0.00";
                txtUtilidad2C.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad2C.Text) / 100) + 1;
                txtPrecio2C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) * porcentaje));
            }
        }

        private void txtUtilidad3C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad3C.Text) == 0.00)
            {
                txtPrecio3C.Text = "0.00";
                txtUtilidad3C.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad3C.Text) / 100) + 1;
                txtPrecio3C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) * porcentaje));
            }
        }

        private void txtPrecio1C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio1C.Text) == 0.00)
            {
                txtPrecio1C.Text = "0.00";
                txtUtilidad1C.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio1C.Text) / Convert.ToDouble(txtCostoCaja.Text)) - 1) * 100;
                txtUtilidad1C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPrecio2C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio2C.Text) == 0.00)
            {
                txtPrecio2C.Text = "0.00";
                txtUtilidad2C.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio2C.Text) / Convert.ToDouble(txtCostoCaja.Text)) - 1) * 100;
                txtUtilidad2C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPrecio3C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio3C.Text) == 0.00)
            {
                txtPrecio3C.Text = "0.00";
                txtUtilidad3C.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio3C.Text) / Convert.ToDouble(txtCostoCaja.Text)) - 1) * 100;
                txtUtilidad3C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void chkCarton_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCarton.Checked == true)
            {
                txtCodigoCarton.Enabled = true;
                txtSkuCarton.Enabled = true;
                txtp_carton.Enabled = true;
                txtDescripcionCarton.Enabled = true;
                txtCostoCarton.Enabled = true;
                txtUtilidad1Ct.Enabled = true;
                txtUtilidad2Ct.Enabled = true;
                txtUtilidad3Ct.Enabled = true;
                txtPrecio1Ct.Enabled = true;
                txtPrecio2Ct.Enabled = true;
                txtPrecio3Ct.Enabled = true;
            } else {
                txtCodigoCarton.Enabled = false;
                txtSkuCarton.Enabled = false;
                txtp_carton.Enabled = false;
                txtDescripcionCarton.Enabled = false;
                txtCostoCarton.Enabled = false;
                txtUtilidad1Ct.Enabled = false;
                txtUtilidad2Ct.Enabled = false;
                txtUtilidad3Ct.Enabled = false;
                txtPrecio1Ct.Enabled = false;
                txtPrecio2Ct.Enabled = false;
                txtPrecio3Ct.Enabled = false;
            }
        }

        private void txtUtilidad1Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad1Ct.Text.IndexOf('.')))
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

        private void txtUtilidad2Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad2Ct.Text.IndexOf('.')))
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

        private void txtUtilidad3Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad3Ct.Text.IndexOf('.')))
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

        private void txtPrecio1Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio1Ct.Text.IndexOf('.')))
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

        private void txtPrecio2Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio2Ct.Text.IndexOf('.')))
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

        private void txtPrecio3Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio3Ct.Text.IndexOf('.')))
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

        private void txtUtilidad1Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad1Ct.Text) == 0.00)
            {
                txtPrecio1Ct.Text = "0.00";
                txtUtilidad1Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad1Ct.Text) / 100) + 1;
                txtPrecio1Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) * porcentaje));
            }
        }

        private void txtUtilidad2Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad2Ct.Text) == 0.00)
            {
                txtPrecio2Ct.Text = "0.00";
                txtUtilidad2Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad2Ct.Text) / 100) + 1;
                txtPrecio2Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) * porcentaje));
            }
        }

        private void txtUtilidad3Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad3Ct.Text) == 0.00)
            {
                txtPrecio3Ct.Text = "0.00";
                txtUtilidad3Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (Convert.ToDouble(txtUtilidad3Ct.Text) / 100) + 1;
                txtPrecio3Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) * porcentaje));
            }
        }

        private void txtPrecio1Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio1Ct.Text) == 0.00)
            {
                txtPrecio1Ct.Text = "0.00";
                txtUtilidad1Ct.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio1Ct.Text) / Convert.ToDouble(txtCostoCarton.Text)) - 1) * 100;
                txtUtilidad1Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPrecio2Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio2Ct.Text) == 0.00)
            {
                txtPrecio2Ct.Text = "0.00";
                txtUtilidad2Ct.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio2Ct.Text) / Convert.ToDouble(txtCostoCarton.Text)) - 1) * 100;
                txtUtilidad2Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPrecio3Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio3Ct.Text) == 0.00)
            {
                txtPrecio3Ct.Text = "0.00";
                txtUtilidad3Ct.Text = "0.00";
            }
            else
            {
                double diferencia = ((Convert.ToDouble(txtPrecio3Ct.Text) / Convert.ToDouble(txtCostoCarton.Text)) - 1) * 100;
                txtUtilidad3Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void dtKardex_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dtKardex.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dtKardex.Rows[selectedrowindex];
            string folio = Convert.ToString(selectedRow.Cells["folio"].Value);
            string tipo = selectedRow.Cells["tipo"].Value.ToString();


            switch (tipo)
            {
                case "Entrada":

                    Forms.Inventario.Form_entrada.folio = folio;
                    Forms.Inventario.Form_entrada.Entrada = "kardex";
                    Forms.Inventario.Form_entrada new_entrada = new Forms.Inventario.Form_entrada();
                    
                    new_entrada.Owner = this;
                    new_entrada.Show();
                    break;
                case "Salida":

                    Forms.Inventario.Form_salida.folio = folio;
                    Forms.Inventario.Form_salida.Entrada = "kardex";
                    Forms.Inventario.Form_salida new_salida = new Forms.Inventario.Form_salida();
                    new_salida.Owner=this;
                    new_salida.Show();

                    break;
                case "Ajuste":
                    Forms.Inventario.Form_ajustes.folio = folio;
                    Forms.Inventario.Form_ajustes new_ajuste = new Forms.Inventario.Form_ajustes();
                    new_ajuste.Owner = this;
                    new_ajuste.Show();
                    break;
                case "Venta":
                    break;
                case "Traspaso":
                    break;
                case "Compra":
                    Form_compras.folio = folio;
                    Form_compras new_compra = new Form_compras();
                    new_compra.Owner = this;
                    new_compra.Show();
                    break;
            }


        }

       
    }
}
 