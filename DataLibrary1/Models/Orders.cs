using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary1.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int Email { get; set; }
        public int ItemQty { get; set; }
        public double Total { get; set; }
    }
}
