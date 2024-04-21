using PujaSubastas.Common;
using Domain.PujaSubastas;

namespace Application.PujaSubastas.GetById;


internal sealed class GetPujaSubastaByIdQueryHandler : IRequestHandler<GetPujaSubastaByIdQuery, ErrorOr<PujaSubastaResponse>>
{
    private readonly IPujaSubastaRepository _pujasubastaRepository;

    public GetPujaSubastaByIdQueryHandler(IPujaSubastaRepository pujasubastaRepository)
    {
        _pujasubastaRepository = pujasubastaRepository ?? throw new ArgumentNullException(nameof(pujasubastaRepository));
    }

    public async Task<ErrorOr<PujaSubastaResponse>> Handle(GetPujaSubastaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _pujasubastaRepository.GetByIdAsync(new PujaSubastaId(query.Id)) is not PujaSubasta pujaSubasta)
        {
            return Error.NotFound("PujaSubasta.NotFound", "The pujasubasta with the provide Id was not found.");
        }

        return new PujaSubastaResponse(
            pujaSubasta.Id.Value, 
            pujaSubasta.SubastaId, 
            pujaSubasta.UsuarioId, 
            pujaSubasta.CantidadPuja,
            pujaSubasta.Fecha);
    }
}