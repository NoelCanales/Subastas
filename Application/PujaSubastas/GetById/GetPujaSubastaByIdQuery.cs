using PujaSubastas.Common;

namespace Application.PujaSubastas.GetById;

public record GetPujaSubastaByIdQuery(Guid Id) : IRequest<ErrorOr<PujaSubastaResponse>>;