using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTORankingAsistencia
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public int CantidadAsistencias { get; set; }
    }
}
