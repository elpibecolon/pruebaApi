using Microsoft.EntityFrameworkCore;
using pruebaApi.Entities;

namespace pruebaApi.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

        public DbSet<BrujasMagos> Brujas_Magos { get; set; }
    }
}
