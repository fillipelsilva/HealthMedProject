using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.HorarioConsultaUseCase
{
    public class RemoverHorarioConsultaUseCase
    {
        private readonly IHorarioConsultaRepository _horarioConsultaRepository;

        public RemoverHorarioConsultaUseCase(IHorarioConsultaRepository horarioConsultaRepository)
        {
            _horarioConsultaRepository = horarioConsultaRepository;
        }

        public async Task Execute(Guid id)
        {
            HorarioConsulta? horarioConsulta = await _horarioConsultaRepository.ObterPorId(id);

            if (horarioConsulta == null) throw new ArgumentException("Não há registro com o id informado.");

            await _horarioConsultaRepository.Remover(id);
        }
    }
}
