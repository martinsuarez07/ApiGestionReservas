using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOHorarioDelDia
    {
        public int HorarioId { get; set; }
        public string Servicio { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int CupoMaximo { get; set; }
        public int CuposOcupados { get; set; }
    }
}
