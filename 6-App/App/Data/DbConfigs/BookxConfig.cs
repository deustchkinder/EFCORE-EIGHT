using App.Data.ValuesConverters;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                .ToTable("Bookxes")
                .HasKey(m => m.BookxID);


            builder
                .Property(u => u.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar(100)")
                .IsRequired();



            builder
                .Property(u => u.BookType)
                .HasColumnType("varchar(100)")
                //.HasConversion(v => v.ToString(), v => (BookType)Enum.Parse(typeof(BookType), v))
                .HasConversion<MyEnumConvrter>()
                .IsRequired();

        }
    }
}
