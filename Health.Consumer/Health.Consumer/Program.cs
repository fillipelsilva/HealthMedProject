using Health.Consumer;
using Health.Consumer.Evento;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using HealthMed.Infraestructure.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        var configuration = hostContext.Configuration;

        var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
        var nomeFila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;

        services.AddHostedService<Worker>();
        services.AddSingleton<HttpClient>();

        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(conexao);

                cfg.ReceiveEndpoint(nomeFila, e =>
                {
                    e.Consumer<ConsultaConsumer>(context);
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<ConsultaConsumer>();
        });
    }).Build();
host.Run();
