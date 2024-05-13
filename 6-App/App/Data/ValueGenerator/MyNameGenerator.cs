using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.ValueGenerator
{
    public class MyNameGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => true;

        public override string Next(EntityEntry? entry)
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
