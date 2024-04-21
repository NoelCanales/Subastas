using Domain.Subastas;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SubastaConfiguration : IEntityTypeConfiguration<Subasta>
{
    public void Configure(EntityTypeBuilder<Subasta> builder)
    {
        builder.ToTable("Subastas");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            subastaId => subastaId.Value,
            value => new SubastaId(value));

        builder.Property(c => c.ProductoId).HasMaxLength(50);

        builder.Property(c => c.FechaInicio).HasMaxLength(250);

        builder.Property(c => c.FechaFinal);

        builder.Property(c => c.Estado);

    }
}
