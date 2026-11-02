using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUListarUsuarios : ICUListarUsuarios
    {
        private IRepositorioUsuario _repoUsuario;

        public CUListarUsuarios(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public IEnumerable<DTOUsuario> Ejecutar()
        {
            IEnumerable<Usuario> usuarios = _repoUsuario.GetAll();

            IEnumerable<DTOUsuario> resultado = usuarios.Select(usuario =>
                new DTOUsuario
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Rol = usuario.Rol,
                    Activo = usuario.Activo
                });

            return resultado;
        }
    }
}
