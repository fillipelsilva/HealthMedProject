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
    public class AdicionarAgendaUseCase
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AdicionarAgendaUseCase(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<bool> Execute(CriarAgendaDTO agendaDTO)
        {
            Agenda? agenda = new(_mapper.Map<List<AgendaDia>>(agendaDTO.Dias), agendaDTO.MedicoId);
            await _agendaRepository.Adicionar(agenda);
            return true;
        }
    }
}

