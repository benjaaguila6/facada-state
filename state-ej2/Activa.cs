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

        public int ControlarEstado(Cuenta cuenta, string password)
        {
            if (cuenta.EsPasswordCorrecta(password))
            {
                cuenta.IntentosFallidos = 0;
                return Resultado.Ok;
            }

            cuenta.IntentosFallidos++;

            if (cuenta.IntentosFallidos >= MaxIntentos)
            {
                cuenta.SetState(new Bloqueada());
                return Resultado.Bloqueada;
            }

            return Resultado.Incorrecta;
        }
    }
}
