using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    public class ServicioPago
    {
        public bool Cobrar(decimal monto) // Metodo para simular cobrar, ya que no manejamos precio del producto.
        {
            Console.WriteLine($"[Pago] Cobrando ${monto}...");

            return monto > 0; //Retornamos true si el monto es mayor a 0
        }
    }
}
