namespace Application.Productos.Update;

public record UpdateProductoCommand(
    Guid Id,
    string Nombre,
    string Descripcion,
    string Año,
    decimal Precio) : IRequest<ErrorOr<Unit>>;