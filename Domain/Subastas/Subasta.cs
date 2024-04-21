using Domain.Primitives;

namespace Domain.Subastas;

public sealed class Subasta : AggregateRoot
{
    public Subasta(
        SubastaId id, 
        Guid productoId, 
        DateTime fechaInicio, 
        DateTime fechaFinal, 
        bool estado)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        ProductoId = productoId;
        FechaInicio = fechaInicio;
        FechaFinal = fechaFinal;
        Estado = estado;

    }

    private Subasta()
    {

    }

    public SubastaId Id { get; private set; }
    public Guid ProductoId { get; private set; } = Guid.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public bool Estado { get; set; }
   
    public static Subasta UpdateSubasta(Guid id, 
    Guid productoId, 
    DateTime fechaInicio, 
    DateTime fechaFinal, 
    bool estado)
    {
        return new Subasta(new SubastaId(id), 
        productoId, 
        fechaInicio,
        fechaFinal, 
        estado);
    }
}
