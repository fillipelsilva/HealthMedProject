using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.AgendaUseCase
{
    public class ObterAgendaPorMedicoIdUseCase
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public ObterAgendaPorMedicoIdUseCase(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<List<AgendaDTO>?> Execute(Guid medicoId)
        {
            List<Agenda>? lstAgendas = await _agendaRepository.ObterPorMedicoId(medicoId);

            return _mapper.Map<List<AgendaDTO>>(lstAgendas);
        }
    }
}
