using Domain.Usuarios;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            usuarioId => usuarioId.Value,
            value => new UsuarioId(value));

        builder.Property(c => c.Nombre).HasMaxLength(250);

        builder.Property(c => c.Apellido).HasMaxLength(250);

        builder.Property(c => c.Dui).HasMaxLength(10);

        builder.Property(c => c.Email).HasMaxLength(250);

        builder.Property(c => c.Telefono).HasMaxLength(50);



    }
}

