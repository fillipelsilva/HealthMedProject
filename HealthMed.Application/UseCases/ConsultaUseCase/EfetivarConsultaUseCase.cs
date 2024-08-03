using HealthMed.Application.DTOs;
using HealthMed.Application.Services;
using HealthMed.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.ConsultaUseCase
{
    public class EfetivarConsultaUseCase
    {
        private readonly IConsultaRepository _consultaRepository;

        public EfetivarConsultaUseCase(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task Execute(CriacaoConsultaDTO consultaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
