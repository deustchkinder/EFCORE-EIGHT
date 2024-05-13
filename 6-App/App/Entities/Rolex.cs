using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Rolex
    {
        public int RolexID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Userx> Users { get; set; } = new HashSet<Userx>();
        public ICollection<RolexUserx> RolexUserx { get; set; } = new HashSet<RolexUserx>();

        public override string ToString()
        {
            return $"{RolexID}  {RoleName}";
        }
    }
}
