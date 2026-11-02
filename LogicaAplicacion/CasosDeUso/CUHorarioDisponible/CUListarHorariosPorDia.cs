using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUHorarioDisponible
{
    public class CUListarHorariosPorDia : ICUListarHorariosPorDia
    {
        private IRepositorioHorarioDisponible _repoHorario;
        private IRepositorioReserva _repoReserva;

        public CUListarHorariosPorDia(
            IRepositorioHorarioDisponible repoHorario,
            IRepositorioReserva repoReserva)
        {
            _repoHorario = repoHorario;
            _repoReserva = repoReserva;
        }

        public IEnumerable<DTOHorarioDelDia> Ejecutar(DateTime fecha)
        {
            DayOfWeek dia = fecha.DayOfWeek;

            var horarios = _repoHorario.GetHorariosPorDia(dia);

            return horarios.Select(h => new DTOHorarioDelDia
            {
                HorarioId = h.Id,
                Servicio = h.Servicio.Nombre,
                HoraInicio = h.HoraInicio.ToString(@"hh\:mm"),
                HoraFin = h.HoraFin.ToString(@"hh\:mm"),
                CupoMaximo = h.CupoMaximo,
                CuposOcupados = _repoReserva.ContarReservas(h.Id, fecha)
            });
        }
    }
}
