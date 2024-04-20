namespace Domain.Usuarios;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAll();
    Task<Usuario?> GetByIdAsync(UsuarioId id);
    Task<bool> ExistsAsync(UsuarioId id);
    void Add(Usuario usuario);
    void Update(Usuario usuario);
    void Delete(Usuario usuario);
}