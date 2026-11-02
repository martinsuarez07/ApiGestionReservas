using DTOs;
using DTOs.DataTransferObject;

namespace LogicaAplicacion.ICasosDeUso.ICUReserva
{
    public interface ICUListarReservasPorHorario
    {
        IEnumerable<DTOReservaHorario> Ejecutar(int horarioId, DateTime fecha);
    }
}