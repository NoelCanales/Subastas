namespace Domain.PujaSubastas;

public interface IPujaSubastaRepository
{
    Task<List<PujaSubasta>> GetAll();
    Task<PujaSubasta?> GetByIdAsync(PujaSubastaId id);
    Task<bool> ExistsAsync(PujaSubastaId id);
    void Add(PujaSubasta pujasubasta);
    void Update(PujaSubasta pujasubasta);
    void Delete(PujaSubasta pujasubasta);
}