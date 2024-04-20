using Domain.Usuarios;
using Domain.Primitives;

namespace Application.Usuarios.Delete;

internal sealed class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, ErrorOr<Unit>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (await _usuarioRepository.GetByIdAsync(new UsuarioId(command.Id)) is not Usuario usuario)
        {
            return Error.NotFound("usuario.NotFound", "The usuario with the provide Id was not found.");
        }

        _usuarioRepository.Delete(usuario);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
