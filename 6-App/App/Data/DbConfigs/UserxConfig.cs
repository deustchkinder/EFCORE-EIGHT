using App.Data.ValueGenerator;
using App.Entities;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
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
                .HasValueGenerator<MyNameGenerator>()
                .IsRequired();


            builder
                .Property<DateTime>("DateCreated")
                .HasColumnType("datetime")
                //.HasDefaultValue(DateTime.Now)
                //.HasDefaultValueSql("getdate()")
                .HasValueGenerator<MyDateGenerator>()
                .IsRequired();


            builder
               .Property<byte[]>("ConcurrencyToken")
               .IsRowVersion()
               .IsConcurrencyToken();
               //.HasDefaultValue(new byte[8])
               //.IsRequired();





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


            //builder
            //    .HasMany(u => u.Roles)
            //    .WithMany(r => r.Users)
            //    .UsingEntity<RolexUserx>(
            //                        l => l.HasOne(ru => ru.Rolex)
            //                       .WithMany(r => r.RolexUserx)
            //                       //.HasPrincipalKey(rux => rux.RolexID)   
            //                       .HasForeignKey(ru => ru.RolexID)
            //                       .OnDelete(DeleteBehavior.Cascade),

            //                        r => r.HasOne(ru => ru.Userx)
            //                       .WithMany(u => u.RolexUserx)
            //                       //.HasPrincipalKey(rux => rux.UserxID)
            //                       .HasForeignKey(ru => ru.UserxID)
            //                       .OnDelete(DeleteBehavior.Cascade)   //,

            //                        //j => j.ToTable("RolexUserx")


            //                        );




            builder
                 .HasMany(u => u.Roles)

                 .WithMany(r => r.Users)
                 
                 .UsingEntity<RolexUserx>(
                    l => l.HasOne(m => m.Rolex)
                    .WithMany(m => m.RolexUserx)
                    .HasForeignKey(m=>m.RolexID)
                    //.HasPrincipalKey(nameof(Rolex.RolexID))
                    .OnDelete(DeleteBehavior.Cascade),

                    r => r.HasOne(m => m.Userx)
                    .WithMany(m => m.RolexUserx)
                    .HasForeignKey(m=>m.UserxID)
                    //.HasPrincipalKey(nameof(Userx.UserxID))
                    .OnDelete(DeleteBehavior.Cascade)
                   
                    )
                 
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
 
 
  //builder
            //     .HasMany(u => u.Roles)
            //     .WithMany(r => r.Users)
            //     .UsingEntity("RolexUsex",
            //        l => l.HasOne(typeof(Rolex)).WithMany().HasForeignKey("RolexID").HasPrincipalKey(nameof(Rolex.RolexID)),
            //        r => r.HasOne(typeof(Userx)).WithMany().HasForeignKey("UserxID").HasPrincipalKey(nameof(Userx.UserxID)),
            //        j => j.HasKey("RolexID", "UserxID"));




            //builder
            //     .HasMany(u => u.Roles)

            //     .WithMany(r => r.Users)

            //     .UsingEntity<RolexUsex>(
            //        l => l.HasOne(m => m.Rolex)
            //        .WithMany(m => m.RolexUsex)
            //        .HasForeignKey("RolexID")
            //        //.HasPrincipalKey(nameof(Rolex.RolexID))
            //        .OnDelete(DeleteBehavior.Cascade),

            //        r => r.HasOne(m => m.Userx)
            //        .WithMany(m => m.RolexUsex)
            //        .HasForeignKey("UserxID")
            //        //.HasPrincipalKey(nameof(Userx.UserxID))
            //        .OnDelete(DeleteBehavior.Cascade))
            //     .ToTable("RolexUsex");


            //builder
            //    .HasMany(u => u.Roles)
            //    .WithMany(r => r.Users)
            //    .UsingEntity<RolexUsex>(
            //        j => j.HasOne(ru => ru.Rolex)
            //              .WithMany(r => r.RolexUsex)
            //              .HasForeignKey(ru => ru.RolexID),
            //        j => j.HasOne(ru => ru.Userx)
            //              .WithMany(u => u.RolexUsex)
            //              .HasForeignKey(ru => ru.UserxID),
            //        j => j.ToTable("RolexUsex")
            //    );

 
 
 
 
 
 
 
 
 */