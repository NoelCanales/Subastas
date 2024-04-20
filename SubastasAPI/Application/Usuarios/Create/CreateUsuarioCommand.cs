namespace Application.Usuario.Create;

public record CreateUsuarioCommand(
     string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono,
    DateTime CreatedAt,
    DateTime UpdatedAt) : IRequest<ErrorOr<Guid>>;