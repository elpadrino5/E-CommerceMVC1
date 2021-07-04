using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class OrderItem_fe
    {
        public int OrderItemId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }

        public int OrderId { get; set; }
    }
}
