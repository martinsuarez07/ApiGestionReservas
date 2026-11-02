using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioHorarioDisponible
    : Repositorio<HorarioDisponible>, IRepositorioHorarioDisponible
    {
        public RepositorioHorarioDisponible(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<HorarioDisponible> GetHorariosActivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HorarioDisponible> GetHorariosPorDia(DayOfWeek dia)
        {
            return _context.HorariosDisponibles
                .Include(h => h.Servicio)
                .Where(h => h.DiaSemana == dia && h.Activo)
                .ToList();
        }
        public IEnumerable<HorarioDisponible> GetHorarios()
        {
            return _context.HorariosDisponibles
                .Include(h => h.Servicio)
                .OrderBy(h => h.DiaSemana)
                .ThenBy(h => h.HoraInicio)
                .ToList();
        }
        public HorarioDisponible GetHorarioPorId(int id)
        {
            return _context.HorariosDisponibles
                .Include(h => h.Servicio)
                .FirstOrDefault(h => h.Id == id);
        }
    }
}
