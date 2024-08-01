using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.AgendaDiaUseCase
{
    public class ObterAgendaDiaPorIdUseCase
    {
        private readonly IAgendaDiaRepository _agendaDiaRepository;

        public ObterAgendaDiaPorIdUseCase(IAgendaDiaRepository agendaDiaRepository)
        {
            _agendaDiaRepository = agendaDiaRepository;
        }

        public async Task<AgendaDia?> Execute(Guid id)
        {
            AgendaDia? agendaDia = await _agendaDiaRepository.ObterPorId(id);

            return agendaDia;
        }
    }
}
