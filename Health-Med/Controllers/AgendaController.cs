using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.AgendaUseCase;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {

        [HttpGet("ObterAgendaPorId")]
        public async Task<IActionResult> ObterAgendaPorId(Guid id, [FromServices] ObterAgendaPorIdUseCase obterAgendaPorIdUseCase)
        {
            try
            {
                var agenda = await obterAgendaPorIdUseCase.Execute(id);
                if (agenda is null) return NotFound();

                return Ok(new { agenda });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPost("AdicionarAgenda")]
        public async Task<IActionResult> AdicionarAgenda([FromBody] CriarAgendaDTO agenda, [FromServices] AdicionarAgendaUseCase adicionarAgendaUseCase)
        {
            try
            {
                await adicionarAgendaUseCase.Execute(agenda);
                return Ok("Agenda adicionada com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("RemoverAgenda/{id}")]
        public async Task<IActionResult> RemoverAgenda(Guid id, [FromServices] RemoverAgendaUseCase removerAgendaUseCase)
        {
            try
            {
                await removerAgendaUseCase.Execute(id);
                return Ok("Agenda removida com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpGet("ObterAgendasPorMedicoId")]
        public async Task<IActionResult> ObterAgendasPorMedicoId(Guid id, [FromServices] ObterAgendaPorMedicoIdUseCase obterAgendaPorIdUseCase)
        {
            try
            {
                var agenda = await obterAgendaPorIdUseCase.Execute(id);
                if (agenda is null) return NotFound();

                return Ok(new { agenda });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
    }
}
