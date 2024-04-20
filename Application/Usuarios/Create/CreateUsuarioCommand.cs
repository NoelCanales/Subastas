namespace Application.Usuarios.Create;

public record CreateUsuarioCommand(
     string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono) : IRequest<ErrorOr<Guid>>;