using Microsoft.EntityFrameworkCore;
using ApiRefactor.Models;

namespace ApiRefactor.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<Wave> Waves => Set<Wave>();
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

    }
}
