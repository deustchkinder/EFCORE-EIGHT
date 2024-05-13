
using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


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
    Name = "Emre Demirkan",
    Address = new Address
    {
        Country = "TURKIYE"
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = "İLK YARDIM 101"
        },
        new Bookx
        {
            Title = "BİLGİSAYARLI GÖRÜ"
        },
        new Bookx
        {
            Title = "VERİTABANI YÖNETİM SİSTEMİ "
        }
    },
    Roles = roles

};
Userx userx2 = new()
{
    Age = 23,
    Name = "Züleyha Şen",
    Address = new Address
    {
        Country = "TURKIYE"
    },
    Bookxes = new List<Bookx>
    {
        new Bookx
        {
            Title = "İLK YARDIM 101"
        },
        new Bookx
        {
            Title = "PARAMEDİK GÜZELİ"
        },
        new Bookx
        {
            Title = "BİR İSTİDRİYENİN İNCİSİ "
        }
    },
    Roles = roles.Skip(1).ToList()
};

db.Users.Add(userx);
db.Users.Add(userx2);
db.SaveChanges();

//db.Users.Remove(userx);
//db.SaveChanges();

//db.Users.Remove(userx2);
//db.SaveChanges();

//db.Roles.RemoveRange(roles[0]);
//db.Roles.RemoveRange(roles[1]);
//db.SaveChanges();

var users = db.Users.Include(m=>m.Roles).Where(m=>m.UserxID==1).ToList();
foreach(var item in users)
{
    Console.WriteLine(item);
    foreach(var item2 in item.Roles)
    {
        Console.WriteLine(item2);
    }
}

List<RolexUserx> result = db.RolexUserx.Include(m=>m.Rolex).Include(m=>m.Userx).Where(m=>m.UserxID == 1).ToList();

foreach(var item in result)
{
    Console.WriteLine(item);
    Console.WriteLine(item.Rolex);
    Console.WriteLine(item.Userx);
    Console.WriteLine(LogLevel.Information);

}


//Console.WriteLine("BIRE COK ILISKISI HAZIRLANDI");
Console.WriteLine("ÇOĞA ÇOK İLİŞKİSİ HAZIRLANDI");
Console.Read();


/*
 


==================  OneToMany  ==================

drop table Addresses
drop table Userxes
drop table Bookxes



CREATE TABLE Userxes (
    UserxID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);


INSERT INTO Userxes (UserxID, Name) VALUES
(1, 'John Doe'),
(2, 'Jane Smith');




CREATE TABLE Bookxes (
    BookxID INT PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    UserxID INT FOREIGN KEY REFERENCES Userxes(UserxID)
);



 
INSERT INTO Bookxes (BookxID, Title, UserxID) VALUES
(101, 'Introduction to C#', 1),
(102, 'Data Structures and Algorithms', 1),
(103, 'The Art of SQL', 2);



 
SELECT u.UserxID, u.Name, b.BookxID, b.Title
FROM Userxes u
LEFT JOIN Bookxes b ON u.UserxID = b.UserxID;












==================  OneToOne  ==================


drop TABLE Addresses
drop TABLE Userxes





 CREATE TABLE Userxes (
    UserxID INT PRIMARY KEY,
    Age INT NOT NULL,
    Name NVARCHAR(255) NOT NULL
);



INSERT INTO Userxes (UserxID, Age, Name) VALUES
(1, 25, 'John Doe'),
(2, 30, 'Jane Smith'),
(3, 22, 'Bob Johnson');




CREATE TABLE Addresses (
    AddressID INT PRIMARY KEY,
    UserxID INT UNIQUE,
    Country NVARCHAR(255) NOT NULL,
    FOREIGN KEY (UserxID) REFERENCES Userxes(UserxID)
);



INSERT INTO Addresses (AddressID, Country, UserxID) VALUES
(101, 'USA', 1),
(102, 'Canada', 2),
(103, 'UK', 3);

 
 
SELECT u.UserxID, u.Name, u.Age, a.Country
FROM Userxes u
LEFT JOIN Addresses a ON u.UserxID = a.UserxID;
 
 
 
 
 */