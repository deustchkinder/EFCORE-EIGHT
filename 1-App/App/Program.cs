using App.Data;
using App.Entities;
using App.Repos;
using App.Repository;
using Microsoft.EntityFrameworkCore;

//MyDbContext _db = new();
//_db.Database.EnsureDeleted();
//_db.Database.EnsureCreated();

//var user = _db.Users.FirstOrDefault();
//Console.WriteLine(user.Name);

DBCreate();

AddUser();
AddUsers();
GetUser();
UpdateUser();
GetUser();
DeleteUser();
AddUsers();
GetUsers();
Console.WriteLine();
GetUsers2();
Console.WriteLine();
GetUsers3();

/*
Userx userx = new()
{
    Name = "User2",
};
*/


/*
using (var db = new MyDbContext())
{
    //db.Users.Add(userx);
    /*
    var entry = db.Entry(userx); //varlığı görelim sqlde INSERT et  Identıty TEMPORARY seklinde
    db.Entry(userx).State = Microsoft.EntityFrameworkCore.EntityState.Added; //INSERT
    entry = db.Entry(userx); //varlığı userx'e ekledikten sonra görelim
    db.SaveChanges();
    userx.Name = "UserUnChanged3";
    db.Entry(userx).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //UPDATE
    entry = db.Entry(userx); //sqle kayıt ettikten sonra görelim
    db.Entry(userx).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
    entry = db.Entry(userx);
    db.SaveChanges();
    */

//var userx = db.Users.FirstOrDefault();
//var userx = db.Users.AsNoTracking().FirstOrDefault();
//var users = db.Users.AsNoTracking().ToList();
//var entries = db.ChangeTracker.Entries();
/*
foreach ( var entry in entries)
{
    Console.WriteLine(entry.State);
}
*/
//Console.WriteLine(userx);
/*
foreach(var user in users)
{
    Console.WriteLine(user.Name);
}  
}
*/

Console.Read();

void DBCreate()
{
    using var db = new MyDbContext();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}
void AddUser()
{
    UserxCommands userxCommands = new();
    Userx userx = new()
    {
        Name = "Emre",
        Age = 25
    };
    userxCommands.AddUser(userx);

}

void AddUsers()
{
    UserxCommands userxCommands = new();
    List<Userx> userxes = new()
    {
        new()
        {
            Name = "Emre",
            Age = 25
        },
        new()
        {
            Name = "Merve",
            Age = 28
        },
        new()
        {
            Name = "Gamze",
            Age = 35
        },
        new()
        {
            Name = "Züleyha",
            Age = 23
        },
        new()
        {
            Name = "Yusuf",
            Age = 32
        },
    };
    userxCommands.AddUsers(userxes);
}

void UpdateUser()
{
    UserxCommands userxCommands = new();
    UserxQueries userxQueries = new();

    var userx = userxQueries.GetUser(1);
    userx!.Name = "Emrememe";
    userx.Age = 70;



    //Userx userx = new()
    //{
    //    UserxID = 1,
    //    Name = "Aliyyyy",
    //    Age = 2000
    //};

    userxCommands.UpdateUser(userx);

}

void DeleteUser()
{
    UserxCommands userxCommands = new();
    UserxQueries userxQueries = new();
    var userx = userxQueries.GetUser(1);
    userxCommands.DeleteUser(userx!);

}

void GetUser()
{
    UserxQueries userxQueries = new();
    var userx = userxQueries.GetUser(1);
    Console.WriteLine(userx);
}
void GetUsers()
{
    UserxQueries userxQueries = new();
    var userxes = userxQueries.GetUsers();

    Console.WriteLine(string.Join(",\n", userxes));


}
void GetUsers2()
{
    UserxQueries userxQueries = new();
    var userxes = userxQueries.GetUsers(2, 3);

    Console.WriteLine(string.Join(",\n", userxes));


}
void GetUsers3()
{
    UserxQueries userxQueries = new();
    var userxes = userxQueries.GetUsers(m => m.Name.Length > 0);

    Console.WriteLine(string.Join(",\n", userxes));
}

