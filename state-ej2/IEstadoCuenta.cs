using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    //Contrato
    // Define el método estándar que todos los estados de la cuenta deben cumplir.
    // Recibe la cuenta y la contraseña ingresada para evaluar el comportamiento.
    public interface IEstadoCuenta
    {
        bool IngresarPassword(Cuenta cuenta, string password);
    }
}
