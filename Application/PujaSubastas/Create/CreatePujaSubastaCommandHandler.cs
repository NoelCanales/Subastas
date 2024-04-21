using Domain.PujaSubastas;
using Domain.Primitives;
//using Domain.ValueObjects;
//using Domain.DomainErrors;

namespace Application.PujaSubastas.Create;

public sealed class CreatePujaSubastaCommandHandler : IRequestHandler<CreatePujaSubastaCommand, ErrorOr<Guid>>
{
    private readonly IPujaSubastaRepository _pujasubastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreatePujaSubastaCommandHandler(IPujaSubastaRepository pujasubastaRepository, IUnitOfWork unitOfWork)
    {
        _pujasubastaRepository = pujasubastaRepository ?? throw new ArgumentNullException(nameof(pujasubastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreatePujaSubastaCommand command, CancellationToken cancellationToken)
    {

        var pujasubasta = new PujaSubasta(
            new PujaSubastaId(Guid.NewGuid()),
            command.SubastaId,
            command.UsuarioId,
            command.CantidadPuja,
            command.Fecha
        );

        _pujasubastaRepository.Add(pujasubasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return pujasubasta.Id.Value;
    }
}
