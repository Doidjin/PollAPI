using Microsoft.EntityFrameworkCore;

namespace PoolApi.Data
{
    public class PoolContext : DbContext
    {
        public PoolContext(DbContextOptions<PoolContext> options) : base(options){}

        public DbSet<Pool> Values {get; set;}

        public DbSet<Option> Options {get; set;}

        public DbSet<View> Views {get; set;}

        public DbSet<Vote> Votes {get; set;}
    }
}