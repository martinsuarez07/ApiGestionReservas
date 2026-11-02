using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaAplicacion.ICasosDeUso.ICUReserva.LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUConfirmarAsistencia : ICUConfirmarAsistencia
    {
        private IRepositorioReserva _repoReserva;

        public CUConfirmarAsistencia(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public void Ejecutar(int reservaId)
        {
            Reserva reserva = _repoReserva.GetById(reservaId);

            if (reserva == null)
            {
                throw new ReservaException("La reserva no existe");
            }

            if (reserva.Estado != EstadoReserva.Confirmada)
            {
                throw new ReservaException("Solo se puede confirmar asistencia de reservas confirmadas");
            }

            reserva.Estado = EstadoReserva.Asistio;

            _repoReserva.Update(reserva);
        }
    }
}