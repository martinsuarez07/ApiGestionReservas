using DTOs;
using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.IRepositorio;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUListarReservasPorHorario : ICUListarReservasPorHorario
    {
        private IRepositorioReserva _repoReserva;

        public CUListarReservasPorHorario(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public IEnumerable<DTOReservaHorario> Ejecutar(int horarioId, DateTime fecha)
        {
            return _repoReserva.GetReservasHorario(horarioId, fecha)
                .Select(r => new DTOReservaHorario
                {
                    ReservaId = r.Id,
                    NombreUsuario = r.Usuario.Nombre,
                    EmailUsuario = r.Usuario.Email,
                    Fecha = r.Fecha,
                    Estado = r.Estado.ToString()
                });
        }
    }
}