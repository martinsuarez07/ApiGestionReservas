using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTORegistrarReserva
    {
        public int UsuarioId { get; set; }

        public int HorarioId { get; set; }

        public DateTime Fecha { get; set; }
    }
}
