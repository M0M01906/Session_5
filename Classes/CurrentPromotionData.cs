using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_1_.Classes
{
    public class CurrentPromotionData
    {
        public string PromotionName { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> SelectedProductIds { get; set; }
    }
}
