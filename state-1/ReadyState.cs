using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    public class ReadyState : EstadoReproductor
    {
        public ReadyState(AudioPlayer player) : base(player) { }

        public override void ClickBloqueo() => Player.ChangeState(new LockedState(Player));

        public override void ClickPlay()
        {
            Player.IniciarReproduccion();
            Player.ChangeState(new PlayingState(Player));
        }

        public override void ClickSiguiente(bool dobleClic) => Player.SiguienteCancion();
        public override void ClickAnterior(bool dobleClic) => Player.AnteriorCancion();
    }
}
