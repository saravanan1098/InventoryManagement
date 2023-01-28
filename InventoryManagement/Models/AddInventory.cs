using System;

namespace InventoryManagement.Models
{
    public class AddInventory
    {
        public int AddInventoryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public DateTime AdditionDate { get; set; } = DateTime.Now;
        public string InvoiceNumber { get; set; }    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
