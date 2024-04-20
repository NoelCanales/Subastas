namespace Usuario.Common;

public record UsuarioResponse(
    Guid Id,
    string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
