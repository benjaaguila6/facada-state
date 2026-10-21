using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace state_1
{
    //Contecxto, clase principal
    public class AudioPlayer
    {
        // Estado actual en el que se encuentra el reproductor
        private IEstadoReproductor _estado;

        // Datos internos del reproductor
        private readonly string[] _canciones = { "Canción A", "Canción B", "Canción C" };
        private int _indice = 0;

        public bool Reproduciendo { get; private set; }
        public int Posicion { get; private set; } // segundos

        public string CancionActual => _canciones[_indice];

        public AudioPlayer()
        {
            _estado = new ReadyState(this); // estado inicial
        }

        // Permite cambiar de estado dinámicamente durante la ejecución
        public void ChangeState(IEstadoReproductor nuevoEstado)
        {
            _estado = nuevoEstado;
            Console.WriteLine($"   [transición -> {nuevoEstado.GetType().Name}]");
        }

        // --- DELEGACIÓN DE ACCIONES (El corazón del Patrón State) ---
        // Los botones de la interfaz solo llaman a esto, sin importar el estado actual.
        public void ClickBloqueo() => _estado.ClickBloqueo();
        public void ClickPlay() => _estado.ClickPlay();
        public void ClickSiguiente(bool dobleClic = false) => _estado.ClickSiguiente(dobleClic);
        public void ClickAnterior(bool dobleClic = false) => _estado.ClickAnterior(dobleClic);

        // Operaciones propias del reproductor, que los estados usan cuando corresponde.
        public void IniciarReproduccion()
        {
            Reproduciendo = true;
            Console.WriteLine($"   Reproduciendo '{CancionActual}'");
        }

        public void DetenerReproduccion()
        {
            Reproduciendo = false;
            Console.WriteLine("   Reproducción detenida");
        }

        public void SiguienteCancion()
        {
            _indice = (_indice + 1) % _canciones.Length;
            Posicion = 0;
            Console.WriteLine($"   Canción siguiente: '{CancionActual}'");
        }

        public void AnteriorCancion()
        {
            _indice = (_indice - 1 + _canciones.Length) % _canciones.Length;
            Posicion = 0;
            Console.WriteLine($"   Canción anterior: '{CancionActual}'");
        }

        public void Adelantar(int segundos)
        {
            Posicion += segundos;
            Console.WriteLine($"   Adelantó {segundos}s (posición: {Posicion}s)");
        }

        public void Retroceder(int segundos)
        {
            Posicion = Math.Max(0, Posicion - segundos);
            Console.WriteLine($"   Retrocedió {segundos}s (posición: {Posicion}s)");
        }
    }
}
