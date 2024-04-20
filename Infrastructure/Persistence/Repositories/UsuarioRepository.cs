using Domain.Usuarios;

namespace Infrastructure.Persistence.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Usuario usuario) => _context.Usuarios.Add(usuario);
    public void Delete(Usuario usuario) => _context.Usuarios.Remove(usuario);
    public void Update(Usuario usuario) => _context.Usuarios.Update(usuario);
    public async Task<bool> ExistsAsync(UsuarioId id) => await _context.Usuarios.AnyAsync(usuario => usuario.Id == id);
    public async Task<Usuario?> GetByIdAsync(UsuarioId id) => await _context.Usuarios.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Usuario>> GetAll() => await _context.Usuarios.ToListAsync();
}