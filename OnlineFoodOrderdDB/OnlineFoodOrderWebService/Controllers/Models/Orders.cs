using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderWebService.Controllers.Models
{
    public class Orders
    {
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string ItemId { get; set; }

        [Required]
        [Range(minimum:0,maximum:Double.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string DeliveryStatus { get; set; }

    }
}
