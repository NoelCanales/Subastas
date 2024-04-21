using Subastas.Common;
using Domain.Subastas;

namespace Application.Subastas.GetAll;


internal sealed class GetAllSubastasQueryHandler : IRequestHandler<GetAllSubastasQuery, ErrorOr<IReadOnlyList<SubastaResponse>>>
{
    private readonly ISubastaRepository _subastaRepository;

    public GetAllSubastasQueryHandler(ISubastaRepository subastaRepository)
    {
        _subastaRepository = subastaRepository ?? throw new ArgumentNullException(nameof(subastaRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<SubastaResponse>>> Handle(GetAllSubastasQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Subasta> subastas = await _subastaRepository.GetAll();

        return subastas.Select(subasta => new SubastaResponse(
                subasta.Id.Value,
                subasta.ProductoId,
                subasta.FechaInicio,
                subasta.FechaFinal,
                subasta.Estado
            )).ToList();
    }
}