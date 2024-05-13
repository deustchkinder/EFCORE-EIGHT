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
    public class RolexUserxConfig : IEntitiyTypeConfiguration<RolexUserx>
    {
        public void Configure(EntityTypeBuilder<RolexUserx> builder)
        {
            builder
                .ToTable("RolexUserx")
                .HasKey(r =>new { r.RolexID , r.UserxID });
            }

    }
}
