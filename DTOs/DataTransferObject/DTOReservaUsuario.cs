using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOReservaUsuario
    {
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Servicio { get; set; }
        public string Estado { get; set; }
    }
}
