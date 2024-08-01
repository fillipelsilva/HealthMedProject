using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class RemoverPacienteUseCase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public RemoverPacienteUseCase(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task Execute(Guid id)
        {
            Paciente? paciente = await _pacienteRepository.ObterPorId(id);

            if (paciente == null) throw new ArgumentException("Não há registro com o id informado.");

            await _pacienteRepository.Remover(id);

        }
    }
}
