using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.MedicoUseCase
{
    public class RemoverMedicoUseCase
    {
        private readonly IMedicoRepository _medicoRepository;

        public RemoverMedicoUseCase(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task Execute(Guid id)
        {
            Medico? medico = await _medicoRepository.ObterPorId(id);

            if (medico == null) throw new ArgumentException("Não há registro com o id informado.");

            await _medicoRepository.Remover(id);
        }
    }
}

