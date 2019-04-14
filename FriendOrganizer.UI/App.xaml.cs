using Autofac;
using FriendOrganizer.UI.Startup;
using System.Windows;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var container = new Boostrapper().Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}

