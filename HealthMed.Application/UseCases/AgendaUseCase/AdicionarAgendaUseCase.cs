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

        public AdicionarAgendaUseCase(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<bool> Execute(CriarAgendaDTO agendaDTO)
        {
            Agenda? agenda = new(agendaDTO.MedicoId, agendaDTO.Nome);
            await _agendaRepository.Adicionar(agenda);
            return true;
        }
    }
}

