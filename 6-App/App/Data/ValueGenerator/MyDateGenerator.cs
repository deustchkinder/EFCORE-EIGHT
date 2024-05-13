using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.ValueGenerator
{
    public class MyDateGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => false;
        public override DateTime Next(EntityEntry? entry)
        {
             return DateTime.Now;
        }
    }
  
}
