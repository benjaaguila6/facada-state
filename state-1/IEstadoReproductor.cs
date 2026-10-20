using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    public interface IEstadoReproductor
    {
        void ClickBloqueo();
        void ClickPlay();
        void ClickSiguiente(bool dobleClic);
        void ClickAnterior(bool dobleClic);
    }
}
