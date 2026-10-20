using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    public abstract class EstadoReproductor : IEstadoReproductor
    {
        protected readonly AudioPlayer Player;
        protected EstadoReproductor(AudioPlayer player) { Player = player; }

        public abstract void ClickBloqueo();
        public abstract void ClickPlay();
        public abstract void ClickSiguiente(bool dobleClic);
        public abstract void ClickAnterior(bool dobleClic);
    }
}
