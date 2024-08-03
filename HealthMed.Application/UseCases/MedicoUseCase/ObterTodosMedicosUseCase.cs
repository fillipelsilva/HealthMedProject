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
    public class ObterTodosMedicosUseCase
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public ObterTodosMedicosUseCase(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicoDTO?>> Execute()
        {
            List<MedicoDTO> medicos = _mapper.Map<List<MedicoDTO>>(await _medicoRepository.ObterTodosMedicosComAgenda());
            return medicos!;
        }
    }
}
