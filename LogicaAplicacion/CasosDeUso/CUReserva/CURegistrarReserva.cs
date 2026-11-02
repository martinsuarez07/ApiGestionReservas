using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUReserva
{
    public class CURegistrarReserva : ICURegistrarReserva
    {
        private IRepositorioReserva _repoReserva;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioHorarioDisponible _repoHorario;

        public CURegistrarReserva(
            IRepositorioReserva repoReserva,
            IRepositorioUsuario repoUsuario,
            IRepositorioHorarioDisponible repoHorario)
        {
            _repoReserva = repoReserva;
            _repoUsuario = repoUsuario;
            _repoHorario = repoHorario;
        }

        public void Ejecutar(int usuarioId, int horarioId, DateTime fecha)

        {
            Usuario usuario = _repoUsuario.GetById(usuarioId);

            if (usuario == null)
            {
                throw new ReservaException("El usuario no existe");
            }

            if (!usuario.Activo)
            {
                throw new ReservaException("El usuario no está habilitado");
            }

            HorarioDisponible horario = _repoHorario.GetById(horarioId);


            if (horario == null)
            {
                throw new ReservaException("El horario no existe");
            }

            bool existeReserva = _repoReserva.ExisteReserva(usuarioId, horarioId, fecha);

            if (existeReserva)
            {
                throw new ReservaException(
                    "Ya posee una reserva para este horario"
                );
            }

            int reservasActuales =
                _repoReserva.ContarReservas(
                    horarioId,
                    fecha
                );

            if (reservasActuales >= horario.CupoMaximo)
            {
                throw new ReservaException(
                    "No hay cupos disponibles"
                );
            }

            Reserva reserva = new Reserva
            {
                UsuarioId = usuarioId,
                HorarioDisponibleId = horarioId,
                Fecha = fecha.Date,
                Estado = EstadoReserva.Confirmada
            };

            _repoReserva.Add(reserva);
        }


    }
}
