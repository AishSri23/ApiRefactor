using ApiRefactor.Models;


namespace ApiRefactor.Repositories
{
    public interface IWaveRepository
    {
        Task<List<Wave>> GetAllWaves();

        Task<Wave?> GetWavesByIdAsync(Guid id);

        Task<bool> SaveWave(Wave wave);        

        
    }
}
