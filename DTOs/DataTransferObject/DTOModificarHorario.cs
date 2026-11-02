using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOModificarHorario
    {
        public int Id { get; set; }

        public DayOfWeek DiaSemana { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public int CupoMaximo { get; set; }

        public int ServicioId { get; set; }
    }
}
