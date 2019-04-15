# WPF projektet FriendOrganizer

Projektet er en variation af det som demonstreres i Pluralsight-kurset [Building an Enterprise App with WPF, MVVM, and Entity Framework Code First](https://app.pluralsight.com/library/courses/wpf-mvvm-entity-framework-app/table-of-contents)
af Thomas Claudius Huber.

Der anvendes WPF med .NET 4.7.2 og .NET Standard classlibraries, samt EF Core 2.2 og Autofac.

Der findes følgende branches:

- 1.ArchitectureSetup
- 2.BasicUIlayer. Her anvendes hardcodede data, som vises i et simpelt View.
- 3.AutofacDependencyInjection. Nu anvendes Autofac til at lave Dependency injection.
- 4.EFCore. Her udskiftes de statiske data med en SQL-database vha. Entity Framework Core.


## 1.ArchitectureSetup
Opret et *.NET Standard* classlibrary kaldet **FriendOrganizer.Model** med klassen Friend.cs:

```c#
public class Friend
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
```

Opret endnu et *.NET Standard* projekt kaldet **FriendOrganizer.DataAccess**.

Til sidst oprettes et *WPF* projekt kaldet **FriendOrganizer.UI**.

Der laves følgende referencer:

- DataAccess refererer til Model
- UI refererer til både Model og DataAccess.

