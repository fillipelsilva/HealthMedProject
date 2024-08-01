using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {

        [HttpGet("ObterPacientePorId")]
        public async Task<IActionResult> ObterPacientePorId(Guid id, [FromServices] ObterPacientePorIdUseCase obterPacientePorIdUseCase)
        {
            try
            {
                var paciente = await obterPacientePorIdUseCase.Execute(id);
                if (paciente is null) return NotFound();

                return Ok(new { paciente });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPost("AdicionarPaciente")]
        public async Task<IActionResult> AdicionarPaciente([FromBody] CriarPacienteDTO paciente, [FromServices] AdicionarPacienteUseCase adicionarPacienteUseCase)
        {
            try
            {
                await adicionarPacienteUseCase.Execute(paciente);
                return Ok("Paciente adicionado com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPut("AtualizarPaciente")]
        public async Task<IActionResult> AtualizarPaciente([FromBody] AlterarPacienteDTO paciente, [FromServices] AtualizarPacienteUseCase atualizarPacienteUseCase)
        {
            try
            {
                await atualizarPacienteUseCase.Execute(paciente);
                return Ok("Paciente atualizado com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("RemoverPaciente/{id}")]
        public async Task<IActionResult> RemoverPaciente(Guid id, [FromServices] RemoverPacienteUseCase removerPacienteUseCase)
        {
            try
            {
                await removerPacienteUseCase.Execute(id);
                return Ok("Paciente removido com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
    }
}
