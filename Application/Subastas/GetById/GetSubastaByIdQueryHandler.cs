using Subastas.Common;
using Domain.Subastas;

namespace Application.Subastas.GetById;


internal sealed class GetSubastaByIdQueryHandler : IRequestHandler<GetSubastaByIdQuery, ErrorOr<SubastaResponse>>
{
    private readonly ISubastaRepository _subastaRepository;

    public GetSubastaByIdQueryHandler(ISubastaRepository subastaRepository)
    {
        _subastaRepository = subastaRepository ?? throw new ArgumentNullException(nameof(subastaRepository));
    }

    public async Task<ErrorOr<SubastaResponse>> Handle(GetSubastaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _subastaRepository.GetByIdAsync(new SubastaId(query.Id)) is not Subasta subasta)
        {
            return Error.NotFound("Subasta.NotFound", "The subasta with the provide Id was not found.");
        }

        return new SubastaResponse(
            subasta.Id.Value, 
            subasta.ProductoId, 
            subasta.FechaInicio, 
            subasta.FechaFinal,
            subasta.Estado);  
        
    }
}