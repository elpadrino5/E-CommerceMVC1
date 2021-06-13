using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary1.Models
{
    public class Cart
    {
        public string Email { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}