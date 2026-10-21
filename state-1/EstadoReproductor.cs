using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    public abstract class EstadoReproductor : IEstadoReproductor
    {
        // Referencia al contexto para poder interactuar con él
        protected readonly AudioPlayer Player;
        protected EstadoReproductor(AudioPlayer player) 
        { 
            Player = player; 
        }

        // Obligamos a las clases hijas (estados concretos) a implementar estas acciones
        public abstract void ClickBloqueo();
        public abstract void ClickPlay();
        public abstract void ClickSiguiente(bool dobleClic);
        public abstract void ClickAnterior(bool dobleClic);
    }
}
