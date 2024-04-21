using Domain.Subastas;
using Domain.Primitives;

namespace Application.Subastas.Delete;

internal sealed class DeleteSubastaCommandHandler : IRequestHandler<DeleteSubastaCommand, ErrorOr<Unit>>
{
    private readonly ISubastaRepository _subastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteSubastaCommandHandler(ISubastaRepository subastaRepository, IUnitOfWork unitOfWork)
    {
        _subastaRepository = subastaRepository ?? throw new ArgumentNullException(nameof(subastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteSubastaCommand command, CancellationToken cancellationToken)
    {
        if (await _subastaRepository.GetByIdAsync(new SubastaId(command.Id)) is not Subasta subasta)
        {
            return Error.NotFound("subasta.NotFound", "The subasta with the provide Id was not found.");
        }

        _subastaRepository.Delete(subasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
