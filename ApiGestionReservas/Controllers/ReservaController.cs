using DTOs.DataTransferObject;
using LogicaAplicacion.CasosDeUso.CUReserva;
using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaAplicacion.ICasosDeUso.ICUReserva.LogicaAplicacion.ICasosDeUso.ICUReserva;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private ICURegistrarReserva _cuRegistrarReserva;
        private ICUListarReservasUsuario _cuListarReservasUsuario;
        private ICUCancelarReserva _cuCancelarReserva;
        private ICUConfirmarAsistencia _cuConfirmarAsistencia;
        private ICUVerRankingAsistencias _cuVerRankingAsistencias;
        public ReservasController(ICURegistrarReserva cuRegistrarReserva, ICUListarReservasUsuario cuListarReservasUsuario, ICUCancelarReserva cuCancelarReserva, ICUConfirmarAsistencia cuConfirmarAsistencia, ICUVerRankingAsistencias cuVerRankingAsistencias)
        {
            _cuRegistrarReserva = cuRegistrarReserva;
            _cuListarReservasUsuario = cuListarReservasUsuario;
            _cuCancelarReserva = cuCancelarReserva;
            _cuConfirmarAsistencia = cuConfirmarAsistencia;
            _cuVerRankingAsistencias = cuVerRankingAsistencias;
        }

        [HttpPost]
        public IActionResult RegistrarReserva([FromBody] DTORegistrarReserva dto)
        {
            try
            {
                _cuRegistrarReserva.Ejecutar(
                    dto.UsuarioId,
                    dto.HorarioId,
                    dto.Fecha
                );

                return Ok("Reserva registrada correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ListarReservasUsuario(int usuarioId)
        {
            try
            {
                var reservas = _cuListarReservasUsuario.Ejecutar(usuarioId);
                return Ok(reservas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{reservaId}/cancelar/{usuarioId}")]
        public IActionResult CancelarReserva(int reservaId, int usuarioId)
        {
            try
            {
                _cuCancelarReserva.Ejecutar(reservaId, usuarioId);
                return Ok("Reserva cancelada correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{reservaId}/asistio")]
        public IActionResult ConfirmarAsistencia(int reservaId)
        {
            try
            {
                _cuConfirmarAsistencia.Ejecutar(reservaId);
                return Ok("Asistencia confirmada correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ranking")]
        public IActionResult Ranking()
        {
            try
            {
                var ranking = _cuVerRankingAsistencias.Ejecutar();
                return Ok(ranking);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
