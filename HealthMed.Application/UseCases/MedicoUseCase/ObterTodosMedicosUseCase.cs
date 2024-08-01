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

        public ObterTodosMedicosUseCase(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<List<Medico?>> Execute()
        {
            List<Medico> medicos = await _medicoRepository.ObterTodos();
            return medicos!;
        }
    }
}
