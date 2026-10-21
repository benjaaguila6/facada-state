using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    public class Activa : IEstadoCuenta
    {
        private const int MaxIntentos = 3;

        public bool IngresarPassword(Cuenta cuenta, string password)
        {
            // Si la contraseña es correcta, reseteamos intentos y damos acceso
            if (cuenta.EsPasswordCorrecta(password))
            {
                cuenta.IntentosFallidos = 0;
                Console.WriteLine("   ¡Acceso concedido! Contraseña correcta.");
                return true;
            }

            // Si es incorrecta, sumamos intentos
            cuenta.IntentosFallidos++;
            Console.WriteLine($"   [Error] Contraseña incorrecta. Intentos fallidos: {cuenta.IntentosFallidos}/{MaxIntentos}");

            // Si llega al límite, cambiamos al estado Bloqueada
            if (cuenta.IntentosFallidos >= MaxIntentos)
            {
                cuenta.SetState(new Bloqueada());
                Console.WriteLine("   [Alerta] La cuenta ha sido BLOQUEADA por superar los intentos.");
            }

            return false;
        }
    }
}
