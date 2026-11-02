using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoReserva Estado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int HorarioDisponibleId { get; set; }
        public HorarioDisponible HorarioDisponible { get; set; }
    }
}
