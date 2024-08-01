using HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AgendaDiaConfiguration : IEntityTypeConfiguration<AgendaDia>
{
    public void Configure(EntityTypeBuilder<AgendaDia> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("AgendaDias");

        builder.Property(a => a.Data)
            .IsRequired();

        builder.HasMany(a => a.Horarios)
            .WithOne(h => h.AgendaDia)
            .HasForeignKey(h => h.AgendaDiaId);

        builder.HasMany(a => a.Consultas)
            .WithOne(c => c.AgendaDia)
            .HasForeignKey(c => c.AgendaDiaId);
    }
}
