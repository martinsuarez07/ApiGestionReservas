using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUBajaUsuario : ICUBajaUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUBajaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(int id)
        {
            Usuario usuario = _repoUsuario.GetById(id);

            if (usuario == null)
                throw new UsuarioException("El usuario no existe");

            if (!usuario.Activo)
                throw new UsuarioException("El usuario ya está inactivo");

            usuario.Activo = false;

            _repoUsuario.Update(usuario);
        }
    }
}
