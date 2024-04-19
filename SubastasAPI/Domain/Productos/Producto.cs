using Domain.Primitives;

namespace Domain.Productos;

public sealed class Producto : AggregateRoot
{
    public Producto(ProductoId id, string nombre, string descripcion, string año, decimal precio)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Nombre = nombre;
        Descripcion = descripcion;
        Año = año;
        Precio = precio;

    }

    private Producto()
    {

    }

    public ProductoId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Año { get; set; } = string.Empty;
    public decimal Precio { get; set; } = 0.0M;
   
    public static Producto UpdateProducto(Guid id, string nombre, string descripcion, string año, decimal precio)
    {
        return new Producto(new ProductoId(id), nombre, descripcion, año, precio);
    }
}
