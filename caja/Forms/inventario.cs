using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caja.Models;


namespace caja
{
    public partial class inventario : Form
    {
        public inventario()
        {
            InitializeComponent();
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            carga();
        }
        public void  carga()
        {
            dataGridView1.Rows.Clear();
            Product product = new Product();
            using (product)
            {
                List<Product> result = product.getProductNoSub();

                foreach (Product item in result)
                {
                    dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, (item.Existencia + item.Devoluciones), item.Price1, item.Price2, item.Price2, item.Price4, item.Price5);
                }
            }
           
          
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
            producto.Codigo = codigo;
            producto Producto = new producto();
            Producto.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producto.Codigo = "";
            producto Producto = new producto();

            Producto.Show(this); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    carga();

                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string bus_descripcion = textBox1.Text;


                    Product product = new Product();
                    using (product)
                    {
                        List<Product> result = product.getProductByDescription(bus_descripcion);

                        foreach (Product item in result)
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, (item.Existencia + item.Devoluciones), item.Price1, item.Price2, item.Price2, item.Price4, item.Price5);

                        }
                    }
                    

                }
                
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == "")
                {
                    carga();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string codigo_buscar = textBox2.Text;
                    Product product = new Product();
                    using (product)
                    {
                        List<Product> result = product.getProductByCode(codigo_buscar);

                        foreach (Product item in result)
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, (item.Existencia + item.Devoluciones), item.Price1, item.Price2, item.Price2, item.Price4, item.Price5);

                        }
                    }
                   
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string codigo_buscar = textBox2.Text;
            Product product = new Product();
            using (product)
            {
                List<Product> result = product.getCaducProducts();

                foreach (Product item in result)
                {
                    dataGridView1.Rows.Add(item.Code1, item.Code2, item.Code3, item.Code4, item.Code5, item.Description, item.Description, item.Price1, item.Price2, item.Price2, item.Price4, item.Price5);
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            carga();
        }
    }
}
