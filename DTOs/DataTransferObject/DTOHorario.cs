using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOHorario
    {
        public int Id { get; set; }

        public DayOfWeek DiaSemana { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public int CupoMaximo { get; set; }

        public bool Activo { get; set; }

        public string Servicio { get; set; }
    }
}
