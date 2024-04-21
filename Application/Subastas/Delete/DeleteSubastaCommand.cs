namespace Application.Subastas.Delete;

public record DeleteSubastaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;