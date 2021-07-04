using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class OrderPost_fe
    {
        //Items List
        public int OrderId { get; set; }
        public string Email { get; set; }
        public List<OrderItem_fe> ListOrderItems { get; set; }
        public int ItemQty { get; set; }
        public double Total { get; set; }
    }
}