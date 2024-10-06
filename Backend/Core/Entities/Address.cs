using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string AddressLine1 { get; set; }
         public string AddressLine2 { get; set; }
         public string City { get; set; }
         public string State { get; set; }
         public string Country { get; set; }
    }
}