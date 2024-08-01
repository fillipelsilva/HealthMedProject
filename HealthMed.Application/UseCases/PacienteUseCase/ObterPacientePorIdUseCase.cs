using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class ObterPacientePorIdUseCase
    {

        private readonly IPacienteRepository _pacienteRepository;

        public ObterPacientePorIdUseCase(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Paciente?> Execute(Guid id)
        {
            Paciente? paciente = await _pacienteRepository.ObterPorId(id);

            return paciente;
        }
    }
}
