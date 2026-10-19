using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    public class ServicioEnvio
    {
        public void ProgramarEnvio(string direccion) // Metodo que simula la programacion del envio
        {
            Console.WriteLine($"[Envío] Envío programado a: {direccion}."); // Mensaje de exito de la programacion
        }

    }
}
