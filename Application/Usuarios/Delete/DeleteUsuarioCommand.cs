namespace Application.Usuarios.Delete;

public record DeleteUsuarioCommand(Guid Id) : IRequest<ErrorOr<Unit>>;