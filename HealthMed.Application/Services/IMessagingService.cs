using HealthMed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public interface IMessagingService
    {
        Task SendMessage(CriacaoConsultaDTO consultaDTO);
        void ReceiveMessage(string queueName);
    }
}
