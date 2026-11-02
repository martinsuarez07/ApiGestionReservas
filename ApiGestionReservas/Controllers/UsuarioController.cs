using DTOs.DataTransferObject;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.Excepciones.LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private  ICUBuscarUsuarioPorId _cuBuscarUsuarioPorId;
        private ICUListarUsuarios _cuListarUsuarios;
        private ICUModificarUsuario _cuModificarUsuario;
        private ICUBajaUsuario _cuBajaUsuario;
        private ICULogin _cuLogin;

        public UsuariosController(ICUBuscarUsuarioPorId cuBuscarUsuarioPorId, ICUListarUsuarios cuListarUsuarios, ICUModificarUsuario cuModificarUsuario, ICUBajaUsuario cuBajaUsuario, ICULogin cuLogin)
        {
            _cuBuscarUsuarioPorId = cuBuscarUsuarioPorId;
            _cuListarUsuarios = cuListarUsuarios;
            _cuModificarUsuario = cuModificarUsuario;
            _cuBajaUsuario = cuBajaUsuario;
            _cuLogin = cuLogin;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                DTOUsuario usuario = _cuBuscarUsuarioPorId.Ejecutar(id);

                return Ok(usuario);
            }
            catch (UsuarioException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al buscar el usuario"
                );
            }
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                IEnumerable<DTOUsuario> usuarios = _cuListarUsuarios.Ejecutar();

                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al listar los usuarios"
                );
            }
        }
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] DTOModificarUsuario dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("El id de la URL no coincide con el del usuario");
                }

                _cuModificarUsuario.Ejecutar(dto);

                return Ok("Usuario modificado correctamente");
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al modificar el usuario"
                );
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Baja(int id)
        {
            try
            {
                _cuBajaUsuario.Ejecutar(id);

                return Ok("Usuario dado de baja correctamente");
            }
            catch (UsuarioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al dar de baja el usuario"
                );
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin dto)
        {
            try
            {
                DTOUsuarioLogueado usuario = _cuLogin.Ejecutar(dto);

                return Ok(usuario);
            }
            catch (UsuarioException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al iniciar sesión"
                );
            }
        }
    }
}
