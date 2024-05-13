using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Bookx
    {
        public int BookxID { get; set; }
        public string Title { get; set; }

        [ForeignKey(nameof(Userx))]
        public int? UserxID { get; set; }
        public Userx Userx { get; set; }
    }
}
