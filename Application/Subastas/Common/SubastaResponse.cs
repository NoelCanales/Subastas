namespace Subastas.Common;

public record SubastaResponse(
    Guid Id,
    Guid ProductoId,
    DateTime FechaInicio,
    DateTime FechaFinal,
    bool Estado
);

   
   