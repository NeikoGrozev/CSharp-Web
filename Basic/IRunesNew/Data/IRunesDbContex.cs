namespace IRunesNew.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class IRunesDbContex : DbContext
    {
        public IRunesDbContex()
        {
        }
        public IRunesDbContex(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=IRunes; Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
