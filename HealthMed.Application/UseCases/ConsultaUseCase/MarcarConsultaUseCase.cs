using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Application.Services;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.ConsultaUseCase
{
    public class MarcarConsultaUseCase
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMessagingService _messagingService;

        public MarcarConsultaUseCase(IConsultaRepository consultaRepository, IMessagingService messagingService)
        {
            _consultaRepository = consultaRepository;
            _messagingService = messagingService;
        }

        public async Task Execute(CriacaoConsultaDTO consultaDTO)
        {
            _messagingService.SendMessage("marcar_consulta_queue", JsonConvert.SerializeObject(consultaDTO));
        }
    }
}
