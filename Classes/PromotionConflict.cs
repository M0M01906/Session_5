using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_1_.Classes
{
    public class PromotionConflict
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> ConflictingProductIds { get; set; }
        public List<string> ConflictingProductNames { get; set; }
/*        public bool IsResolved { get; set; }
        public bool ResolvedByPriorityChange { get; set; }
        public bool ResolvedByDateChange { get; set; }
        public bool ResolvedByProductRemoval { get; set; }
        public List<string> RemovedProducts { get; set; }*/
    }
}
