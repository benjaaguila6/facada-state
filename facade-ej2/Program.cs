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
            var checkout = new CheckoutFacade();

            Console.WriteLine("Compra exitosa:");
            checkout.ConfirmarCompra("Zapatillas", 2, 50000m, "Av. Siempre Viva 742", "cliente@mail.com");

            Console.WriteLine();
            Console.WriteLine("Compra sin stock:");
            checkout.ConfirmarCompra("Zapatillas", 50, 500000m, "Av. Siempre Viva 742", "cliente@mail.com");

            Console.ReadLine();
        }
    }
}
