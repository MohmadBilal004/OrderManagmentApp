using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enum;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public decimal Totalamount { get; set; }
        public decimal Depositamount { get; set; }
        public int isDelivered { get; set; }
        public Status Status { get; set; }
        public string otherNotes { get; set; }
        public int isDeleted{ get; set; }

        public Customer Customer{ get; set; }
    }
}