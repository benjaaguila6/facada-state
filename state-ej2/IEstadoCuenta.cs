using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    public interface IEstadoCuenta
    {
        int ControlarEstado(Cuenta cuenta, string password);
    }
}
