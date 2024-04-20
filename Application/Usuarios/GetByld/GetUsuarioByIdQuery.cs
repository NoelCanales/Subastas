using Usuarios.Common;
namespace Application.Usuarios.GetById;

public record GetUsuarioByIdQuery(Guid Id) : IRequest<ErrorOr<UsuarioResponse>>;