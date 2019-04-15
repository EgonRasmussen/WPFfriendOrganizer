## FriendDataService

I UI-projektet oprettes en folder kaldet **Data** og en **FriendDataService** klasse og tilhørende interface:

```c#
public interface IFriendDataService
{
    IEnumerable<Friend> GetAll();
}
```
Og implementationen:
```c#
public class FriendDataService : IFriendDataService
{
    public IEnumerable<Friend> GetAll()
    {
        // TODO: Load data from real database
        yield return new Friend { FirstName = "Thomas", LastName = "Huber" };
        yield return new Friend { FirstName = "Andreas", LastName = "Boehler" };
        yield return new Friend { FirstName = "Julia", LastName = "Huber" };
        yield return new Friend { FirstName = "Chrissi", LastName = "Egin" };
    }
}
```
.  
.
## MVVM Pattern

![MVVM Pattern](MVVMPattern.pn)

## ViewModel
I UI-projektet oprettes folderen **ViewModel** og en klasse kaldet **ViewModelBase**:
```c#
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

I ViewModel folderen oprettes klassen **MainWiewModel**. 
Her oprettes en Observable collection Friends, hvori alle Friend-objekterne indlæses.
En property SelectedFriend benyttes til at pege på en valgt Friend, med tilhørende Changenotification:

```c#
public class MainWiewModel : ViewModelBase
{
    private IFriendDataService _friendDataService;
    private Friend _selectedFriend;

    public MainViewModel(IFriendDataService friendDataService)
    {
        Friends = new ObservableCollection<Friend>();
        _friendDataService = friendDataService;
    }

    public void Load()
    {
        var friends = _friendDataService.GetAll();
        Friends.Clear();
        foreach (var friend in friends)
        {
            Friends.Add(friend);
        }
    }

    public ObservableCollection<Friend> Friends { get; set; }

    public Friend SelectedFriend
    {
        get { return _selectedFriend; }
        set
        {
            _selectedFriend = value;
            OnPropertyChanged();
        }
    }
}
```

### Instantiering af ViewModel
View'et skal have en reference til ViewModel-objektet og det sker i MainWindow.xaml.cs. 
Det er også her at Load metoden til indlæsning af Friend-objekter kaldes:

```c#
public partial class MainWindow : Window
{
    private MainViewModel _viewModel;

    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _viewModel.Load();
    }
}
```

Constructoren i MainWindow skal modtage et viewModel objekt, som oprettes i App.xaml.cs.
Først fjernes ```StartupUri``` i App.xaml og erstattes med et event ```Startup="Application_Startup"``` og en eventhandler:
```c#
private void Application_Startup(object sender, StartupEventArgs e)
{
    var mainWindow = new MainWindow(
        new MainViewModel(
            new FriendDataService()));
    mainWindow.Show();
}
```

## Opret UI
Opret xaml koden i MainWindow.xaml, se koden.

