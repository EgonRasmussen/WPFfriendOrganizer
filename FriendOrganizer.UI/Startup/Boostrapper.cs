using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace FriendOrganizer.UI.Startup
{
    public class Boostrapper : IDesignTimeDbContextFactory<FriendOrganizerDbContext>
    {
        DbContextOptions<FriendOrganizerDbContext> dbContextOptions = new DbContextOptionsBuilder<FriendOrganizerDbContext>()
            .UseSqlServer(ConfigurationManager.ConnectionStrings["FriendOrganizerDb"]
            .ConnectionString)
            .Options;

        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FriendOrganizerDbContext>().WithParameter("options", dbContextOptions).InstancePerLifetimeScope();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            return builder.Build();
        }

        public FriendOrganizerDbContext CreateDbContext(string[] args)
        {
            return new FriendOrganizerDbContext(dbContextOptions);
        }
    }
}
