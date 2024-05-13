using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMongo.MongoModels
{
    public class MongoAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"City: {City}, Street: {Street}, PostalCode: {PostalCode}";
        }
    }
}
