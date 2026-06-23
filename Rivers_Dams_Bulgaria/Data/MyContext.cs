using Microsoft.EntityFrameworkCore;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<River> Rivers { get; set; } = null!;
        public DbSet<Dam> Dams { get; set; } = null!;
        public DbSet<Reservoir> Reservoirs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<River>()
                .HasMany(r => r.Dams)
                .WithOne(d => d.River)
                .HasForeignKey(d => d.RiverId);

            modelBuilder.Entity<Dam>()
            .HasMany(d => d.Reservoirs);
        }
    }
}
