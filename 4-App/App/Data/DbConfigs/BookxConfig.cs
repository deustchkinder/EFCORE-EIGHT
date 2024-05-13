using App.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DbConfigs
{
    public class BookxConfig : IEntityTypeConfiguration<Bookx>
    {
        public void Configure(EntityTypeBuilder<Bookx> builder)
        {
            builder
                 .ToTable("Books")
                 .HasKey(m => m.BookxID);



            builder
                .Property(u => u.Title)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();


            //builder
            //    .HasOne(b => b.Userx)
            //    .WithMany(u => u.Bookxes)
            //    .HasForeignKey(b => b.UserxID)
            //    .OnDelete(DeleteBehavior.Cascade);



        }

    }
}

