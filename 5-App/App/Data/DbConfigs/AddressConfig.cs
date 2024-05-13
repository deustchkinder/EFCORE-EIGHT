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
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                 .ToTable("Addresses")
                 .HasKey(m => m.AddressID);



            //builder
            //    .Property(u => u.Country)
            //    .HasColumnName("Name")
            //    .HasColumnType("varchar(100)")
            //    .IsRequired();



            //builder
            // .ComplexProperty(u => u.AddressDetails)
            // .Property(u => u.Country)
            // .HasColumnName("City")
            // .HasColumnType("varchar(100)")
            // .IsRequired();


            //builder
            //    .ComplexProperty(u => u.AddressDetails)
            //    .Property(u => u.City)
            //    .HasColumnName("City")
            //    .HasColumnType("varchar(100)")
            //    .IsRequired();

            builder
                .OwnsOne(u => u.AddressDetails, a =>
                {
                    a.Property(u => u.Country)
                    .HasColumnName("Country")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                    a.Property(u => u.City)
                    .HasColumnName("City")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                });











            //builder
            //    .HasOne(u => u.Userx)
            //    .WithOne(a => a.Address)
            //    .HasForeignKey<Address>(a => a.UserxID);


            //.HasOne(u => u.Userx)
            //.WithOne(a => a.Address)
            //.HasForeignKey<Address>(a => a.UserxID);
        }

    }
}



/*
 
 
 

 builder
     .HasOne(u => u.Userx)
     .WithOne(a => a.Address)
     .HasForeignKey<Address>(a => a.UserxID);
 
 
 */