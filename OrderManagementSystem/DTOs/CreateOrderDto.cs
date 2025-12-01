using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal UnitPrice { get; set; }
    }
}