using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.ICUReserva
{
    public interface ICURegistrarReserva
    {
        void Ejecutar(int usuarioId,
                      int horarioId,
                      DateTime fecha);
    }
}
