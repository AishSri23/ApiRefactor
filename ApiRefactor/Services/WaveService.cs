using ApiRefactor.Models;
using ApiRefactor.Repositories;

namespace ApiRefactor.Services
{
    public class WaveService
    {
        private readonly IWaveRepository _waveRepository;
        public WaveService(IWaveRepository waveRepository)
        {
            _waveRepository = waveRepository;
        }

        public async Task<List<Wave>> GetAllWavesAsync()
        {
            return await _waveRepository.GetAllWaves();
        }
        public async Task<Wave?> GetWavesByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            return await _waveRepository.GetWavesByIdAsync(id);
        }

        public async Task<Guid> SaveWaveAsync(Wave wave)
        {
            var result = await _waveRepository.SaveWave(wave);
            if (result)
                return wave.Id;
            else
                return Guid.Empty;
        }
    }
}
