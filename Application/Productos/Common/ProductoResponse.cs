namespace Productos.Common;

public record ProductoResponse(
    Guid Id,
    string Nombre,
    string Descripcion,
    string Año,
    decimal Precio
);
