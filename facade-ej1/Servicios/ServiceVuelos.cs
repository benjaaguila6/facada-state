using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    public class ServiceVuelos
    {
        public bool HayDisponibilidad(string destino, DateTime fecha) // Metodo para verificar si hay vuelos disponibles para esa fecha y destino.
        {
            if (fecha < DateTime.Today) // Validamos que la fecha sea mayor que hoy para evitar fechas invalidas.
            {
                return false;
            }

            Console.WriteLine($"[Vuelos] Consultando vuelos a {destino} para el {fecha:dd/MM/yyyy}..."); // Simulacion de busqueda de disponibilidad.

            return true; // Hay vuelos disponibles
        }

        public string Reservar(string destino, DateTime fecha) //Metodo para registrar la reserva.
        {
            Console.WriteLine("[Vuelos] Vuelo reservado."); // Simulacion de INSERT para la reserva.
            return "VUE-001";
        }

    }
}
