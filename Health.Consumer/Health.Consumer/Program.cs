using Health.Consumer;
using Health.Consumer.Evento;
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
            e.Consumer<ConsultaConsumer>();
        });
    });
});


var host = builder.Build();
host.Run();
