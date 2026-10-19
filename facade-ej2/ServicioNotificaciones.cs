using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    public class ServicioNotificaciones
    {
        public void EnviarEmail(string email, string mensaje) // Metodo encargado de mandarle un mail al cliente
        {
            Console.WriteLine($"[Email] Enviado a {email}: {mensaje}"); // Mensaje de exito del envio del mensaje
        }
    }
}
