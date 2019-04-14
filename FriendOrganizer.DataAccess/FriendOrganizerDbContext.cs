using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        private string _constring;

        public FriendOrganizerDbContext()
        {
            // Benyttes kun til Migration
            _constring = @"Server = (localdb)\mssqllocaldb; Database = FriendOrganizerDb; Trusted_Connection = True;";
        }
        public FriendOrganizerDbContext(string constring)
        {
            _constring = constring;
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_constring);
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
