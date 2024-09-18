using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _18.EstructuraDatos_boleta_venta
{
    internal class Boleta
    {
        int numBoleta;
        string nombre;
        string direccion;
        int dni;
        string fechaRegistro;
        string descripcion;
        int cantidad;

        public Boleta(int numBoleta, string nombre, string direccion, int dni, string fechaRegistro, string descripcion, int cantidad)
        {
            this.numBoleta = numBoleta;
            this.nombre = nombre;
            this.direccion = direccion;
            this.dni = dni;
            this.fechaRegistro = fechaRegistro;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
        }

        public Boleta()
        {
        }

        public int NumBoleta { get => numBoleta; set => numBoleta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Dni { get => dni; set => dni = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public double determinaPrecio(string producto)
        {
            double precio = 0;
            switch (producto)
            {
                case "PS4 + 1 MANDO DS4":
                    precio = 2049.00;
                    break;
                case "PS4 + 2 MANDO DS4":
                    precio = 1899.00;
                    break;
                case "PS3 (500GB)":
                    precio = 1349.00;
                    break;
                case "MANDO PS4/DS4":
                    precio = 219.00;
                    break;
                case "MANDO PS3/DS4":
                    precio = 199.00;
                    break;
            }
            return precio;
        }

        public double calcularImporte(double precio, int cantidad)
        {
            
            double total = precio * cantidad;

            return total;
        }


    }
}
