using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    // Define el comportamiento cuando la música está sonando activamente.
    public class PlayingState : EstadoReproductor
    {
        public PlayingState(AudioPlayer player) : base(player) { }

        // Si está sonando y bloquean, pasa al estado LockedState
        public override void ClickBloqueo() => Player.ChangeState(new LockedState(Player));

        // Si está sonando y presionan Play, detiene la música y vuelve a ReadyState
        public override void ClickPlay()
        {
            Player.DetenerReproduccion();
            Player.ChangeState(new ReadyState(Player));
        }

        // Doble clic: cambia de canción. Un clic: adelanta 5 segundos.
        public override void ClickSiguiente(bool dobleClic)
        {
            if (dobleClic) Player.SiguienteCancion();
            else Player.Adelantar(5);
        }

        // Doble clic: cambia de canción. Un clic: retrocede 5 segundos.
        public override void ClickAnterior(bool dobleClic)
        {
            if (dobleClic) Player.AnteriorCancion();
            else Player.Retroceder(5);
        }
    }
}
