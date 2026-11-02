using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CULogin
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;

        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public DTOUsuarioLogueado Ejecutar(DTOLogin dto)
        {
            if (dto == null)
                throw new UsuarioException("Los datos son obligatorios");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new UsuarioException("El email es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new UsuarioException("La contraseña es obligatoria");

            Usuario usuario = _repoUsuario.GetByEmail(dto.Email);

            if (usuario == null)
                throw new UsuarioException("Email o contraseña incorrectos");

            if (!usuario.Activo)
                throw new UsuarioException("El usuario está inactivo");

            if (usuario.PasswordHash != dto.Password)
                throw new UsuarioException("Email o contraseña incorrectos");

            DTOUsuarioLogueado respuesta = new DTOUsuarioLogueado
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = (int)usuario.Rol
            };

            return respuesta;
        }
    }
}
