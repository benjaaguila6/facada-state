using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    public class ServiceAutos
    {
        public string Alquilar(string destino, int dias) //Metodo para registrar el alquiler de un auto.
        {
            Console.WriteLine($"[Autos] Auto alquilado en {destino} por {dias} días."); // Simulacion de INSERT para el alquiler del auto
            return "AUT-001";
        }
    }
}
