namespace PujaSubastas.Common;

public record PujaSubastaResponse(
    Guid Id,
    Guid SubastaId,
    Guid UsuarioId,
    int CantidadPuja,
    DateTime Fecha
    
);

   
   