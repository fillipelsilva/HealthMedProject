using HealthMed.Application.DTOs;
using HealthMed.Application.UseCases.MedicoUseCase;
using HealthMed.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Health.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        [HttpGet("ObterMedicoPorId/{id}")]
        public async Task<IActionResult> ObterMedicoPorId(Guid id, [FromServices] ObterMedicoPorIdUseCase obterMedicoPorIdUseCase)
        {
            try
            {
                var medico = await obterMedicoPorIdUseCase.Execute(id);
                if (medico is null) return NotFound();

                return Ok(new { medico });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPost("AdicionarMedico")]
        public async Task<IActionResult> AdicionarMedico([FromBody] CriarMedicoDTO medico, [FromServices] AdicionarMedicoUseCase adicionarMedicoUseCase)
        {
            try
            {
                await adicionarMedicoUseCase.Execute(medico);
                return Ok("Médico adicionado com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpPut("AtualizarMedico")]
        public async Task<IActionResult> AtualizarMedico([FromBody] AlterarMedicoDTO medico, [FromServices] AtualizarMedicoUseCase atualizarMedicoUseCase)
        {
            try
            {
                await atualizarMedicoUseCase.Execute(medico);
                return Ok("Médico atualizado com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("RemoverMedico/{id}")]
        public async Task<IActionResult> RemoverMedico(Guid id, [FromServices] RemoverMedicoUseCase removerMedicoUseCase)
        {
            try
            {
                await removerMedicoUseCase.Execute(id);
                return Ok("Médico removido com sucesso!");
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
    }
}
