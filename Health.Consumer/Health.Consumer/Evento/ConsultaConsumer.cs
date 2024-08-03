using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Consumer.Evento;
public class ConsultaConsumer : IConsumer<Consulta>
{
    private readonly HttpClient _httpClient;

    public ConsultaConsumer(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Consume(ConsumeContext<Consulta> context)
    {
        var ctx = new AppDbContext();

        //var consulta = _consultaRepository.Find(x => x.MedicoId == context.Message.MedicoId && x.Horario == context.Message.Horario);

        var apiUrl = "https://localhost:7033/api/Consulta/EfetivarConsulta";
        string json = JsonConvert.SerializeObject(context.Message);
        using (var httpClient = new HttpClient())
        {
            // Create a StringContent object from the JSON message
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Send the message via POST request
                var response = await httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                    Console.WriteLine($"Response: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
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