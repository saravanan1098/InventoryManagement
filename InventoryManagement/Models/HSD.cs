using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Hsd
    {
        [Key]
        public int HsdId { get; set; }
        
        public int TotalQuantity { get; set; } 
    }

}
