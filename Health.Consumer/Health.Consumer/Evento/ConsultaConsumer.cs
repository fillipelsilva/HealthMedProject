using HealthMed.Domain.Entities;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Consumer.Evento;
internal class ConsultaConsumer : IConsumer<Consulta>
{
    public Task Consume(ConsumeContext<Consulta> context)
    {
        Console.WriteLine(context.Message.Horario);
        return Task.CompletedTask;
    }
}
