using Domain.Usuarios;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.Usuarios.Update;

internal sealed class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, ErrorOr<Unit>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (!await _usuarioRepository.ExistsAsync(new UsuarioId(command.Id)))
        {
            return Error.NotFound("usuario.NotFound", "The usuario with the provide Id was not found.");
        }

        Usuario usuario = Usuario.UpdateUsuario( 
            command.Id,
            command.Nombre,
            command.Apellido,
            command.Dui,
            command.Email,
            command.Telefono);

        _usuarioRepository.Update(usuario);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
