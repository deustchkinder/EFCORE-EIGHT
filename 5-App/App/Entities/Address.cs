using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public AddressDetails AddressDetails { get; set; }

        [ForeignKey(nameof(Userx))]
        public int UserxID { get; set; }
        public Userx Userx { get; set; }

    }

}
