using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime salida = new DateTime(2027, 1, 15);

            Console.WriteLine("SIN fachada (el cliente coordina todo): ");

            // Sin la fachada, el cliente va a tener que conocer todas las subclases del sistema, lo que genera acoplamiento

            var vuelos = new ServiceVuelos();
            var hoteles = new ServiceHotel();
            var autos = new ServiceAutos();
            
            if (vuelos.HayDisponibilidad("Bariloche", salida)) //1. Simulamos la verificacion de disponibilidad los vuelos.
            {
                vuelos.Reservar("Bariloche", salida); // 2. Simulamos la reserva del vuelo
                hoteles.Reservar("Bariloche", 7); // 3. Simulamos la reserva del hotel
                autos.Alquilar("Bariloche", 7); // 4. Simulamos la reserva del auto
            }

            //CANTIDAD DE LLAMADAS SIN LA FACHADA: 4

            Console.WriteLine();
            
            Console.WriteLine("CON fachada (una sola llamada):");
            
            var agencia = new FacadeAgenciaViajes(); //Instanciamos la fachada, que va a delegar las tareas a las subclases
            
            agencia.ReservarPaquete("Bariloche", salida, 7); // 1. Llamamos al metodo de la fachada que delega la responsabilidad a cada subclase.

            //CANTIDAD DE LLAMADAS CON LA FACHADA: 1

            Console.ReadLine(); 
        }
    }
}
