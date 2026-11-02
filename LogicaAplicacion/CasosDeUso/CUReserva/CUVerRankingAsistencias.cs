using DTOs;
using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.IRepositorio;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CUVerRankingAsistencias : ICUVerRankingAsistencias
    {
        private IRepositorioReserva _repoReserva;

        public CUVerRankingAsistencias(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public IEnumerable<DTORankingAsistencia> Ejecutar()
        {
            return _repoReserva.GetReservasConAsistencia()
                .GroupBy(r => r.UsuarioId)
                .Select(g => new DTORankingAsistencia
                {
                    UsuarioId = g.Key,
                    NombreUsuario = g.First().Usuario.Nombre,
                    CantidadAsistencias = g.Count()
                })
                .OrderByDescending(r => r.CantidadAsistencias)
                .ToList();
        }
    }
}