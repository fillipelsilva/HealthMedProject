using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public interface IMessagingService
    {
        void SendMessage(string queueName, string message);
        void ReceiveMessage(string queueName);
    }
}
