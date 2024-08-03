using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class ObterPacientePorIdUseCase
    {

        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public ObterPacientePorIdUseCase(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<PacienteDTO?> Execute(Guid id)
        {
            PacienteDTO? paciente = _mapper.Map<PacienteDTO>(await _pacienteRepository.ObterComConsultaPorId(id));

            return paciente;
        }
    }
}
