using System;
using System.Collections.Generic;

namespace OnlineFoodOrderDALCrossPlatform.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
