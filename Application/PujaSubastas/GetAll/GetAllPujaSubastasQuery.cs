using PujaSubastas.Common;

namespace Application.PujaSubastas.GetAll;

public record GetAllPujaSubastasQuery() : IRequest<ErrorOr<IReadOnlyList<PujaSubastaResponse>>>;