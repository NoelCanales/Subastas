using Domain.PujaSubastas;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.PujaSubastas.Update;

internal sealed class UpdatePujaSubastaCommandHandler : IRequestHandler<UpdatePujaSubastaCommand, ErrorOr<Unit>>
{
    private readonly IPujaSubastaRepository _pujasubastaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePujaSubastaCommandHandler(IPujaSubastaRepository pujasubastaRepository, IUnitOfWork unitOfWork)
    {
        _pujasubastaRepository = pujasubastaRepository ?? throw new ArgumentNullException(nameof(pujasubastaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdatePujaSubastaCommand command, CancellationToken cancellationToken)
    {
        if (!await _pujasubastaRepository.ExistsAsync(new PujaSubastaId(command.Id)))
        {
            return Error.NotFound("pujasubasta.NotFound", "The pujasubasta with the provide Id was not found.");
        }

        PujaSubasta pujasubasta = PujaSubasta.UpdatePujaSubasta(
            command.Id, 
            command.SubastaId,
            command.UsuarioId,
            command.CantidadPuja,
            command.Fecha);

        _pujasubastaRepository.Update(pujasubasta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
