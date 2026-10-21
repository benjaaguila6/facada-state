using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace state_1
{
    // Define qué pasa cuando el reproductor está encendido pero detenido.
    public class ReadyState : EstadoReproductor
    {
        public ReadyState(AudioPlayer player) : base(player) { }

        // Si está en Ready y bloquean, pasa al estado Bloqueado
        public override void ClickBloqueo() => Player.ChangeState(new LockedState(Player));

        // Si está en Ready y dan Play, inicia la música y cambia a PlayingState
        public override void ClickPlay()
        {
            Player.IniciarReproduccion();
            Player.ChangeState(new PlayingState(Player));
        }

        // En estado Ready, pasar de canción simplemente cambia la pista
        public override void ClickSiguiente(bool dobleClic) => Player.SiguienteCancion();
        public override void ClickAnterior(bool dobleClic) => Player.AnteriorCancion();
    }
}
