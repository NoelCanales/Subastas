using Domain.Primitives;
using ErrorOr;

namespace Domain.Usuarios;

public sealed class Usuario : AggregateRoot
{
    public Usuario (
        UsuarioId id, 
        string nombre,
         string apellido,
          string dui, 
          string email,
          string telefono
          )
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Nombre = nombre;
        Apellido = apellido;
        Dui = dui;
        Email = email;
        Telefono = telefono;
    }

    private Usuario()
    {

    }

    public UsuarioId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Dui { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono{ get; set; } = string.Empty;


   
    public static Usuario UpdateUsuario(Guid id, 
    string nombre, 
    string apellido, 
    string dui, 
    string email,
    string telefono
    )   
    {
        return new Usuario(new UsuarioId(id), 
        nombre, 
        apellido, 
        dui, 
        email, 
        telefono);
    }
}
