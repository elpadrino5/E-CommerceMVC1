using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class CartItem_fe
    {
        [Display(Name = "Cart Item ID")]
        public int CartItemId { get; set; }

        public int Email { get; set; }

        // [Display(Name = "Cart ID")]
        //public int CartId { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public double Price { get; set; }

        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }
    }
}