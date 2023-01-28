using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int CategoryId { get; set; }

    }
}
