using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioReserva
     : Repositorio<Reserva>, IRepositorioReserva
    {
        public RepositorioReserva(ApplicationDbContext context)
            : base(context)
        {
        }

        public bool ExisteReserva(int usuarioId, int horarioId, DateTime fecha)
        {
            return _context.Reservas.Any(r =>
                r.UsuarioId == usuarioId &&
                r.HorarioDisponibleId == horarioId &&
                r.Fecha.Date == fecha.Date &&
                r.Estado == EstadoReserva.Confirmada);
        }

        public int ContarReservas(int horarioId, DateTime fecha)
        {
            return _context.Reservas.Count(r =>
                r.HorarioDisponibleId == horarioId &&
                r.Fecha.Date == fecha.Date &&
                r.Estado == EstadoReserva.Confirmada);
        }

        public IEnumerable<Reserva> GetReservasUsuario(int usuarioId)
        {
            return _context.Reservas
                .Include(r => r.HorarioDisponible)
                .ThenInclude(h => h.Servicio)
                .Where(r => r.UsuarioId == usuarioId)
                .ToList();
        }

        public IEnumerable<Reserva> GetReservasHorario(int horarioId, DateTime fecha)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Where(r =>
                    r.HorarioDisponibleId == horarioId &&
                    r.Fecha.Date == fecha.Date)
                .ToList();
        }
        public IEnumerable<Reserva> GetReservasConAsistencia()
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Where(r => r.Estado == EstadoReserva.Asistio)
                .ToList();
        }
    }
}
