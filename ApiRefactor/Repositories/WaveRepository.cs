using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRefactor.Models;
using Microsoft.EntityFrameworkCore;
using ApiRefactor.Data;

namespace ApiRefactor.Repositories
{
    public class WaveRepository : IWaveRepository
    {
        private readonly AppDBContext _context;


        public WaveRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Wave>> GetAllWaves(int pageSize,int pageNumber)
        {
            return await _context.Waves
                        .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                        .AsNoTracking()
                        .ToListAsync();

        }

        public async Task<Wave?> GetWavesByIdAsync(Guid id)
        {
            
            return await _context.Waves
                        .AsNoTracking()
                        .FirstOrDefaultAsync(w => w.Id == id);
        }

        

        public async Task<bool> SaveWave(Wave wave)
        {
            if (wave == null)
            {
                throw new ArgumentNullException(nameof(wave));
            }

            try
            {
                var data = await _context.Waves.AsNoTracking().AnyAsync(w => w.Id == wave.Id);
                if (data)
                {
                    _context.Waves.Update(wave);
                }
                else
                {
                    await _context.Waves.AddAsync(wave);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                
                return false;
            }
        }
    }
}
