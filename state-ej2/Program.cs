using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== VALIDACIÓN DE CUENTA (PATRÓN STATE) ===");

            // Permitimos configurar la contraseña inicial por teclado (o usar una por defecto)
            Console.Write("Ingrese la contraseña correcta para configurar la cuenta: ");
            string passwordSecreta = Console.ReadLine()?.Trim() ?? "1234";

            var cuenta = new Cuenta(passwordSecreta);
            string opcion = "";

            while (opcion != "2")
            {
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("1. Ingresar contraseña");
                Console.WriteLine("2. Salir");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Elige una opción (1-2): ");

                opcion = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la contraseña: ");
                        string passIngresada = Console.ReadLine()?.Trim() ?? "";

                        int resultado = cuenta.IngresarPassword(passIngresada);

                        // Interpretamos el resultado usando la clase estática Resultado
                        if (resultado == Resultado.Ok)
                        {
                            Console.WriteLine("¡Acceso concedido! Contraseña correcta.");
                            opcion = "2"; // Salimos del programa al acertar
                        }
                        else if (resultado == Resultado.Incorrecta)
                        {
                            Console.WriteLine($"[Error] Contraseña incorrecta. Intentos fallidos: {cuenta.IntentosFallidos}");
                        }
                        else if (resultado == Resultado.Bloqueada)
                        {
                            Console.WriteLine("[Bloqueado] La cuenta está bloqueada por exceder los intentos fallidos.");
                            opcion = "2"; // Salimos al bloquearse
                        }
                        break;

                    case "2":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("[Error] Opción no válida. Ingrese 1 o 2.");
                        break;
                }
            }

            Console.WriteLine("\nFin del programa. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    
    }
}
