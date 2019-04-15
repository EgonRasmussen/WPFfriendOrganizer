using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext(DbContextOptions<FriendOrganizerDbContext> options) : base(options)
        {}

        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend { Id = 1, FirstName = "Thomas", LastName = "Huber" },
                new Friend { Id = 2, FirstName = "Urs", LastName = "Meier" },
                new Friend { Id = 3, FirstName = "Erkan", LastName = "Egin" },
                new Friend { Id = 4, FirstName = "Sara", LastName = "Huber" }
                );
        }
    }
}
