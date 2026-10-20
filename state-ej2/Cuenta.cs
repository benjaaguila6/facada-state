using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_ej2
{
    public class Cuenta
    {
        private IEstadoCuenta _estado;
        private readonly string _passwordCorrecta;

        public int IntentosFallidos { get; set; }

        public Cuenta(string passwordCorrecta)
        {
            _passwordCorrecta = passwordCorrecta;
            _estado = new Activa(); // estado inicial
        }

        // Setter para recibir un nuevo objeto de estado (transición).
        public void SetState(IEstadoCuenta nuevoEstado)
        {
            _estado = nuevoEstado;
            Console.WriteLine($"   [transición -> {nuevoEstado.GetType().Name}]");
        }

        public bool EsPasswordCorrecta(string password) => password == _passwordCorrecta;

        // El contexto no tiene condicionales: delega en el estado actual.
        public int IngresarPassword(string password)
        {
            return _estado.ControlarEstado(this, password);
        }
    }
}
