using AppMongo.Data;
using AppMongo.MongoModels;

var dbMongo = new MyMongoDbContext();

var userxMongo = new MongoUser
{
    id = new MongoDB.Bson.ObjectId(),
    Name = "Sümeyye",
    MongoAddress = new()
    {

        City = "Istanbul",
        PostalCode = "34182",
        Street = "Neşe Kaynağı "
    },
    MongoAddresses =
    [
        new()
        {

            City = "Tokat",
            PostalCode = "60024",
            Street = "Aşıklar Çıkmazı"
        },
        new()
        {

            City = "Erzincan",
            PostalCode = "24000",
            Street = "Altıntepeden Dörtyola"
        }
    ]
};

dbMongo.Users.Add(userxMongo);
dbMongo.SaveChanges();

var usr = dbMongo.Users.FirstOrDefault();

Console.WriteLine(usr);

Console.Read();