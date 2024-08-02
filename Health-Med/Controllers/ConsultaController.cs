using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.AgendaUseCase;
using HealthMed.Application.UseCases.ConsultaUseCase;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {

        [HttpGet("ObterConsultaPorId")]
        public async Task<IActionResult> ObterConsultaPorId(Guid id, [FromServices] ObterConsultaPorIdUseCase obterConsultaPorIdUseCase)
        {
            try
            {
                var consulta = await obterConsultaPorIdUseCase.Execute(id);
                if (consulta is null) return NotFound();

                return Ok(new { consulta });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPost("MarcarConsulta")]
        public async Task<IActionResult> MarcarConsulta([FromBody] CriacaoConsultaDTO consulta, [FromServices] MarcarConsultaUseCase marcarConsultaUseCase)
        {
            try
            {
                await marcarConsultaUseCase.Execute(consulta);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("RemoverConsulta/{id}")]
        public async Task<IActionResult> RemoverAgenda(Guid id, [FromServices] RemoverConsultaUseCase removerConsultaUseCase)
        {
            try
            {
                await removerConsultaUseCase.Execute(id);
                return Ok("Consulta removida com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
    }
}
