using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class Order_fe
    {
        //Items List
        public int OrderId { get; set; }
        public int Email { get; set; }
        public List<CartItem_fe> ListCartItems { get; set; }
        public int ItemQty { get; set; }
        public double Total { get; set; }

        //Address
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        //Payment
        public long CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public int Expiration { get; set; }
        public int CVV { get; set; }
    }
}