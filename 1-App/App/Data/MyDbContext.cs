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
        public DbSet<Userx>Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = EMRE; database = EFDB; integrated security = true; TrustServerCertificate = True;");
            optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information); //warning-error falan göster, ben görmek istiyorum veritabanımda
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserxConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
