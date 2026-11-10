using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte opciones = 0;
            List<Producto> productos = new List<Producto>();
            do
            {
                MostrarBienvenida();
                MostrarMenu();
                
                Console.Write("Ingrese una opción: ");
                while (!byte.TryParse(Console.ReadLine(), out opciones))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Ingrese una opción válida.");
                    Console.Write("Intente de nuevo: ");
                    Console.ResetColor();
                }
                switch (opciones)
                {
                    case 1:
                        // Lógica para agregar producto

                        Console.Write("Ingrese el código del producto: ");
                        string codigo = Console.ReadLine();

                        Console.Write("Ingrese el nombre del producto: ");
                        string nombre = Console.ReadLine();

                        decimal precio;
                        Console.Write("Ingrese el precio del producto: ");
                        while (!decimal.TryParse(Console.ReadLine(), out  precio) || precio < 0)
                        {
                            MostrarMensajeError("Error: Ingrese un precio válido.");
                            Console.Write("Ingrese el precio del producto: ");
                        }

                        // es obligatorio declarar la vaviable primero antes para que apareza en el while, ya que si se declara dentro del while no se puede usar fuera de el
                        int cantidad;
                        Console.Write("Ingrese la cantidad del producto: ");
                        while (!int.TryParse(Console.ReadLine(), out  cantidad) || cantidad < 0)
                        {
                            MostrarMensajeError("Error: Ingrese una cantidad válida.");
                        }

                        Producto producto = new Producto(codigo,nombre, precio, cantidad);

                        productos.Add(producto);

                        break;

                    case 2:

                        if (productos.Count ==0)
                        {
                           MostrarConsola("No hay productos para mostrar.");
                        }
                        else
                        {
                            foreach (Producto prod in productos)
                            {
                                prod.MostrarInformacion();
                            }
                        }
                        break;
                    case 3:
                        // Lógica para calcular valor total
                        decimal valorTotal = 0;
                        foreach (Producto prod in productos)
                        {
                            valorTotal += prod.Precio * prod.Cantidad;
                        }
                        MostrarConsola($"El valor total de los productos es: RD${valorTotal:N2}");
                        
                        break;
                    case 4:
                        MostrarConsola("Saliendo del programa...");
                        break;

                    default:
                        MostrarMensajeError("Opción no válida. Elija entre 1 y 4.");
                        break;
                }
            }
            while(opciones != 4);

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }
        public static void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        public static void MostrarConsola(string mensajeConsola)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensajeConsola);
            Console.ResetColor();
        }
        public static void MostrarBienvenida()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================================");
            Console.WriteLine("### BIENVENIDO AL SISTEMA DE GESTIÓN DE PRODUCTOS ### \n");
            Console.WriteLine("=====================================================");
            Console.ResetColor();
        }
        public static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("### MENU DE OPCIONES ### ");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Calcular valor total");
            Console.WriteLine("4. Salir");
            Console.ResetColor();


        }

    }
}
