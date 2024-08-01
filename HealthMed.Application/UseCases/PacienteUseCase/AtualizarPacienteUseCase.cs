using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class AtualizarPacienteUseCase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public AtualizarPacienteUseCase(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task Execute(AlterarPacienteDTO pacienteDTO)
        {
            var paciente = await _pacienteRepository.ObterPorId(pacienteDTO.Id);

            paciente.AlterarPaciente(pacienteDTO.Nome, pacienteDTO.CPF);

            await _pacienteRepository.Atualizar(paciente);
        }
    }
}
