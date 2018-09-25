using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookit.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public int BookId { get; set; }
        public int Price { get; set; }

        public OrderState State { get; set; }

        public DateTime TimeCreated { get; set; }
    }

    public enum OrderState
    {
        New=0,
        Delivered=1
    }
}
