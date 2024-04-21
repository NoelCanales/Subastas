using Domain.PujaSubastas;
using Domain.Primitives;

namespace Application.PujaSubastas.Delete;

internal sealed class DeletePujaSubastaCommandHandler : IRequestHandler<DeletePujaSubastaCommand, ErrorOr<Unit>>
{
    private readonly IPujaSubastaRepository _pujasubastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeletePujaSubastaCommandHandler(IPujaSubastaRepository pujasubastaRepository, IUnitOfWork unitOfWork)
    {
        _pujasubastaRepository = pujasubastaRepository ?? throw new ArgumentNullException(nameof(pujasubastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeletePujaSubastaCommand command, CancellationToken cancellationToken)
    {
        if (await _pujasubastaRepository.GetByIdAsync(new PujaSubastaId(command.Id)) is not PujaSubasta pujasubasta)
        {
            return Error.NotFound("subasta.NotFound", "The pujasubasta with the provide Id was not found.");
        }

        _pujasubastaRepository.Delete(pujasubasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
