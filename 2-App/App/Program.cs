using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App.Repos;

//HOSTING CONFIGURATION
using IHost myHost = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.SetBasePath(Environment.CurrentDirectory);
        config.AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices(services =>
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            options.LogTo(Console.WriteLine, LogLevel.Information);
        });
        services.AddScoped<UserxCommands>();
        services.AddScoped<UserxQueries>();
    })
    .ConfigureLogging(m =>
    {
        m.SetMinimumLevel(LogLevel.Error);
        m.AddJsonConsole(m =>
        {
            m.IncludeScopes = true;
            m.TimestampFormat = "HH:mm:ss";
            m.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
            {
                Indented = true
            };
        });
    })
    .Build();

Console.WriteLine("HOSTİNG HAZIR - KİLİTLENMİŞ DURUMDA!");

AddUser();
GetAllUsers();

myHost.Run();

void AddUser()
{
    using (IServiceScope scope = myHost.Services.CreateScope())
    {
        var userxCommands = scope.ServiceProvider.GetRequiredService<UserxCommands>();
        userxCommands.Add(new Userx { Name = "eMERVErir" });
    }
}

void GetAllUsers()
{
    using (IServiceScope scope = myHost.Services.CreateScope())
    {
        var userxQueries = scope.ServiceProvider.GetRequiredService<UserxQueries>();
        var users = userxQueries.GetAll();
        foreach (var item in users)
        {
            Console.WriteLine(item.Name);
        }
    }
}


Console.ReadLine();


//DEPENDECY INJECTION - SERVICES - OPTIONBUILDER - CONFIGUREBUILDER

//IConfiguration configuration = new ConfigurationBuilder()
    //.SetBasePath(Environment.CurrentDirectory)
    //.AddJsonFile("AppSettings.json",optional:true,reloadOnChange:true)
    //.Build();

//var ops = new DbContextOptionsBuilder<MyDbContext>()
    //.UseSqlServer(configuration.GetConnectionString("MyConnection"))
    //.LogTo(Console.WriteLine, LogLevel.Information)
    //.Options;

//MyDbContext db = new(ops);

//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

//UserxCommands userxCommands = new(db);
//UserxQueries userxQueries = new(db);

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(conf =>
{
    return new ConfigurationBuilder()
   .SetBasePath(Environment.CurrentDirectory)
   .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
   .Build();
}
);
//HENUZ HOSTING ORTAMINDA DEGILIZ.
services.AddDbContext<MyDbContext>(options =>
{
    IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

services.AddScoped<UserxCommands>();
services.AddScoped<UserxQueries>(); 

ServiceProvider provider = services.BuildServiceProvider();

MyDbContext db = provider.GetRequiredService<MyDbContext>();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

UserxCommands userxCommands = provider.GetRequiredService<UserxCommands>();
userxCommands.Add(new Userx { Name = "Emre" });

UserxQueries userxQueries = provider.GetRequiredService<UserxQueries>();
userxQueries.GetAll();

Console.Read();