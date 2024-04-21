using Subastas.Common;

namespace Application.Subastas.GetAll;

public record GetAllSubastasQuery() : IRequest<ErrorOr<IReadOnlyList<SubastaResponse>>>;