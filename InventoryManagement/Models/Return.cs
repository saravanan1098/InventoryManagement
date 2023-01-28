using System;

namespace InventoryManagement.Models
{
    public class Return
    {
        public int ReturnId { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public User  Returnedby { get; set; }
    }
}
