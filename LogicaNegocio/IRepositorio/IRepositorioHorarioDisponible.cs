using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.IRepositorio
{
    public interface IRepositorioHorarioDisponible
     : IRepositorio<HorarioDisponible>
    {
        IEnumerable<HorarioDisponible> GetHorariosActivos();

        IEnumerable<HorarioDisponible> GetHorariosPorDia(DayOfWeek dia);
        HorarioDisponible GetById(int id);

        IEnumerable<HorarioDisponible> GetAll();

        IEnumerable<HorarioDisponible> GetHorarios();
        HorarioDisponible GetHorarioPorId(int id);
    }
}
