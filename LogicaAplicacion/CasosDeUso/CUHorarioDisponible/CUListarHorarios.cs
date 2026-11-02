using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUHorarioDisponible
{
    public class CUListarHorarios : ICUListarHorarios
    {
        private IRepositorioHorarioDisponible _repoHorario;

        public CUListarHorarios(
            IRepositorioHorarioDisponible repoHorario)
        {
            _repoHorario = repoHorario;
        }

        public IEnumerable<DTOHorario> Ejecutar()
        {
            return _repoHorario.GetHorarios()
                .Select(h => new DTOHorario
                {
                    Id = h.Id,
                    DiaSemana = h.DiaSemana,
                    HoraInicio = h.HoraInicio,
                    HoraFin = h.HoraFin,
                    CupoMaximo = h.CupoMaximo,
                    Activo = h.Activo,
                    Servicio = h.Servicio.Nombre
                })
                .ToList();
        }
    }
}

