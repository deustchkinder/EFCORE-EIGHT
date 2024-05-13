using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DbConfigs
{
    public class UserxConfig : IEntityTypeConfiguration<Userx>
    {
        public void Configure(EntityTypeBuilder<Userx> builder)
        {
            builder
                 .ToTable("Users")
                 .HasKey(m => m.UserxID);


            builder
                .Property(u => u.Age)
                .HasColumnType("int")
                .IsRequired();


            builder
                .Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)")
                .IsRequired();



            builder
                .HasOne(u => u.Address)
                .WithOne(a => a.Userx)
                .HasForeignKey<Address>(a => a.UserxID)
                .OnDelete(DeleteBehavior.Cascade);



            builder
                .HasMany(u => u.Bookxes)
                .WithOne(b => b.Userx)
                .HasForeignKey(b => b.UserxID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<RolexUserx>(
                l => l.HasOne(m => m.Rolex).WithMany(m => m.RolexUserx).HasForeignKey(m => m.RolexID).OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne(m => m.Userx).WithMany(m => m.RolexUserx).HasForeignKey(m => m.UserxID).OnDelete(DeleteBehavior.Cascade))
                .ToTable("RolexUserx");
                






            //builder
            //    .HasData(new Userx
            //    {
            //        UserxID = 1,
            //        Name = "User 1"
            //    });

        }

    }

}













/*
 
 
builder
    .HasOne(u => u.Address)
    .WithOne(a => a.Userx)
    .HasForeignKey<Address>(a => a.UserxID);

 

 
 */