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
  public class CUModificarHorario : ICUModificarHorario
    {
        private IRepositorioHorarioDisponible _repoHorario;
        private IRepositorioServicio _repoServicio;

        public CUModificarHorario(
            IRepositorioHorarioDisponible repoHorario,
            IRepositorioServicio repoServicio)
        {
            _repoHorario = repoHorario;
            _repoServicio = repoServicio;
        }

        public void Ejecutar(DTOModificarHorario dto)
        {
            if (dto == null)
            {
                throw new NegocioException("Los datos son obligatorios");
            }

            HorarioDisponible horario = _repoHorario.GetById(dto.Id);


            if (horario == null)
            {
                throw new NegocioException("El horario no existe");
            }

            if (dto.HoraInicio >= dto.HoraFin)
            {
                throw new NegocioException(
                    "La hora de inicio debe ser menor a la hora de fin"
                );
            }

            if (dto.CupoMaximo <= 0)
            {
                throw new NegocioException(
                    "El cupo máximo debe ser mayor a cero"
                );
            }

            Servicio servicio = _repoServicio.GetById(dto.ServicioId);


            if (servicio == null)
            {
                throw new NegocioException("El servicio no existe");
            }

            horario.DiaSemana = dto.DiaSemana;
            horario.HoraInicio = dto.HoraInicio;
            horario.HoraFin = dto.HoraFin;
            horario.CupoMaximo = dto.CupoMaximo;
            horario.ServicioId = dto.ServicioId;

            _repoHorario.Update(horario);
        }
    }
}
