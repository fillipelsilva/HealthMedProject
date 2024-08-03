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
    public class ObterAgendaPorIdUseCase
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public ObterAgendaPorIdUseCase(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<AgendaDTO?> Execute(Guid id)
        {
            AgendaDTO? agenda = _mapper.Map<AgendaDTO>(await _agendaRepository.ObterComDiasPorId(id));

            return agenda;
        }
    }
}
