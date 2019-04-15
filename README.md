## EF Core

![EFCore](ArchitectureWithEFCore.png)

Installér følgende NuGet pakker til projektet DataAccess:

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Og installer følgende til UI-projektet:

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design

Tilføj connectionstring til App.config i UI-projektet (efter <configuration>.<startup>):

```xml
<connectionStrings>
  <add name="FriendOrganizerDb" connectionString="Server = (localdb)\mssqllocaldb; Database = FriendOrganizerDb; Trusted_Connection = True;" />
</connectionStrings>
```

Husk at lave en reference i UI-projektet til ```System.Configuration```.

Opret klassen FriendOrganizerDbContext DataAccess projektet:

```c#
public class FriendOrganizerDbContext : DbContext
{
    public DbSet<Friend> Friends { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FriendOrganizerDb"].ToString())
        .EnableSensitiveDataLogging(true)
        .UseLoggerFactory(new ServiceCollection()
        .AddLogging(builder => builder.AddConsole()
            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
            .BuildServiceProvider().GetService<ILoggerFactory>());

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
```

No database provider has been configured for this DbContext. A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider. If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.





