using ApiRefactor.Models;


namespace ApiRefactor.Repositories
{
    public interface IWaveRepository
    {
        Task<List<Wave>> GetAllWaves(int pageSize, int PageNumber);

        Task<Wave?> GetWavesByIdAsync(Guid id);

        Task<bool> SaveWave(Wave wave);        

        
    }
}
