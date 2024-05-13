using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options):base(options) 
        {
        
        }
        public DbSet<Userx> Users { get; set; }
    }
}
