using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    public class FacadeAgenciaViajes // Fachada puerta de entrada para el program.cs
    {
        // Subclases del sistema de la agencia.
        private readonly ServiceVuelos _vuelos = new ServiceVuelos(); // Inicializamos el servicio de vuelos
        private readonly ServiceHotel _hoteles = new ServiceHotel(); // Inicializamos el servicio de hoteles
        private readonly ServiceAutos _autos = new ServiceAutos(); // Inicializamos el servicio de autos

        public void ReservarPaquete(string destino, DateTime fechaSalida, int noches) // Metodo que deriva a las subclases
        {
            if (!_vuelos.HayDisponibilidad(destino, fechaSalida)) // Primero llamamos al metodo de verificacion del servicio de vuelos
            {
                Console.WriteLine("La fecha es invalida."); // En caso de que la fecha sea menor a hoy
                return;
            }

            //Delegamos la responsabilidad a las subclases en el orden correcto.

            string vuelo = _vuelos.Reservar(destino, fechaSalida); // Simulacion de INSERT
            string hotel = _hoteles.Reservar(destino, noches); // Simulacion de INSERT
            string auto = _autos.Alquilar(destino, noches); // Simulacion de INSERT

            Console.WriteLine($"[FACHADA] Paquete confirmado: {vuelo} | {hotel} | {auto}");
        }
    }
}
