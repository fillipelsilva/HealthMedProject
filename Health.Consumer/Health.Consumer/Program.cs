using Health.Consumer;
using Health.Consumer.Evento;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using HealthMed.Infraestructure.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var configuration = builder.Configuration;
var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
var nomeFila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(conexao);

        cfg.ReceiveEndpoint(nomeFila, e =>
        {
            e.Consumer<ConsultaConsumer>(context);
        });
    });
});

builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddDbContext<AppDbContext>();

var host = builder.Build();
host.Run();
