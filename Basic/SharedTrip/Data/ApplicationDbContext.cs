namespace SharedTrip
{
    using Models;

    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserTrips)
                .WithOne(ut => ut.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.UserTrips)
                .WithOne(ut => ut.Trip)
                .HasForeignKey(t => t.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserTrip>()
                .HasKey(ut => new { ut.TripId, ut.UserId });
        }
    }
}
