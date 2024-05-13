using App.Data;
using App.Entities;

MyDbContext db = new();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

Userx userx = new()
{
    Age = 23,
    Name = "Züleyha Şen",
    Address = new Address
    {
        Country = "TURKIYE"

    }
};
db.Users.Add(userx);
db.SaveChanges();

//db.Users.Remove(userx);
//db.SaveChanges();

Console.WriteLine("BİREBİR İLİŞKİ OLUŞTURULDU");

Console.Read();