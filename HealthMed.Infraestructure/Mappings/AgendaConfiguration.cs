using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("Agendas");

        builder.Property(a => a.Nome)
            .IsRequired();

        builder.HasOne(a => a.Medico)
            .WithMany(m => m.Agendas)
            .HasForeignKey(a => a.MedicoId);

        builder.HasMany(a => a.Dias)
            .WithOne(d => d.Agenda)
            .HasForeignKey(d => d.AgendaId);
    }
}
