using DTOs.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.HorarioDisponible
{
    public interface ICUListarHorariosPorDia
    {
        IEnumerable<DTOHorarioDelDia> Ejecutar(DateTime fecha);
    }
}
