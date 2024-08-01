using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthMed.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<AgendaDia> AgendaDias { get; set; }
        public DbSet<HorarioConsulta> HorarioConsultas { get; set; }
        private readonly IConfiguration _config;
        public AppDbContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mappings
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultaConfiguration());
            modelBuilder.ApplyConfiguration(new AgendaConfiguration());
            modelBuilder.ApplyConfiguration(new AgendaDiaConfiguration());
            modelBuilder.ApplyConfiguration(new HorarioConsultaConfiguration());

            // Ignorar propriedades não mapeadas
            modelBuilder.Entity<Paciente>().Ignore(p => p.ValidationResult);

            // Configuração para evitar múltiplos caminhos de cascata
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AgendaDia>()
                .HasOne(ad => ad.Agenda)
                .WithMany(a => a.Dias)
                .HasForeignKey(ad => ad.AgendaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
