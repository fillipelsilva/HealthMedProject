using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HorarioConsultaConfiguration : IEntityTypeConfiguration<HorarioConsulta>
{
    public void Configure(EntityTypeBuilder<HorarioConsulta> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("HorarioConsultas");

        builder.Property(h => h.Horario)
            .IsRequired();

        builder.Property(h => h.Disponivel)
            .IsRequired();

        builder.HasOne(h => h.AgendaDia)
            .WithMany(a => a.Horarios)
            .HasForeignKey(h => h.AgendaDiaId);
    }
}
