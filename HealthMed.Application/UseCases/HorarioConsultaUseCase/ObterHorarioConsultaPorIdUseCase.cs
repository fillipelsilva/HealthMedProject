using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.HorarioConsultaUseCase
{
    public class ObterHorarioConsultaPorIdUseCase
    {
        private readonly IHorarioConsultaRepository _horarioConsultaRepository;
        private readonly IMapper _mapper;

        public ObterHorarioConsultaPorIdUseCase(IHorarioConsultaRepository horarioConsultaRepository, IMapper mapper)
        {
            _horarioConsultaRepository = horarioConsultaRepository;
            _mapper = mapper;
        }

        public async Task<HorarioConsultaDTO?> Execute(Guid id)
        {
            HorarioConsultaDTO? consulta = _mapper.Map<HorarioConsultaDTO>(await _horarioConsultaRepository.ObterPorId(id));

            return consulta;
        }
    }
}
