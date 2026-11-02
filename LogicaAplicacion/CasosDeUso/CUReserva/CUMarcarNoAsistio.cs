using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUMarcarNoAsistio : ICUMarcarNoAsistio
    {
        private IRepositorioReserva _repoReserva;

        public CUMarcarNoAsistio(IRepositorioReserva repoReserva)
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
                throw new ReservaException("Solo se puede marcar falta en reservas confirmadas");
            }

            reserva.Estado = EstadoReserva.NoAsistio;

            _repoReserva.Update(reserva);
        }
    }
}