using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medicos");

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(m => m.CPF)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(m => m.CRM)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(m => m.Agendas)
            .WithOne(a => a.Medico)
            .HasForeignKey(a => a.MedicoId);
    }
}
