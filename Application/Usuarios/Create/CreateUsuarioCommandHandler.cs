using Domain.Usuarios;
using Domain.Primitives;

namespace Application.Usuarios.Create;

public sealed class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, ErrorOr<Guid>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateUsuarioCommand command, CancellationToken cancellationToken)
    {

        var usuario = new Usuario(
            new UsuarioId(Guid.NewGuid()),
            command.Nombre,
            command.Apellido,
            command.Dui,
            command.Email,
            command.Telefono
        );

        _usuarioRepository.Add(usuario);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return usuario.Id.Value;
    }
}
