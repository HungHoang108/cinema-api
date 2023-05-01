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
        public DbSet<Cinema> Cinemas { get; set; } = null!;
    }
}