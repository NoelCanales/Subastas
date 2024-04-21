using PujaSubastas.Common;
using Domain.PujaSubastas;

namespace Application.PujaSubastas.GetAll;


internal sealed class GetAllPujaSubastasQueryHandler : IRequestHandler<GetAllPujaSubastasQuery, ErrorOr<IReadOnlyList<PujaSubastaResponse>>>
{
    private readonly IPujaSubastaRepository _pujasubastaRepository;

    public GetAllPujaSubastasQueryHandler(IPujaSubastaRepository pujasubastaRepository)
    {
        _pujasubastaRepository = pujasubastaRepository ?? throw new ArgumentNullException(nameof(pujasubastaRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<PujaSubastaResponse>>> Handle(GetAllPujaSubastasQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<PujaSubasta> subastas = await _pujasubastaRepository.GetAll();

        return subastas.Select(pujasubasta => new PujaSubastaResponse(
                pujasubasta.Id.Value,
                pujasubasta.SubastaId,
                pujasubasta.UsuarioId,
                pujasubasta.CantidadPuja,
                pujasubasta.Fecha
            )).ToList();
    }
}