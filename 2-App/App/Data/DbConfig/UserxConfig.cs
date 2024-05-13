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
            .HasData(new Userx
            {
                UserxID = 1,
                Name = "User 1",
            });
        }
    }
}
