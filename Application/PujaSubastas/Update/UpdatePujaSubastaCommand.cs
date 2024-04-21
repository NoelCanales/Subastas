namespace Application.PujaSubastas.Update;

public record UpdatePujaSubastaCommand(
    Guid Id,
    Guid SubastaId,
    Guid UsuarioId,
    int CantidadPuja,
    DateTime Fecha) : IRequest<ErrorOr<Unit>>;