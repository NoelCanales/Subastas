using Domain.Subastas;
using Domain.Primitives;
//using Domain.ValueObjects;
//using Domain.DomainErrors;

namespace Application.Subastas.Create;

public sealed class CreateSubastaCommandHandler : IRequestHandler<CreateSubastaCommand, ErrorOr<Guid>>
{
    private readonly ISubastaRepository _subastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSubastaCommandHandler(ISubastaRepository subastaRepository, IUnitOfWork unitOfWork)
    {
        _subastaRepository = subastaRepository ?? throw new ArgumentNullException(nameof(subastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateSubastaCommand command, CancellationToken cancellationToken)
    {

        var subasta = new Subasta(
            new SubastaId(Guid.NewGuid()),
            command.ProductoId,
            command.FechaInicio,
            command.FechaFinal,
            command.Estado
        );

        _subastaRepository.Add(subasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subasta.Id.Value;
    }
}
