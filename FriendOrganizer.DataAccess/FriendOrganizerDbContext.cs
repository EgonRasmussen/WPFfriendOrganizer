using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        private readonly string _constring;
        public FriendOrganizerDbContext(string constring)
        {
            _constring = constring;
        }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_constring);
            //.EnableSensitiveDataLogging(true)
            //.UseLoggerFactory(new ServiceCollection()
            //.AddLogging(builder => builder.AddConsole()
            //    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
            //    .BuildServiceProvider().GetService<ILoggerFactory>());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend { FirstName = "Thomas", LastName = "Huber" },
                new Friend { FirstName = "Urs", LastName = "Meier" },
                new Friend { FirstName = "Erkan", LastName = "Egin" },
                new Friend { FirstName = "Sara", LastName = "Huber" }
                );
        }
    }
}
