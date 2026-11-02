using System;
using System.Collections.Generic;
using System.Text;
using DTOs.DataTransferObject;


    namespace LogicaAplicacion.ICasosDeUso.HorarioDisponible
    {
        public interface ICUBuscarHorarioPorId
        {
            DTOHorario Ejecutar(int id);
        }
    }

