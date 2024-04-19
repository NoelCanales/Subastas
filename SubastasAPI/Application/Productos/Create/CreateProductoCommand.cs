namespace Application.Productos.Create;

public record CreateProductoCommand(
    string Nombre,
    string Descripcion,
    string Año,
    decimal Precio) : IRequest<ErrorOr<Guid>>;