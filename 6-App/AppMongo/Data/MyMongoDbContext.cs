
using AppMongo.MongoModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMongo.Data
{
    public class MyMongoDbContext:DbContext
    {
        public DbSet<MongoUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMongoDB("mongodb://localhost:27017", "myDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MongoUser>(m =>
            {
                m.ToCollection("Users");
                m.Property(x => x.Name).HasElementName("firstName");
            });
        }
    }
}
