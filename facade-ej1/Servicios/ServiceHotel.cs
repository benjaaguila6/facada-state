using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    public class ServiceHotel
    {
        public string Reservar(string destino, int noches) //Metodo para registrar la reserva del hotel
        {
            Console.WriteLine($"[Hoteles] Hotel reservado en {destino} por {noches} noches."); // Simulamos INSERT para la reserva.

            return "HOT-001";
        }
    }
}
