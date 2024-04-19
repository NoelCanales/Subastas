using Usuarios.Common;
using Domain.Usuarios;

namespace Application.Usuarios.GetById;


internal sealed class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, ErrorOr<UsuarioResponse>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
    }

    public async Task<ErrorOr<UsuarioResponse>> Handle(GetUsuarioByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _usuarioRepository.GetByIdAsync(new UsuarioId(query.Id)) is not Usuario usuario)
        {
            return Error.NotFound("Usuario.NotFound", "The usuario with the provide Id was not found.");
        }

        return new UsuarioResponse(
            usuario.Id.Value, 
            usuario.Nombre, 
            usuario.Apellido, 
            usuario.Dui,
            usuario.Email,
            usuario.Telefono,
            usuario.CreatedAT,
            usuario.UpdatedAt

        );
    }
}