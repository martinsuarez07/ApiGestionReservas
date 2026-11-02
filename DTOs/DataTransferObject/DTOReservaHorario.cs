using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOReservaHorario
    {
        public int ReservaId { get; set; }
        public string NombreUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
