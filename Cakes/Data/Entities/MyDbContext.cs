using Microsoft.EntityFrameworkCore;
namespace Cakes.Data.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Cake> Cake { get; set; }

    }
}
