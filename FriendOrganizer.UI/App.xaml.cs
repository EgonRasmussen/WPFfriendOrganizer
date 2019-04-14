using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using System.Windows;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(
                new MainViewModel(
                    new FriendDataService()));
            mainWindow.Show();
        }
    }
}
