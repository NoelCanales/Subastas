namespace Application.Subastas.Create;

public record CreateSubastaCommand(
    Guid Id,
    Guid ProductoId,
    DateTime FechaInicio,
    DateTime FechaFinal,
    bool Estado) : IRequest<ErrorOr<Guid>>;