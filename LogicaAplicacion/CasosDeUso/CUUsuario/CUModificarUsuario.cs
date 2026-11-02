using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUModificarUsuario : ICUModificarUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUModificarUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(DTOModificarUsuario dto)
        {
            if (dto == null)
                throw new UsuarioException("Los datos son obligatorios");

            Usuario usuario = _repoUsuario.GetById(dto.Id);

            if (usuario == null)
                throw new UsuarioException("El usuario no existe");

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new UsuarioException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new UsuarioException("El email es obligatorio");

            bool cambioEmail =
                !usuario.Email.Equals(
                    dto.Email,
                    StringComparison.OrdinalIgnoreCase
                );

            if (cambioEmail && _repoUsuario.ExisteEmail(dto.Email))
                throw new UsuarioException(
                    "Ya existe otro usuario con ese email"
                );

            usuario.Nombre = dto.Nombre;
            usuario.Email = dto.Email;
            usuario.Rol = (RolUsuario)dto.Rol;
            usuario.Activo = dto.Activo;

            _repoUsuario.Update(usuario);
        }
    }
}
