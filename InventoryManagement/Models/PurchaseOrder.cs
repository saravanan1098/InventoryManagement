using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PoId { get; set; }
        public int PoNumber { get; set; } = new Random().Next(10000, 99999);
        public int MaterialId { get; set; }
        public string VendorName { get; set; }
        public string PoType { get; set; }
        public DateTime PoDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }

    }
}
