using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace state_1
{
    public class LockedState : EstadoReproductor
    {
        public LockedState(AudioPlayer player) : base(player) { }

        public override void ClickBloqueo()
        {
            // Al desbloquear vuelve a PlayingState si estaba reproduciendo, o a ReadyState si no.
            if (Player.Reproduciendo)
                Player.ChangeState(new PlayingState(Player));
            else
                Player.ChangeState(new ReadyState(Player));
        }

        // Mientras está bloqueado, los controles multimedia no hacen nada por seguridad
        public override void ClickPlay() { Console.WriteLine("   (bloqueado) play no hace nada"); }
        public override void ClickSiguiente(bool dobleClic) { Console.WriteLine("   (bloqueado) siguiente no hace nada"); }
        public override void ClickAnterior(bool dobleClic) { Console.WriteLine("   (bloqueado) anterior no hace nada"); }
    }
}
