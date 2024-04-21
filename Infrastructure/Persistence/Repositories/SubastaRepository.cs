using Domain.Subastas;

namespace Infrastructure.Persistence.Repositories;

public class SubastaRepository : ISubastaRepository
{
    private readonly ApplicationDbContext _context;

    public SubastaRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Subasta subasta) => _context.Subastas.Add(subasta);
    public void Delete(Subasta subasta) => _context.Subastas.Remove(subasta);
    public void Update(Subasta subasta) => _context.Subastas.Update(subasta);
    public async Task<bool> ExistsAsync(SubastaId id) => await _context.Subastas.AnyAsync(subasta => subasta.Id == id);
    public async Task<Subasta?> GetByIdAsync(SubastaId id) => await _context.Subastas.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Subasta>> GetAll() => await _context.Subastas.ToListAsync();
}