using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class Cart_fe
    {
        public string Email { get; set; }
        public List<CartItem_fe> CartItems { get; set; }
    }
}