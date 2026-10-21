using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    public class Bloqueada : IEstadoCuenta
    {
        public bool IngresarPassword(Cuenta cuenta, string password)
        {
            Console.WriteLine("   [Bloqueado] La cuenta se encuentra bloqueada. No se puede ingresar.");
            return false;
        }
    }
}
