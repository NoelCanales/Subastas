namespace Application.PujaSubastas.Delete;

public record DeletePujaSubastaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;