using DTOs.DataTransferObject;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private ICUListarHorariosPorDia _cuListarHorariosPorDia;
        private ICUListarHorarios _cuListarHorarios;
        private ICUBuscarHorarioPorId _cuBuscarHorarioPorId;
        private ICUModificarHorario _cuModificarHorario;
        private ICUBajaHorario _cuBajaHorario;


        public HorariosController(ICUListarHorariosPorDia cuListarHorariosPorDia, ICUListarHorarios cuListarHorarios, ICUBuscarHorarioPorId cuBuscarHorarioPorId, ICUModificarHorario cuModificarHorario, ICUBajaHorario cuBajaHorario)
        {
            _cuListarHorariosPorDia = cuListarHorariosPorDia;
            _cuListarHorarios = cuListarHorarios;
            _cuBuscarHorarioPorId = cuBuscarHorarioPorId;
            _cuModificarHorario = cuModificarHorario;
            _cuBajaHorario = cuBajaHorario;
        }

        [HttpGet("dia")]
        public IActionResult ListarPorDia([FromQuery] DateTime fecha)
        {
            try
            {
                var horarios = _cuListarHorariosPorDia.Ejecutar(fecha);
                return Ok(horarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var horarios = _cuListarHorarios.Ejecutar();
                return Ok(horarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var horario = _cuBuscarHorarioPorId.Ejecutar(id);
                return Ok(horario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] DTOModificarHorario dto)
        {

            try
            {
                if (id != dto.Id)
                {
                    return BadRequest(
                        "El id de la URL no coincide con el id del horario"
                    );
                }

                _cuModificarHorario.Ejecutar(dto);

                return Ok("Horario modificado correctamente");
            }
            catch (NegocioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al modificar el horario");

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Baja(int id)
        {
            try
            {
                _cuBajaHorario.Ejecutar(id);

                return Ok("Horario dado de baja correctamente");
            }
            catch (NegocioException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    "Ocurrió un error al dar de baja el horario"
                );
            }
        }
    }
}