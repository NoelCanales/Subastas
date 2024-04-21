using Domain.Primitives;

namespace Domain.PujaSubastas;

public sealed class PujaSubasta : AggregateRoot
{
    public PujaSubasta(
        PujaSubastaId id,
        Guid subastaId,
        Guid usuarioId,
        int cantidadPuja,
        DateTime fecha
    )

    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        CantidadPuja = cantidadPuja;
        Fecha = fecha;

    }

    private PujaSubasta()
    {

    }

  
    public PujaSubastaId Id { get; private set; }
    public Guid SubastaId { get; private set; } = Guid.Empty;
    public Guid UsuarioId { get; private set; } = Guid.Empty;
    public int CantidadPuja { get; set; }
    public DateTime Fecha { get; set; }


    public static PujaSubasta UpdatePujaSubasta(Guid id,
    Guid subastaId,
    Guid usuarioId,
    int cantidadpuja,
    DateTime fecha)

    {
        return new PujaSubasta(new PujaSubastaId(id),
        subastaId,
        usuarioId,
        cantidadpuja,
        fecha);
    }
}
