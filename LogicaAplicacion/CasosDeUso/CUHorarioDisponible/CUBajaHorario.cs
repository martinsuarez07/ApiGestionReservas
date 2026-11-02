using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUHorarioDisponible
{
    public class CUBajaHorario : ICUBajaHorario
    {
        private  IRepositorioHorarioDisponible _repoHorario;

        public CUBajaHorario(IRepositorioHorarioDisponible repoHorario)
        {
            _repoHorario = repoHorario;
        }

        public void Ejecutar(int id)
        {
            HorarioDisponible horario = _repoHorario.GetById(id);

            if (horario == null)
            {
                throw new NegocioException("El horario no existe");
            }

            if (!horario.Activo)
            {
                throw new NegocioException("El horario ya está inactivo");
            }

            horario.Activo = false;

            _repoHorario.Update(horario);
        }
    }
}