using DTOs;
using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUListarReservasUsuario : ICUListarReservasUsuario
    {
        private IRepositorioReserva _repoReserva;

        public CUListarReservasUsuario(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public IEnumerable<DTOReservaUsuario> Ejecutar(int usuarioId)
        {
            return _repoReserva.GetReservasUsuario(usuarioId)
                .Select(r => new DTOReservaUsuario
                {
                    ReservaId = r.Id,
                    Fecha = r.Fecha,
                    HoraInicio = r.HorarioDisponible.HoraInicio.ToString(@"hh\:mm"),
                    HoraFin = r.HorarioDisponible.HoraFin.ToString(@"hh\:mm"),
                    Servicio = r.HorarioDisponible.Servicio.Nombre,
                    Estado = r.Estado.ToString()
                });
        }
    }
}