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
    public class AdicionarMedicoUseCase
    {
        private readonly IMedicoRepository _medicoRepository;

        public AdicionarMedicoUseCase(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<bool> Execute(CriarMedicoDTO medicoDTO)
        {
            Medico? medico = new(medicoDTO.Nome, medicoDTO.CPF, medicoDTO.CRM, medicoDTO.Email, medicoDTO.Password);
            await _medicoRepository.Adicionar(medico);
            return true;
        }
    }
}

