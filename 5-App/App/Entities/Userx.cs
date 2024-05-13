using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Userx
    {
        public int UserxID { get; set; } 
        public int Age { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        //[Timestamp]
        //public byte[] ConcurrencyToken { get; set; }
        public ICollection<Bookx> Bookxes { get; set; } = new HashSet<Bookx>();
        public ICollection<Rolex> Roles { get; set; } = new HashSet<Rolex>();
        public ICollection<RolexUserx> RolexUserx { get; set; } = new HashSet<RolexUserx>();
        public override string ToString()
        {
            return $"{UserxID} {Name} {Age}";
        }

    }
}



