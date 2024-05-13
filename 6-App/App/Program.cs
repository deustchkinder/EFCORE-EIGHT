

using App.Data;
using App.Data.ValueGenerator;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;





//=============================================== Entities  ====================

List<Rolex> roles = new()
{
    new Rolex
    {
        RoleName = "Admin",


    },
    new Rolex
    {
        RoleName = "Moderator",

    },
    new Rolex
    {
        RoleName = "User"
    },
    new Rolex
    {
        RoleName = "Guest"
    }
};
Userx userx = new()
{
    Age = 25,

    //Name = "John Doe",
    Name = new MyNameGenerator().Next(null),

    Address = new Address
    {
        AddressDetails = new("TR", "Ist")
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = "Introduction to C#",
            BookType = BookType.Novel


        },
        new Bookx
        {
            Title = "Data Structures and Algorithms",
            BookType = BookType.Story

        },
        new Bookx
        {
            Title = "alo melo ",
            BookType = BookType.Poem

        }
    },
    Roles = roles

};
Userx user2 = new()
{
    Age = 25,

    //Name = "Mon Do",

    Name = new MyNameGenerator().Next(null),

    Address = new Address
    {
        AddressDetails = new("FR", "Pr")
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = "olalala",
            BookType = BookType.Novel

        },
        new Bookx
        {
            Title = "Tollala",
            BookType = BookType.Story

        },
        new Bookx
        {
            Title = "follala ",
            BookType = BookType.Poem

        }
    },
    Roles = roles.Skip(1).ToList()

};







//=============================================== Creatre DB ====================
MyDbContext db = new();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();



//=============================================== Add  Entities =================
db.Users.Add(userx);
db.SaveChanges();

Thread.Sleep(1000);

db.Users.Add(user2);
db.SaveChanges();



//=============================================== Remove Entities =================
//db.Users.Remove(userx);
//db.SaveChanges();

//db.Users.Remove(userx2);
//db.SaveChanges();



//db.Roles.RemoveRange(roles[0]);
//db.Roles.RemoveRange(roles[1]);
//db.SaveChanges();




//=============================== ManyToMany  Queries==============================

var users = db.Users.Include(m => m.Roles).Where(m => m.UserxID == 1).ToList();

foreach (var item in users)
{
    Console.WriteLine(item);
    foreach (var item2 in item.Roles)
    {
        Console.WriteLine(item2);
    }
}


Console.WriteLine("=================");

List<RolexUserx> result = db.RolexUserx.Include(m => m.Rolex)
    .Include(m => m.Userx)
    .Where(m => m.UserxID == 1)
    .ToList();


foreach (var item in result)
{
    Console.WriteLine(item);
    Console.WriteLine(item.Rolex);
    Console.WriteLine(item.Userx);
    Console.WriteLine("====");
}






//==================================== SQL Raw ====================================
//int minLen = 1;
//var rslt = db.Users.FromSqlRaw($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSqlInterpolated($"EXEC getUsers @minLen={minLen}").ToList();
//rslt = db.Users.FromSql($"SELECT * FROM Users  WHERE LEN(Name) > 1;").ToList();






//==================================== Optimistic Concurrency =====================


Userx? userx1 = db.Users.FirstOrDefault();
userx1.Name = "John Doe";


MyDbContext db2 = new();
Userx? userx2 = db2.Users.FirstOrDefault();
userx2.Name = "Mon Do";


db.SaveChanges();


try
{
    db2.SaveChanges();
}
catch (DbUpdateConcurrencyException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine("Rollback");
    db2.Entry(userx2!).Reload();
    userx2.Name = "Mon Do";
    db2.SaveChanges();
}



 

 








Console.WriteLine("OK");




 






Console.Read();





/*
 
 
 
 
create proc getUsers
@minLen INT
AS
SELECT * FROM Users  WHERE LEN(Name) > @minLen;
 



 

/// store procedure parametrelerini dbparametrelere czvirmen lazim
/// sql injectionlara karsi korunman icin
/// /// null parametreli store procedure lerde dah iyi
FromSqlRaw


 

/// string interpolation parametreleri store procedurelere gonderebiliyorsun
/// null parametreli store procedure lerde  fazladan islem yapma ihtiyaci yok
FromSqlInterpolated



 
 
 */


/*
 
Userx? userx1 = db.Users.FirstOrDefault();


MyDbContext db2 = new();
Userx? userx2 = db2.Users.FirstOrDefault();


userx1.Name = "John Doe";
db.SaveChanges();


try
{
    userx2.Name = "Mon Do";
    db2.SaveChanges();
}
catch (DbUpdateConcurrencyException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine("Rollback");
    db2.Entry(userx2!).Reload();
    db2.SaveChanges();
}

 
 */



/*
 
object lockObj = new();

for (int i = 0; i < 3; i++)
{

    Thread tx = new(() =>
    {
        try
        {

            Userx? user = db.Users.FirstOrDefault();
            if (user != null)
            {
                user.Name = new MyNameGenerator().Next(null);
                db.SaveChanges();

            }
            Console.WriteLine(user?.Name);
            Thread.Sleep(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

    });

    tx.Start();



    //Thread tx = new(() =>
    //{
    //    try
    //    {
    //        lock (lockObj)
    //        {
    //            Userx? user = db.Users.FirstOrDefault();
    //            if (user != null)
    //            {
    //                user.Name = new MyNameGenerator().Next(null);
    //                db.SaveChanges();
    //            }
    //            Console.WriteLine(user?.Name);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }

    //});

    //tx.Start();



}

 
 
 */
























