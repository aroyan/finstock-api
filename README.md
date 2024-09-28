# Finstock API using ASP.NET and SQLite

## Pattern

### Creating new Model or Entity or Table

1. Create a new file inside `Models` folder and add name for example `User.cs`
2. Inside `/Models/User.cs` define the column for that `User` table, for example

```cs
// Models/User.cs
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
```

3. After defining the columns, open the `/Data/ApplicationDBContext.cs` file and register the `User` model to `DbContext` using `DbSet` like: `DbSet<User> Users { get; set; }`

4. Now it's time to run the migrations using `dotnet ef migrations add AddUser` and `dotnet ef database update`