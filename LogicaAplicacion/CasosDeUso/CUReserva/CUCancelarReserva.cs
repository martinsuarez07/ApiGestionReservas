using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUCancelarReserva : ICUCancelarReserva
    {
        private IRepositorioReserva _repoReserva;

        public CUCancelarReserva(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public void Ejecutar(int reservaId, int usuarioId)
        {
            Reserva reserva = _repoReserva.GetById(reservaId);

            if (reserva == null)
            {
                throw new ReservaException("La reserva no existe");
            }

            if (reserva.UsuarioId != usuarioId)
            {
                throw new ReservaException("No puede cancelar una reserva de otro usuario");
            }

            if (reserva.Estado != EstadoReserva.Confirmada)
            {
                throw new ReservaException("Solo se pueden cancelar reservas confirmadas");
            }

            reserva.Estado = EstadoReserva.Cancelada;

            _repoReserva.Update(reserva);
        }
    }
}

