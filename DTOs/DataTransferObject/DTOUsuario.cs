using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;

namespace DTOs.DataTransferObject
{
    public class DTOUsuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public RolUsuario Rol { get; set; }

        public bool Activo { get; set; }
    }
}
