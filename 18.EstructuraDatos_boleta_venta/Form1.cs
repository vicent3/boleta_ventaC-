using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18.EstructuraDatos_boleta_venta
{
    public partial class Form1 : Form
    {
        double precioProducto;
        int numero;
        static List<Boleta> datos = new List<Boleta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {

            if (txtCliente.Text.Trim() == "" )
            {
                errorProvider1.SetError(txtCliente, "No se admite espacio vacio");
               
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDireccion, "No se admite espacio vacio");
            }
            else if (txtDNI.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDNI, "No se admite espacio vacio");
            }
            else if (cobProducto.SelectedItem == null || cobProducto.Text.Trim() == "")
            {
                errorProvider1.SetError(cobProducto, "Seleccione uno");
            }
            else if (txtCantidad.Text.Trim() == "")
            {
                errorProvider1.SetError(txtCantidad, "No se admite espacio vacio");
            } 
            
            else
            {
                errorProvider1.Clear();
                double importe;
                Boleta producto = new Boleta
                {
                    NumBoleta = numero,
                    Nombre = txtCliente.Text,
                    Direccion = txtDireccion.Text,
                    Dni = int.Parse(txtDNI.Text),
                    FechaRegistro = DateTime.Now.Year.ToString(),
                    Descripcion = cobProducto.SelectedItem.ToString(),
                    Cantidad = int.Parse(txtCantidad.Text),
                };

                importe = producto.calcularImporte(precioProducto, int.Parse(txtCantidad.Text));

                dgvDetalle.Rows.Add(producto.Cantidad, producto.Descripcion, precioProducto, importe);

                double suma = 0;
                foreach (DataGridViewRow columna in dgvDetalle.Rows)
                {
                    suma = suma + Convert.ToDouble(columna.Cells[3].Value);
                }

                lblTotal.Text = "$" + suma.ToString();
            }

            

    }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            lblNumero.Text = DateTime.Now.Year.ToString() + "  -  " + "00000";
        }

       
        private void cobProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boleta precio = new Boleta();
            precioProducto = precio.determinaPrecio(cobProducto.SelectedItem.ToString());
            txtPrecio.Text = "$" + precioProducto.ToString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() == "")
            {
                errorProvider1.SetError(txtCliente, "No se admite espacio vacio");

            }
            else if (txtDireccion.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDireccion, "No se admite espacio vacio");
            }
            else if (txtDNI.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDNI, "No se admite espacio vacio");
            }
            else if (cobProducto.SelectedItem == null || cobProducto.Text.Trim() == "")
            {
                errorProvider1.SetError(cobProducto, "Seleccione uno");
            }
            else if (txtCantidad.Text.Trim() == "")
            {
                errorProvider1.SetError(txtCantidad, "No se admite espacio vacio");
            }
            else
            {

                numero++;
                lblNumero.Text = DateTime.Now.Year.ToString() + "  -  " + numero.ToString("00000");

                double suma = 0;
                foreach (DataGridViewRow columna in dgvDetalle.Rows)
                {
                    suma = suma + Convert.ToDouble(columna.Cells[0].Value);
                }

                dgvEstadistica.Rows.Add(lblNumero.Text, txtFecha.Text, suma, lblTotal.Text);

                txtCliente.Text = "";
                txtCantidad.Text = "";
                txtDNI.Text = "";
                txtDireccion.Text = "";
                cobProducto.ResetText();
                dgvDetalle.Rows.Clear();
                lblTotal.Text = "0";

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvDetalle.Rows[e.RowIndex];
                string mensaje = "¿Deseas eliminar la fila?";
                string titulo = "eliminar fila";
                DialogResult eliminar = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (eliminar == DialogResult.Yes)
                {
                    dgvDetalle.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dgvEstadistica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvEstadistica.Rows[e.RowIndex];
                string mensaje = "¿Deseas eliminar la fila?";
                string titulo = "eliminar fila";
                DialogResult eliminar = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (eliminar == DialogResult.Yes)
                {
                    dgvEstadistica.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
