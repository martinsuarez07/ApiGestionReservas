using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DuracionMinutos { get; set; }
        public int CupoMaximo { get; set; }
        public bool Activo { get; set; }

        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
    }
}
