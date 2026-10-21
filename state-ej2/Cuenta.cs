using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    //Contexto
    public class Cuenta
    {
        private IEstadoCuenta _estado;
        private readonly string _passwordCorrecta;

        public int IntentosFallidos { get; set; }

        public Cuenta(string passwordCorrecta)
        {
            _passwordCorrecta = passwordCorrecta;
            _estado = new Activa(); // Estado inicial
        }

        public void SetState(IEstadoCuenta nuevoEstado)
        {
            _estado = nuevoEstado;
            Console.WriteLine($"   [transición -> {nuevoEstado.GetType().Name}]");
        }

        public bool EsPasswordCorrecta(string password) => password == _passwordCorrecta;

        // Delega la validación directamente al estado actual
        public bool IngresarPassword(string password)
        {
            return _estado.IngresarPassword(this, password);
        }
    }
}
