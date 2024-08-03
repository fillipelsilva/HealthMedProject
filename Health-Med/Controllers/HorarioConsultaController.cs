using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.AgendaUseCase;
using HealthMed.Application.UseCases.ConsultaUseCase;
using HealthMed.Application.UseCases.HorarioConsultaUseCase;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioConsultaController : ControllerBase
    {

        [HttpGet("ObterHorarioConsultaPorId")]
        public async Task<IActionResult> ObterHorarioConsultaPorId(Guid id, [FromServices] ObterHorarioConsultaPorIdUseCase obterHorarioConsultaPorIdUseCase)
        {
            try
            {
                var consulta = await obterHorarioConsultaPorIdUseCase.Execute(id);
                if (consulta is null) return NotFound();

                return Ok(new { consulta });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPost("CadastrarHorarioConsulta")]
        public async Task<IActionResult> CadastrarHorarioConsulta([FromBody] CriacaoHorarioConsultaDTO horarioConsulta, [FromServices] AdicionarHorarioConsultaUseCase adicionarHorarioConsultaUseCase)
        {
            try
            {
                await adicionarHorarioConsultaUseCase.Execute(horarioConsulta);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("RemoverHorarioConsulta/{id}")]
        public async Task<IActionResult> RemoverHorarioConsulta(Guid id, [FromServices] RemoverHorarioConsultaUseCase removerConsultaUseCase)
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
