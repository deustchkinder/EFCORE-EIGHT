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
    public class RolexConfig : IEntityTypeConfiguration<Rolex>
    {
        public void Configure(EntityTypeBuilder<Rolex> builder)
        {
            builder
                .ToTable("Roles")
                .HasKey(r => r.RolexID);

            builder
                .Property(r => r.RoleName)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
