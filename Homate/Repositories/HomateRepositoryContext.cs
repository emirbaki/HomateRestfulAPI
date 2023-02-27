using Homate.Models;
using Homate.Repositories.Configs;
using Microsoft.EntityFrameworkCore;

namespace Homate.Repositories
{
    public class HomateRepositoryContext : DbContext
    {
        public HomateRepositoryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShopConfig());
        }
        public DbSet<Shop> Shops { get; set; }
    }
}
