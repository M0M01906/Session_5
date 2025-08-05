using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_1_.Classes
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public bool Seasonal { get; set; }
        public bool Active { get; set; }
        public System.DateTime IntroducedDate { get; set; }
        public string Ingredients { get; set; }
    }
}
