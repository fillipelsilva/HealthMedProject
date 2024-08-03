
using HealthMed.Domain.Validations;
using HealthMed.Infraestructure.Data;
using Health.IoC;
using Microsoft.EntityFrameworkCore;
using HealthMed.Application.AutoMapperSetup;
using FluentValidation.AspNetCore;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PacienteValidation>());

NativeInjector.RegisterServices(builder.Services);

builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;

builder.Services.AddMassTransit((x =>
{
    x.UsingAzureServiceBus((xcontext, cfg) =>
    {
        cfg.Host(conexao);
    });
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
