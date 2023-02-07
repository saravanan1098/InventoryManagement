using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class HsdIndent
    {
        [Key]
        public int IndentId { get; set; }
        public int IndentNumber { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime ExpectedDateTime { get; set; }
        public DateTime IndentCreatedDate { get; set; } = DateTime.Now;
        public string SupplierName { get; set; }
        public string Username { get; set; } 
    }
}
