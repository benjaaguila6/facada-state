using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade_ej2
{
    public class CheckoutFacade // Fachada que puede ser utilizado por un boton "Comprar"
    {
        // Subclases del sistema de gestion.
        private readonly ServicioStock _stock = new ServicioStock();
        private readonly ServicioPago _pago = new ServicioPago();
        private readonly ServicioEnvio _envio = new ServicioEnvio();
        private readonly ServicioNotificaciones _notificaciones = new ServicioNotificaciones();

        public bool ConfirmarCompra(string producto, int cantidad, decimal monto, string direccion, string email) // Metodo que organiza el orden y delega las responsabilidades a las subclases
        {
            if (!_stock.HayStock(producto, cantidad)) // Validamos si no hay stock (Simulamos 10 permitidos)
            {
                Console.WriteLine("Compra cancelada: sin stock.");
                return false;
            }

            if (!_pago.Cobrar(monto)) // Validamos si el cobro es valido
            {
                Console.WriteLine("  Compra cancelada: el pago fue rechazado.");
                return false;
            }

            _stock.Descontar(producto, cantidad); // En caso de que el pago sea exitoso, recien ahi descontamos
            _envio.ProgramarEnvio(direccion); // Luego, programamos el envio
            _notificaciones.EnviarEmail(email, "¡Tu compra fue confirmada!"); //Finalmente, enviamos la notificacion de la compra exitosa.

            return true;
        }
    }
}

