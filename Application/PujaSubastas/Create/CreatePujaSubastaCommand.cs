namespace Application.PujaSubastas.Create;

public record CreatePujaSubastaCommand(
    Guid Id,
    Guid SubastaId,
    Guid UsuarioId,
    int CantidadPuja,
    DateTime Fecha) : IRequest<ErrorOr<Guid>>;