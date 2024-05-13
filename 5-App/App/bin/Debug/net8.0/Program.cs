
using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using App.Data.ValueGenerator;


MyDbContext db = new();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

List<Rolex> roles = new()
{
    new Rolex
    {
        RoleName = "Admin"
    },
    new Rolex
    {
        RoleName ="Moderator"
    },
    new Rolex
    {
        RoleName ="User"
    },
    new Rolex
    {
        RoleName="Guest"
    }
};


Userx userx = new()
{
    Age = 25,
    //Name = "Emre Demirkan",
    Name = new MyNameGenerator().Next(null),
    Address = new Address
    {
        AddressDetails = new("TR","ERZINCAN")
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = ".NET İLE ENTİTY FRAMEWORK",
            BookType = BookType.Science
        },
        new Bookx
        {
            Title = "BİLGİSAYARLI GÖRÜ",
            BookType = BookType.SciFi
        },
        new Bookx
        {
            Title = "VERİTABANI YÖNETİM SİSTEMİ ",
            BookType=BookType.SciFi
        }
    },
    Roles = roles

};
Userx userx2 = new()
{
    Age = 23,
    //Name = "Züleyha Şen",
    Name = new MyNameGenerator().Next(null),
    Address = new Address
    {
        AddressDetails = new("TR","TOKAT")
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = "İLK YARDIM 101",
            BookType=BookType.Story
        },
        new Bookx
        {
            Title = "PARAMEDİK GÜZELİ",
            BookType=BookType.Fantasy
        },
        new Bookx
        {
            Title = "BİR İSTİDRİYENİN İNCİSİ ",
            BookType=BookType.Poem
        }
    },
    Roles = roles.Skip(1).ToList()
};

db.Users.Add(userx);
db.SaveChanges();
Thread.Sleep(1000);
db.Users.Add(userx2);
db.SaveChanges();

//db.Users.Remove(userx);
//db.SaveChanges();

//db.Users.Remove(userx2);
//db.SaveChanges();

//db.Roles.RemoveRange(roles[0]);
//db.Roles.RemoveRange(roles[1]);
//db.SaveChanges();

var users = db.Users.Include(m => m.Roles).Where(m => m.UserxID == 1).ToList();
foreach (var item in users)
{
    Console.WriteLine(item);
    foreach (var item2 in item.Roles)
    {
        Console.WriteLine(item2);
    }
}

List<RolexUserx> result = db.RolexUserx.Include(m => m.Rolex).Include(m => m.Userx).Where(m => m.UserxID == 1).ToList();

foreach (var item in result)
{
    Console.WriteLine(item);
    Console.WriteLine(item.Rolex);
    Console.WriteLine(item.Userx);
    Console.WriteLine(LogLevel.Information);

}
//Console.WriteLine("BIRE COK ILISKISI HAZIRLANDI");
//Console.WriteLine("ÇOĞA ÇOK İLİŞKİSİ HAZIRLANDI");
//Console.WriteLine("KARMASIK OZELLIKLER DERLENDİ");

//==========================================================================================================================

//int minLen = 1;
//var rslt = db.Users.FromSqlRaw($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSqlInterpolated($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSql($"SELECT * FROM Users WHERE LEN(Name) > 1;").ToList();
//Console.WriteLine("SQLRAW-STORED PROCEDURE");

//===========================================================================================================================
Userx? userx1 = db.Users.FirstOrDefault();
userx1.Name = "Emre Demirkan";

MyDbContext db2 = new();
Userx? user2 = db2.Users.FirstOrDefault();
userx2.Name = "Züleyha Şen";
db.SaveChanges();
try
{
    db2.SaveChanges();
}
catch(DbUpdateConcurrencyException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine("ROLLBACK TRIGGERS SQL");
    db2.Entry(user2!).Reload();
    db2.SaveChanges(true);
}
Console.WriteLine("CONCURRENCYTOKEN EŞZAMANLILIK");
//=============================================================================================================================
Console.Read();
