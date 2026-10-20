using state_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REPRODUCTOR DE AUDIO (PATRÓN STATE) ===");
            var player = new AudioPlayer();
            string opcion = "";

            while (opcion != "5")
            {
                // Información rápida en pantalla
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"[Estado: {player.GetType().Name}] | [Canción: {player.CancionActual}] | [Pos: {player.Posicion}s]");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("1. Play / Stop");
                Console.WriteLine("2. Bloquear / Desbloquear");
                Console.WriteLine("3. Siguiente (1 clic / Doble clic)");
                Console.WriteLine("4. Anterior (1 clic / Doble clic)");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción (1-5): ");

                opcion = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        player.ClickPlay();
                        break;
                    case "2":
                        player.ClickBloqueo();
                        break;
                    case "3":
                        player.ClickSiguiente(PreguntarDobleClic());
                        break;
                    case "4":
                        player.ClickAnterior(PreguntarDobleClic());
                        break;
                    case "5":
                        Console.WriteLine("¡Saliendo del reproductor!");
                        break;
                    default:
                        Console.WriteLine("[Error] Opción no válida. Ingrese un número del 1 al 5.");
                        break;
                }
            }
        }

        // Método auxiliar corto para validar el doble clic
        private static bool PreguntarDobleClic()
        {
            Console.Write("¿Es doble clic? (s/n): ");
            string respuesta = Console.ReadLine()?.Trim().ToLower();
            return respuesta == "s" || respuesta == "si";
        }
    }

}
    

