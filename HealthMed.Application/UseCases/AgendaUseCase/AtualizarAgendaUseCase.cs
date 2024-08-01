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
    public class AtualizarAgendaUseCase
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AtualizarAgendaUseCase(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task Execute(AlterarAgendaDTO agendaDTO)
        {
            var agenda = await _agendaRepository.ObterPorId(agendaDTO.Id);

            agenda.AlterarAgenda(_mapper.Map<List<AgendaDia>>(agendaDTO.Dias));

            await _agendaRepository.Atualizar(agenda);
        }
    }
}

