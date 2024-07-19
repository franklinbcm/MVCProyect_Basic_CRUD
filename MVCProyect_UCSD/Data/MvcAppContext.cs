
using Microsoft.EntityFrameworkCore;
using MVCProyect_UCSD.Models;

namespace MVCProyect_UCSD.Data
{
    public class MvcAppContext : DbContext
    {
        public MvcAppContext(DbContextOptions<MvcAppContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
