using System;
using System.Collections.Generic;

namespace OnlineFoodOrderDALCrossPlatform.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryStatus { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Items Item { get; set; }
    }
}
