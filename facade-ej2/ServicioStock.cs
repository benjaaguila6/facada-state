using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    public class ServicioStock
    {
        public bool HayStock(string producto, int cantidad) // Validacion del stock
        {
            if(cantidad <= 0) // Si ingresamos un numero negativo
            {
                throw new Exception("La cantidad debe ser mayor a 0");
            }
            
            Console.WriteLine($"[Stock] Verificando stock de {cantidad} x {producto}...");
            
            return cantidad <= 10; // simulación: máximo 10 unidades disponibles
        }

        public void Descontar(string producto, int cantidad) // Metodo para simular que se desconto el stock
        {
            Console.WriteLine($"[Stock] Descontando {cantidad} x {producto}.");
        }
    }
}
