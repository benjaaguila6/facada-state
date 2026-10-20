using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    public class Bloqueada : IEstadoCuenta
    {
        public int ControlarEstado(Cuenta cuenta, string password)
        {
            return Resultado.Bloqueada;
        }
    }
}
