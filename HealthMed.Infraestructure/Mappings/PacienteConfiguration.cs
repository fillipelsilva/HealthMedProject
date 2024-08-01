using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(p => p.CPF)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(p => p.Consultas)
            .WithOne(c => c.Paciente)
            .HasForeignKey(c => c.PacienteId);
    }
}
