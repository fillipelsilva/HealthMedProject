using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class RemoverAgendaUseCase
    {
        private readonly IAgendaRepository _agendaRepository;

        public RemoverAgendaUseCase(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task Execute(Guid id)
        {
            Agenda? agenda = await _agendaRepository.ObterPorId(id);

            if (agenda == null) throw new ArgumentException("Não há registro com o id informado.");

            await _agendaRepository.Remover(id);

        }
    }
}
