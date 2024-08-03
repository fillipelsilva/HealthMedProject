using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace HealthMed.Application.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public MessagingService(IBus bus, IConfiguration configuration, IMapper mapper)
        {
            _bus = bus;
            _configuration = configuration;
            _mapper = mapper;
        }

        public void ReceiveMessage(string queueName)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessage(CriacaoConsultaDTO consultaDTO)
        {
            try
            {
                var nomeFila = _configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;

                var consulta = _mapper.Map<Consulta>(consultaDTO);

                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
                await endpoint.Send(consulta);

            }
            catch (Exception)
            {
                throw new Exception();
            }

        }



    }
}
