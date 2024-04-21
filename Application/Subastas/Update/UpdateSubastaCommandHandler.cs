using Domain.Subastas;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.Subastas.Update;

internal sealed class UpdateSubastaCommandHandler : IRequestHandler<UpdateSubastaCommand, ErrorOr<Unit>>
{
    private readonly ISubastaRepository _subastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateSubastaCommandHandler(ISubastaRepository subastaRepository, IUnitOfWork unitOfWork)
    {
        _subastaRepository = subastaRepository ?? throw new ArgumentNullException(nameof(subastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateSubastaCommand command, CancellationToken cancellationToken)
    {
        if (!await _subastaRepository.ExistsAsync(new SubastaId(command.Id)))
        {
            return Error.NotFound("subasta.NotFound", "The subasta with the provide Id was not found.");
        }

        Subasta subasta = Subasta.UpdateSubasta(command.Id, command.ProductoId,
            command.FechaInicio,
            command.FechaFinal,
            command.Estado);

        _subastaRepository.Update(subasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
