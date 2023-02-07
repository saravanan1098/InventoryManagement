using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int CategoryId { get; set; }

    }
}
