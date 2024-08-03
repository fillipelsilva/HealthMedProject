using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.MedicoUseCase
{
    public class ObterMedicoPorIdUseCase
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public ObterMedicoPorIdUseCase(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<MedicoDTO?> Execute(Guid id)
        {
            MedicoDTO? medico = _mapper.Map<MedicoDTO>(await _medicoRepository.ObterPorId(id));
            return medico;
        }
    }
}

