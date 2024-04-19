using Usuarios.Common;

namespace Application.Usuarios.GetAll;

public record GetAllUsuariosQuery() : IRequest<ErrorOr<IReadOnlyList<UsuarioResponse>>>;