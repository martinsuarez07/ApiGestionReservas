using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
