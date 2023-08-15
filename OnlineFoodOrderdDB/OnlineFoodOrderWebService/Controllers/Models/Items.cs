using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderWebService.Controllers.Models
{
    public class Items
    {
        [Required]
        public string ItemId { get; set; }

        [Required]
        [MinLength(4), MaxLength(50)]
        public string ItemName { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
