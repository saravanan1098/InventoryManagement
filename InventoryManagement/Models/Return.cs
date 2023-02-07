using System;

namespace InventoryManagement.Models
{
    public class Return
    {
        public int ReturnId { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public User  Returnedby { get; set; }
    }
}
