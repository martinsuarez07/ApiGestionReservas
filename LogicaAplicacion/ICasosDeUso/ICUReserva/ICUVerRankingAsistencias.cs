using DTOs;
using DTOs.DataTransferObject;

namespace LogicaAplicacion.ICasosDeUso.ICUReserva
{
    public interface ICUVerRankingAsistencias
    {
        IEnumerable<DTORankingAsistencia> Ejecutar();
    }
}