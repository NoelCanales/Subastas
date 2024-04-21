using Subastas.Common;

namespace Application.Subastas.GetById;

public record GetSubastaByIdQuery(Guid Id) : IRequest<ErrorOr<SubastaResponse>>;