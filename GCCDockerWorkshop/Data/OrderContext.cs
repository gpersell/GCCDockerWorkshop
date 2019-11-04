using Microsoft.EntityFrameworkCore;

namespace GCCDockerWorkshop.Models
{
    public class GCCDockerWorkshopDB : DbContext
    {
        public GCCDockerWorkshopDB(DbContextOptions<GCCDockerWorkshopDB> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}