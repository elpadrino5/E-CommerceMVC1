using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class Product_fe   
    {
        //[Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        // [DataType(DataType.Currency)]
        public double Price { get; set; }

        [StringLength(300, ErrorMessage = "You exided the amount of allowed characters (300)")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }
    }
}