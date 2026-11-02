using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DataTransferObject
{
    public class DTOUsuarioLogueado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public int Rol { get; set; }
    }
}
