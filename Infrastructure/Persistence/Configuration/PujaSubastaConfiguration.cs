using Domain.PujaSubastas;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PujaSubastaConfiguration : IEntityTypeConfiguration<PujaSubasta>
{
    public void Configure(EntityTypeBuilder<PujaSubasta> builder)
    {
        builder.ToTable("PujaSubastas");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            pujasubastaId => pujasubastaId.Value,
            value => new PujaSubastaId(value));

        builder.Property(c => c.SubastaId);

        builder.Property(c => c.UsuarioId);

        builder.Property(c => c.CantidadPuja);

        builder.Property(c => c.Fecha);

    }
}
