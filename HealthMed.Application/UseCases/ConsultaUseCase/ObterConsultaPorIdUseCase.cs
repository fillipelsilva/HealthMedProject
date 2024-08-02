using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.ConsultaUseCase
{
    public class ObterConsultaPorIdUseCase
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMapper _mapper;

        public ObterConsultaPorIdUseCase(IConsultaRepository consultaRepository, IMapper mapper)
        {
            _consultaRepository = consultaRepository;
            _mapper = mapper;
        }

        public async Task<ConsultaDTO?> Execute(Guid id)
        {
            ConsultaDTO? consulta = _mapper.Map<ConsultaDTO>(await _consultaRepository.ObterComMedicoEPacientePorId(id));

            return consulta;
        }
    }
}
