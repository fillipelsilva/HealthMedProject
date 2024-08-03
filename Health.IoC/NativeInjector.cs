using HealthMed.Application.Services;
using HealthMed.Application.UseCases.AgendaDiaUseCase;
using HealthMed.Application.UseCases.AgendaUseCase;
using HealthMed.Application.UseCases.ConsultaUseCase;
using HealthMed.Application.UseCases.HorarioConsultaUseCase;
using HealthMed.Application.UseCases.MedicoUseCase;
using HealthMed.Application.UseCases.PacienteUseCase;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Health.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection service)
        {
            #region Services
            service.AddScoped<AdicionarMedicoUseCase>();
            service.AddScoped<AdicionarAgendaUseCase>();
            service.AddScoped<ObterAgendaPorMedicoIdUseCase>();
            service.AddScoped<AtualizarMedicoUseCase>();
            service.AddScoped<EfetivarConsultaUseCase>();
            service.AddScoped<RemoverMedicoUseCase>();
            service.AddScoped<RemoverAgendaUseCase>();
            service.AddScoped<ObterHorarioConsultaPorIdUseCase>();
            service.AddScoped<AutenticarMedicoUseCase>();
            service.AddScoped<ObterAgendaPorIdUseCase>();
            service.AddScoped<ObterMedicoPorIdUseCase>();
            service.AddScoped<ObterConsultaPorIdUseCase>();
            service.AddScoped<ObterTodosMedicosUseCase>();
            service.AddScoped<MarcarConsultaUseCase>();
            service.AddScoped<AdicionarPacienteUseCase>();
            service.AddScoped<AtualizarPacienteUseCase>();
            service.AddScoped<RemoverPacienteUseCase>();
            service.AddScoped<RemoverHorarioConsultaUseCase>();
            service.AddScoped<ObterAgendaDiaPorIdUseCase>();
            service.AddScoped<AdicionarHorarioConsultaUseCase>();
            service.AddScoped<ObterPacientePorIdUseCase>();
            service.AddScoped<IMessagingService, MessagingService>();
            #endregion
            #region Repositories
            service.AddSingleton<HttpClient>();
            service.AddScoped<IPacienteRepository, PacienteRepository>();
            service.AddScoped<IMedicoRepository, MedicoRepository>();
            service.AddScoped<IConsultaRepository, ConsultaRepository>();
            service.AddScoped<IHorarioConsultaRepository, HorarioConsultaRepository>();
            service.AddScoped<IAgendaDiaRepository, AgendaDiaRepository>();
            service.AddScoped<IAgendaRepository, AgendaRepository>();
            #endregion
        }
    }
}
