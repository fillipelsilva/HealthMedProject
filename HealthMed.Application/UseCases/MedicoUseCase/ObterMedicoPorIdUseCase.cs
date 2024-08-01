using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.MedicoUseCase
{
    public class ObterMedicoPorIdUseCase
    {
        private readonly IMedicoRepository _medicoRepository;

        public ObterMedicoPorIdUseCase(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Medico?> Execute(Guid id)
        {
            Medico? medico = await _medicoRepository.ObterPorId(id);
            return medico;
        }
    }
}

