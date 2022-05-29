using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>()
                .ToTable("Manufacturer");

            modelBuilder.Entity<Model>()
                .ToTable("Model")
                .HasOne<Manufacturer>()
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.ManufacturerId);
        }
    }
}