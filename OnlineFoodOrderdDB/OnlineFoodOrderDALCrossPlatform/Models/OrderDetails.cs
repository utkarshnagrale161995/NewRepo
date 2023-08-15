using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineFoodOrderDALCrossPlatform.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public int TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
