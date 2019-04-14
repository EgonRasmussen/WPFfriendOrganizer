## Autofac

I UI-projektet installeres NuGet pakken **Autofac**.

I UI-projektet oprettes folderen **Startup** og klassen **Bootstrapper**:

```c#
public class Boostrapper
{
    public IContainer Bootstrap()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<MainWindow>().AsSelf();
        builder.RegisterType<MainViewModel>().AsSelf();
        builder.RegisterType<FriendDataService>().As<IFriendDataService>();

        return builder.Build();
    }
}
```

Nu skal App.xaml.cs klassen ændres:

```c#
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var container = new Boostrapper().Bootstrap();

        var mainWindow = container.Resolve<MainWindow>();
        mainWindow.Show();
    }
}
```