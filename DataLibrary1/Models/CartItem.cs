﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary1.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public string Email { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }
    }
}