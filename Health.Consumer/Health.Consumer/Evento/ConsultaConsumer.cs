using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Consumer.Evento;
public class ConsultaConsumer : IConsumer<Consulta>
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaConsumer(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public Task Consume(ConsumeContext<Consulta> context)
    {
        var ctx = new AppDbContext();

        var consulta = _consultaRepository.Find(x => x.MedicoId == context.Message.MedicoId && x.Horario == context.Message.Horario);

        Console.WriteLine(context.Message.Horario);
        Console.WriteLine(consulta.Medico.Nome);
        return Task.CompletedTask;
    }
}

//https://send-email-grupo1-hackathon.azurewebsites.net/send-email
//https://send-email-grupo1-hackathon.azurewebsites.net/send-email-patient
//vai ficar o send-email com:
//{
//    "to" : "daviemanuel94@gmail.com",
//    "doctor" : "Davi Emanuel Nogueira",
//    "patient" : "Renato Luís",
//    "appointment" : "2024-08-06T19:00:00"
//}
//send - email - patient:
//{
//    "to" : "daviemanuel94@gmail.com",
//    "doctor" : "Davi Emanuel Nogueira",
//    "patient" : "Renato Luís",
//    "appointment" : "2024-08-06T19:00:00",
//    "isConfirmed" : false
//}