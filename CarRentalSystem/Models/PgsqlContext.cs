using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Models
{
    public class PgsqlContext : DbContext
    {
        public PgsqlContext(DbContextOptions<PgsqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<Agent>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Rental>();
        }
    }
}
