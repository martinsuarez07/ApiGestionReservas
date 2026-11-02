using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using LogicaNegocio.IRepositorio;

public class CUBuscarUsuarioPorId : ICUBuscarUsuarioPorId
{
    private IRepositorioUsuario _repoUsuario;

    public CUBuscarUsuarioPorId(IRepositorioUsuario repoUsuario)
    {
        _repoUsuario = repoUsuario;
    }

    public DTOUsuario Ejecutar(int id)
    {
        Usuario usuario = _repoUsuario.GetById(id);

        if (usuario == null)
        {
            throw new UsuarioException("El usuario no existe");
        }

        DTOUsuario dto = new DTOUsuario
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Rol = usuario.Rol,
            Activo = usuario.Activo
        };

        return dto;
    }
}