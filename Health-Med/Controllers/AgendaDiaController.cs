using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.AgendaDiaUseCase;
using HealthMed.Application.UseCases.AgendaUseCase;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaDiaController : ControllerBase
    {

        [HttpGet("ObterAgendaDiaPorId")]
        public async Task<IActionResult> ObterAgendaPorId(Guid id, [FromServices] ObterAgendaDiaPorIdUseCase obterAgendaDiaPorIdUseCase)
        {
            try
            {
                var agendaDia = await obterAgendaDiaPorIdUseCase.Execute(id);
                if (agendaDia is null) return NotFound();

                return Ok(new { agendaDia });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }        
    }
}
