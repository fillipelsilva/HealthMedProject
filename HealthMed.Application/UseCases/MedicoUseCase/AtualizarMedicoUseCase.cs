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
    public class AtualizarMedicoUseCase
    {
        private readonly IMedicoRepository _medicoRepository;

        public AtualizarMedicoUseCase(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task Execute(AlterarMedicoDTO medicoDTO)
        {
            var medico = await _medicoRepository.ObterPorId(medicoDTO.Id);
            
            medico.AlterarMedico(medicoDTO.Nome, medicoDTO.CPF, medicoDTO.CRM);

            await _medicoRepository.Atualizar(medico);
        }
    }
}

