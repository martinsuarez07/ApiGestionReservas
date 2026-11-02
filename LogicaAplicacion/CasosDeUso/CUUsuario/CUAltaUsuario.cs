using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(DTOAltaUsuario dto)
        {
            if (dto == null)
                throw new UsuarioException("Los datos son obligatorios");

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new UsuarioException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new UsuarioException("El email es obligatorio");

            if (_repoUsuario.ExisteEmail(dto.Email))
                throw new UsuarioException("Ya existe un usuario con ese email");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new UsuarioException("La contraseña es obligatoria");

            Usuario usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                PasswordHash = dto.Password, // después lo hasheamos
                Rol = (RolUsuario)dto.Rol,
                Activo = true
            };

            _repoUsuario.Add(usuario);
        }
    }
}
