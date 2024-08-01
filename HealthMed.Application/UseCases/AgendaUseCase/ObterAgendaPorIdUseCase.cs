using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.AgendaUseCase
{
    public class ObterAgendaPorIdUseCase
    {
        private readonly IAgendaRepository _agendaRepository;

        public ObterAgendaPorIdUseCase(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<Agenda?> Execute(Guid id)
        {
            Agenda? agenda = await _agendaRepository.ObterPorId(id);

            return agenda;
        }
    }
}
