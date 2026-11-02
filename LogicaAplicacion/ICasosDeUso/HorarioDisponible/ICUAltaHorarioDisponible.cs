using DTOs.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.HorarioDisponible
{
    public interface ICUAltaHorarioDisponible
    {
        void Ejecutar(DTOAltaHorarioDisponible dto);
    }
}
