using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.ICUReserva
{
    public interface ICUCancelarReserva
    {
        void Ejecutar(int reservaId, int usuarioId);
    }
}
