namespace Domain.Subastas;

public interface ISubastaRepository
{
    Task<List<Subasta>> GetAll();
    Task<Subasta?> GetByIdAsync(SubastaId id);
    Task<bool> ExistsAsync(SubastaId id);
    void Add(Subasta subasta);
    void Update(Subasta subasta);
    void Delete(Subasta subasta);
}