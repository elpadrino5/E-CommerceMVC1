using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceMVC1.Models
{
    public class Payment_fe
    {
        public long CardNumber { get; set; }
        public string Email { get; set; }
        public string NameOnCard { get; set; }
        public int Expiration { get; set; }
        public int CVV { get; set; }
    }
}