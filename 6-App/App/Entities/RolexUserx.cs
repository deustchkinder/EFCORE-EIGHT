using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class RolexUserx
    {

        public int RolexID { get; set; }
        public Rolex Rolex { get; set; }

        public int UserxID { get; set; }
        public Userx Userx { get; set; }

        public override string ToString()
        {
            return $"{RolexID} {UserxID}";
        }


    }
}
