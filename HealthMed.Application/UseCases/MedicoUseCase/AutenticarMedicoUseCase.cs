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
    public class AutenticarMedicoUseCase
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public AutenticarMedicoUseCase(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<Medico> Execute(AutenticarMedicoDTO medicoAutenticacaoDTO)
        {
            Validation(medicoAutenticacaoDTO);

            Medico medico = new Medico(
                medicoAutenticacaoDTO.Email,
                medicoAutenticacaoDTO.Password);

            Medico _medico = this._medicoRepository.Find(x => x.Email.ToLower() == medico.Email.ToLower()
                                                    && x.Password.ToLower() == medico.Password.ToLower());
            if (_medico == null)
                throw new Exception("User not found");

            return _medico;
        }

        private void Validation(AutenticarMedicoDTO medicoDto)
        {
            if (string.IsNullOrEmpty(medicoDto.Email) || string.IsNullOrEmpty(medicoDto.Password))
                throw new Exception("Email/Password are required.");
        }
    }
}
