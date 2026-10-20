using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var checkout = new CheckoutFacade(); // Instanciamos la facade que orquestara a las subclases 
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("===== TIENDA ONLINE =====");
                Console.WriteLine("1. Confirmar una compra");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Comprar(checkout);
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        static void Comprar(CheckoutFacade checkout)
        {
            Console.WriteLine("(Simulación: hay stock hasta 10 unidades; el pago se rechaza si el monto es 0)");

            //Datos que introducimos
            string producto = Entrada.Texto("Producto: ");
            int cantidad = Entrada.Entero("Cantidad: ", 1);
            decimal monto = Entrada.Monto("Monto a pagar: ");
            string direccion = Entrada.Texto("Dirección de envío: ");
            string email = Entrada.Texto("Email: ");

            Console.WriteLine();
            bool ok = checkout.ConfirmarCompra(producto, cantidad, monto, direccion, email); // llamamos al metodo de la fachada para realizar la compra.
            Console.WriteLine(ok ? ">> Compra realizada con éxito." : ">> La compra no se pudo realizar.");
        }
    }

        static class Entrada
        {
            public static string Texto(string mensaje)
            {
                while (true)
                {
                    Console.Write(mensaje);
                    string valor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(valor)) return valor.Trim();
                    Console.WriteLine("El valor no puede estar vacío.");
                }
            }

            public static int Entero(string mensaje, int minimo)
            {
                while (true)
                {
                    Console.Write(mensaje);
                    if (int.TryParse(Console.ReadLine(), out int numero) && numero >= minimo)
                        return numero;
                    Console.WriteLine($"Ingresá un número entero mayor o igual a {minimo}.");
                }
            }

            public static decimal Monto(string mensaje)
            {
                while (true)
                {
                    Console.Write(mensaje);
                    if (decimal.TryParse(Console.ReadLine(), out decimal monto) && monto >= 0)
                        return monto;
                    Console.WriteLine("Ingresá un monto válido (por ejemplo 15000 o 15000,50).");
                }
            }
        }
}
