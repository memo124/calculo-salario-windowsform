using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Laboratorio1
{
    public partial class Form1 : Form
    {
        public List<Articulo> articulos;
        public List<detalle> detalle;
        public double total = 0;
        public Form1()
        {
            InitializeComponent();
            articulos = new List<Articulo>();
            detalle = new List<detalle>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            articulos.Add(new Articulo(1, "Camisa", 15.00));
            articulos.Add(new Articulo(2, "Cinturón", 8.00));
            articulos.Add(new Articulo(3, "Zapatos", 40.00));
            articulos.Add(new Articulo(4, "Pantalón", 25.00));
            articulos.Add(new Articulo(5, "Calcetines", 2.50));
            articulos.Add(new Articulo(6, "Faldas", 18.00));
            articulos.Add(new Articulo(7, "Gorras", 9.00));
            articulos.Add(new Articulo(8, "Suéter", 19.00));
            articulos.Add(new Articulo(9, "Corbatas", 12.00));
            articulos.Add(new Articulo(10, "Chaquetas", 35.00));
            foreach (Articulo articulo in articulos)
            {
                comboBox1.Items.Add(articulo.articulo);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridView1.Columns.Add("producto", "producto");
            dataGridView1.Columns.Add("precio", "precio");
            dataGridView1.Columns.Add("cantidad", "cantidad");
            dataGridView1.AllowUserToResizeColumns = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void generarTabla()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in detalle)
            {
                dataGridView1.Rows.Add(item.producto,item.precio,item.cantidad);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             double precio = 0;
            int cantidad = int.Parse(txtcantidad.Text);
            if (cantidad<=0)
            {
                MessageBox.Show("Favor ingresar una cantidad a llevar");
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Favor seleccionar un producto");
                return;
            }
            string Articulo = comboBox1.SelectedItem.ToString();
            
            foreach (Articulo articulo in articulos)
            {
                if (articulo.articulo.Equals(comboBox1.SelectedItem.ToString())) 
                { 
                    precio = articulo.precio; 
                }
            }
            // Calcular el total sin aplicar descuentos
            double totalSinDescuento = total + (cantidad * precio);

            // Aplicar los descuentos según el total sin descuento
            if (totalSinDescuento <= 100)
            {
                mensaje.Text = "No aplica en la promoción";
            }
            else if (totalSinDescuento >= 101 && totalSinDescuento <= 299)
            {
                totalSinDescuento -= totalSinDescuento * 0.15;
                mensaje.Text = "Descuento del 15%";
            }
            else if (totalSinDescuento >= 300 && totalSinDescuento <= 499)
            {
                totalSinDescuento -= totalSinDescuento * 0.25;
                mensaje.Text = "Descuento del 25%";
            }
            else if (totalSinDescuento >= 500)
            {
                totalSinDescuento -= totalSinDescuento * 0.30;
                mensaje.Text = "Felicidades, has ganado un producto promocional";
            }
            total = totalSinDescuento;
            lbtotal.Text = total.ToString();
            label5.Text = $"${totalSinDescuento}";
            this.detalle.Add( new
                detalle()
                {
                cantidad = cantidad,
                precio = precio,
                producto = Articulo
            });
            generarTabla();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
