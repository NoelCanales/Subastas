using Domain.PujaSubastas;

namespace Infrastructure.Persistence.Repositories;

public class PujaSubastaRepository : IPujaSubastaRepository
{
    private readonly ApplicationDbContext _context;

    public PujaSubastaRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(PujaSubasta pujasubasta) => _context.PujaSubastas.Add(pujasubasta);
    public void Delete(PujaSubasta pujasubasta) => _context.PujaSubastas.Remove(pujasubasta);
    public void Update(PujaSubasta pujasubasta) => _context.PujaSubastas.Update(pujasubasta);
    public async Task<bool> ExistsAsync(PujaSubastaId id) => await _context.PujaSubastas.AnyAsync(pujasubasta => pujasubasta.Id == id);
    public async Task<PujaSubasta?> GetByIdAsync(PujaSubastaId id) => await _context.PujaSubastas.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<PujaSubasta>> GetAll() => await _context.PujaSubastas.ToListAsync();
}