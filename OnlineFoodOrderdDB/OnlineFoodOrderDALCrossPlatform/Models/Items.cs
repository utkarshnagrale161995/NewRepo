using System;
using System.Collections.Generic;

namespace OnlineFoodOrderDALCrossPlatform.Models
{
    public partial class Items
    {
        public Items()
        {
            Orders = new HashSet<Orders>();
        }

        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
