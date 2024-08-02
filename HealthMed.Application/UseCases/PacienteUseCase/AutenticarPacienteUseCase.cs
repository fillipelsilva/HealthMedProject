using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.PacienteUseCase
{
    public class AutenticarPacienteUseCase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public AutenticarPacienteUseCase(IPacienteRepository usuarioRepository, IMapper mapper)
        {
            _pacienteRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Paciente> Execute(AutenticarPacienteDTO pacienteAutenticacaoDTO)
        {
            Validation(pacienteAutenticacaoDTO);

            Paciente paciente = new Paciente(
                pacienteAutenticacaoDTO.Email,
                pacienteAutenticacaoDTO.Password);

            Paciente _paciente = this._pacienteRepository.Find(x => x.Email.ToLower() == paciente.Email.ToLower()
                                                    && x.Password.ToLower() == paciente.Password.ToLower());
            if (_paciente == null)
                throw new Exception("User not found");

            return _paciente;
        }

        private void Validation(AutenticarPacienteDTO pacienteDto)
        {
            if (string.IsNullOrEmpty(pacienteDto.Email) || string.IsNullOrEmpty(pacienteDto.Password))
                throw new Exception("Email/Password are required.");
        }

    }
}
