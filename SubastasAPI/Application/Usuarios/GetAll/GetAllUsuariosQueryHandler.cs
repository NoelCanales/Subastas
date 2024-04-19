using Usuarios.Common;
using Domain.Usuarios;

namespace Application.Usuarios.GetAll;


internal sealed class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, ErrorOr<IReadOnlyList<UsuarioResponse>>>
{
    private readonly IUsuarioRepository _Repository;

    public GetAllUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<UsuarioResponse>>> Handle(GetAllUsuariosQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Usuario> usuarios = await _usuarioRepository.GetAll();

        return usuarios.Select(usuario => new UsuarioResponse(
                usuario.Id.Value,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Dui,
                usuario.Email,
                usuario.Telefono,
                usuario.CreatedAT,
                usuario.UpdatedAt



            )).ToList();
    }
}