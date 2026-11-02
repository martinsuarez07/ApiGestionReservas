using DTOs;
using DTOs.DataTransferObject;

namespace LogicaAplicacion.ICasosDeUso.ICUReserva
{
    public interface ICUListarReservasUsuario
    {
        IEnumerable<DTOReservaUsuario> Ejecutar(int usuarioId);
    }
}