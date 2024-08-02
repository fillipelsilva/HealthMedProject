using AutoMapper;
using HealthMed.Application.DTOs;
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
        private readonly IMapper _mapper;

        public ObterAgendaDiaPorIdUseCase(IAgendaDiaRepository agendaDiaRepository, IMapper mapper)
        {
            _agendaDiaRepository = agendaDiaRepository;
            _mapper = mapper;
        }

        public async Task<RecuperarAgendaDiaDTO?> Execute(Guid id)
        {
            RecuperarAgendaDiaDTO? agendaDia = _mapper.Map<RecuperarAgendaDiaDTO>(await _agendaDiaRepository.ObterPorIdPeloMedico(id));

            return agendaDia;
        }
    }
}
