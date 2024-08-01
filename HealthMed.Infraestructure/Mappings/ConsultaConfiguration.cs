using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("Consultas");

        builder.HasOne(c => c.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(c => c.PacienteId);

        builder.HasOne(c => c.Medico)
            .WithMany()
            .HasForeignKey(c => c.MedicoId);

        builder.HasOne(c => c.AgendaDia)
            .WithMany(a => a.Consultas)
            .HasForeignKey(c => c.AgendaDiaId);

        builder.Property(c => c.Horario)
            .IsRequired();
    }
}
