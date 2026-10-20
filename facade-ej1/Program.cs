using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var agencia = new FacadeAgenciaViajes(); //Instanciamos la fachada, que va a delegar las tareas a las subclases
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("===== AGENCIA DE VIAJES =====");

                Console.WriteLine("Ingrese el destino de su viaje: ");
                string destino = Console.ReadLine(); //destino de nuestro viaje
                Console.WriteLine("Ingrese la fecha del viaje (dd/mm/yyyy): ");
                DateTime fecha = Convert.ToDateTime(Console.ReadLine()); //fecha de nuestro viaje
                Console.WriteLine("Ingrese la cantidad de noches que se va a alojar en el hotel: ");
                int noches = Convert.ToInt32(Console.ReadLine()); // cantidad de noches de nuestro viaje

                Console.WriteLine("1. Reservar paquete (CON fachada)");
                Console.WriteLine("2. Reservar paquete (SIN fachada)");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ReservarConFachada(agencia, destino, fecha, noches); // llamamos al metodo que resuelve el problema con fachada
                        break;
                    case "2":
                        ReservarSinFachada(destino, fecha, noches); // llamamos al metodo que lo resuelve sin fachada
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

        private static void ReservarSinFachada(string destino, DateTime fecha, int cantNoches)
        {
            Console.WriteLine("SIN fachada (el cliente coordina todo): ");

            // Sin la fachada, el cliente va a tener que conocer todas las subclases del sistema, lo que genera acoplamiento

            var vuelos = new ServiceVuelos();
            var hoteles = new ServiceHotel();
            var autos = new ServiceAutos();

            if (vuelos.HayDisponibilidad(destino, fecha)) //1. Simulamos la verificacion de disponibilidad los vuelos.
            {
                vuelos.Reservar(destino, fecha); // 2. Simulamos la reserva del vuelo
                hoteles.Reservar(destino, cantNoches); // 3. Simulamos la reserva del hotel
                autos.Alquilar(destino, cantNoches); // 4. Simulamos la reserva del auto
            }

            //CANTIDAD DE LLAMADAS SIN LA FACHADA: 4
        }

        private static void ReservarConFachada(FacadeAgenciaViajes agencia, string destino, DateTime fecha, int cantNoches)
        {
            Console.WriteLine();

            Console.WriteLine("CON fachada (una sola llamada):");

            agencia.ReservarPaquete(destino, fecha, cantNoches); // 1. Llamamos al metodo de la fachada que delega la responsabilidad a cada subclase.

            //CANTIDAD DE LLAMADAS CON LA FACHADA: 1

            Console.ReadLine();
        }
    }
}
