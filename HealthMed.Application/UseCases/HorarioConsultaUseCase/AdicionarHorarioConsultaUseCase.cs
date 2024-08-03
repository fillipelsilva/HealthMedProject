using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.HorarioConsultaUseCase
{
    public class AdicionarHorarioConsultaUseCase
    {
        private readonly IHorarioConsultaRepository _horarioConsultaRepository;
        private readonly IAgendaDiaRepository _agendaDiaRepository;

        public AdicionarHorarioConsultaUseCase(IHorarioConsultaRepository horarioConsultaRepository, IAgendaDiaRepository agendaDiaRepository)
        {
            _horarioConsultaRepository = horarioConsultaRepository;
            _agendaDiaRepository = agendaDiaRepository;
        }

        public async Task<bool> Execute(CriacaoHorarioConsultaDTO horarioConsultaDTO)
        {
            var diaConsulta = await _agendaDiaRepository.ObterPorId(horarioConsultaDTO.AgendaDiaId);
            HorarioConsulta? horarioConsulta = new(horarioConsultaDTO.Horario, true);
            horarioConsulta.DefinirDia(diaConsulta);
            await _horarioConsultaRepository.Adicionar(horarioConsulta);
            return true;
        }
    }
}
