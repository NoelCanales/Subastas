namespace Application.Subastas.Update;

public record UpdateSubastaCommand(
    Guid Id,
    Guid ProductoId,
    DateTime FechaInicio,
    DateTime FechaFinal,
    bool Estado) : IRequest<ErrorOr<Unit>>;