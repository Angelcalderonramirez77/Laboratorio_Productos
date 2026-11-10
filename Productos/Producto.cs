using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    internal class Producto
    {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
        
        public Producto (string codigo, string nombre, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad; 
        }
        public void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================");
            Console.WriteLine($"Código: {Codigo}, Nombre: {Nombre}, Precio: RD${Precio:N2}, Cantidad: {Cantidad:N2}");
            Console.WriteLine("====================================================");
            Console.ResetColor();
        }

        public decimal CalcularValorTotal(decimal precio, int cantidad)
        {
            Precio =precio * cantidad;
            return Precio;
        }

    }

}
