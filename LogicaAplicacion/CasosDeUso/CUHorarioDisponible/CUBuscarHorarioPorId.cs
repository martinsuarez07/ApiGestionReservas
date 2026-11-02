using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUHorarioDisponible
{
    public class CUBuscarHorarioPorId : ICUBuscarHorarioPorId
    {
        private  IRepositorioHorarioDisponible _repoHorario;

        public CUBuscarHorarioPorId(
            IRepositorioHorarioDisponible repoHorario)
        {
            _repoHorario = repoHorario;
        }

        public DTOHorario Ejecutar(int id)
        {
            HorarioDisponible horario = _repoHorario.GetHorarioPorId(id);

            if (horario == null)
            {
                throw new NegocioException("El horario no existe");
            }

            return new DTOHorario
            {
                Id = horario.Id,
                DiaSemana = horario.DiaSemana,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin,
                CupoMaximo = horario.CupoMaximo,
                Activo = horario.Activo,
                Servicio = horario.Servicio?.Nombre
            };
        }
    }
}