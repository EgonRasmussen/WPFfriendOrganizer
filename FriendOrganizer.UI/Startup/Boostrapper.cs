using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace FriendOrganizer.UI.Startup
{
    public class Boostrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            var constring = ConfigurationManager.ConnectionStrings["FriendOrganizerDb"].ConnectionString;

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FriendOrganizerDbContext>()
                .UseSqlServer(constring);
            builder.RegisterType<FriendOrganizerDbContext>().WithParameter("options", dbContextOptionsBuilder.Options).InstancePerLifetimeScope();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            return builder.Build();
        }
    }

    public class FriendOrganizerDbContextFactory : IDesignTimeDbContextFactory<FriendOrganizerDbContext>
    {
        public FriendOrganizerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FriendOrganizerDbContext>();
            var constring = ConfigurationManager.ConnectionStrings["FriendOrganizerDb"].ConnectionString;
            optionsBuilder.UseSqlServer(constring);

            return new FriendOrganizerDbContext(optionsBuilder.Options);
        }

    }
}
