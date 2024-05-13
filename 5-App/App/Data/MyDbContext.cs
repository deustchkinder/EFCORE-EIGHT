using App.Data.DbConfigs;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class MyDbContext : DbContext
    {

        //public MyDbContext(DbContextOptions<MyDbContext> ops):base(ops)
        //{


        //}

        public DbSet<Userx> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bookx> Books { get; set; }
        public DbSet<Rolex> Roles { get; set; }
        public DbSet<RolexUserx> RolexUserx { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = EMRE; database = TestDB; integrated security = true; TrustServerCertificate = True;");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }

}



























/*
         //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=CEMO\\SQLEXPRESS;Initial Catalog=EfDb;User ID=sa;Password=1234;TrustServerCertificate=True;");
        //    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Error);

        //}

 
 
 */






















/*
 
 
 
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Userx>()
                .ToTable("Users")
                .HasKey(m=>m.UserxID);


            modelBuilder.Entity<Userx>()
                .Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
 
 
 
 
 
 */