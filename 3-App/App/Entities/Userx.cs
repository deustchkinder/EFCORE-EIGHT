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

        //One To One Relationalship Database
        public Address Address { get; set; }

        //One To Many Relationalship Database
        //public ICollection<Address>Addresses { get; set; } = new List<Address>();
        public override string ToString()
        {
            return $"{UserxID} {Name} {Age}";
        }

    }
}