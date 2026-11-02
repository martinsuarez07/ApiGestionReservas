using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.IRepositorio
{
    public interface IRepositorioReserva : IRepositorio<Reserva>
    {
        bool ExisteReserva(int usuarioId,
                           int horarioId,
                           DateTime fecha);

        int ContarReservas(int horarioId,
                           DateTime fecha);

        IEnumerable<Reserva> GetReservasUsuario(int usuarioId);

        IEnumerable<Reserva> GetReservasHorario(int horarioId,
                                                DateTime fecha);

        IEnumerable<Reserva> GetReservasConAsistencia();
    }
}
