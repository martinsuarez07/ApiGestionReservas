using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class HorarioDisponible
    {
        public int Id { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CupoMaximo { get; set; }
        public bool Activo { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
