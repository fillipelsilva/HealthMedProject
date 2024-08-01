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
    public class AdicionarPacienteUseCase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public AdicionarPacienteUseCase(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<bool> Execute(CriarPacienteDTO pacienteDTO)
        {
            Paciente pacienteNovo = new(pacienteDTO.Nome, pacienteDTO.CPF, pacienteDTO.Email, pacienteDTO.Password);

            pacienteNovo.AdicionarEmail(pacienteDTO.Email);
            pacienteNovo.AdicionarPassword(pacienteDTO.Password);

            await _pacienteRepository.Adicionar(pacienteNovo);
            return true;
        }
    }
}
