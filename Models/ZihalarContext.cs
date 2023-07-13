using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Drone.WebApp.Models
{
    public class ZihalarContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ZihalarContext(DbContextOptions<ZihalarContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Ziha> Zihalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ziha>().HasKey(z => z.Drone_Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }
    }
}
