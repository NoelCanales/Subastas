namespace Application.Usuarios.Update;

public record UpdateUsuarioCommand(
    Guid Id,
    string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono) : IRequest<ErrorOr<Unit>>;