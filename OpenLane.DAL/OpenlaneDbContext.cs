using Domain;
using Microsoft.EntityFrameworkCore;
using Openlane.Domain;

namespace Openlane.DAL
{
    public class Openlanecontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OpenLaneDb.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Taxes> Taxes { get; set; }
        public DbSet<BikeContainer> BikeContainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeContainer>()
                .HasMany(o => o.Bikes)
                .WithOne(o => o.BikeContainer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bike>()
                .HasMany(o => o.Documents)
                .WithOne(o => o.Bike)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bike>()
                .HasMany(o => o.Taxes)
                .WithOne(o => o.Bike)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bike>()
                .HasMany(o => o.Bids)
                .WithOne(o => o.Bike)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
