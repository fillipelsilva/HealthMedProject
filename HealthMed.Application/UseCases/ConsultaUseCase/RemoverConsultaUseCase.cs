using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.ConsultaUseCase
{
    public class RemoverConsultaUseCase
    {
        private readonly IConsultaRepository _consultaRepository;

        public RemoverConsultaUseCase(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task Execute(Guid id)
        {
            Consulta? consulta = await _consultaRepository.ObterPorId(id);

            if (consulta == null) throw new ArgumentException("Não há registro com o id informado.");

            await _consultaRepository.Remover(id);
        }
    }
}
