using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUHorarioDisponible
{
    public class CUAltaHorarioDisponible : ICUAltaHorarioDisponible
    {
        private IRepositorioHorarioDisponible _repoHorario;
        private IRepositorioServicio _repoServicio;

        public CUAltaHorarioDisponible(
            IRepositorioHorarioDisponible repoHorario,
            IRepositorioServicio repoServicio)
        {
            _repoHorario = repoHorario;
            _repoServicio = repoServicio;
        }

        public void Ejecutar(DTOAltaHorarioDisponible dto)
        {
            if (dto == null)
                throw new NegocioException("Los datos son obligatorios");

            if (dto.HoraInicio >= dto.HoraFin)
                throw new NegocioException("La hora de inicio debe ser menor a la hora de fin");

            if (dto.CupoMaximo <= 0)
                throw new NegocioException("El cupo máximo debe ser mayor a cero");

            Servicio servicio = _repoServicio.GetById(dto.ServicioId);

            if (servicio == null)
                throw new NegocioException("El servicio no existe");

            HorarioDisponible horario = new HorarioDisponible
            {
                DiaSemana = dto.DiaSemana,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                CupoMaximo = dto.CupoMaximo,
                ServicioId = dto.ServicioId,
                Activo = true
            };

            _repoHorario.Add(horario);
        }
    }
}
