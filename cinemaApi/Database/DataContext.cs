using cinemaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemaApi.Database
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;
        public DataContext(DbContextOptions options, IConfiguration config) : base(options) => _config = config;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasIndex(c => c.Name).IsUnique();
            });

        }
        public DbSet<Cinema> Cinemas { get; set; } = null!;
    }
}