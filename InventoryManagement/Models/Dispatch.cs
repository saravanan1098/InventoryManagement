using System;

namespace InventoryManagement.Models
{
    public class Dispatch
    {
        public int DispatchId { get; set; }
        public DateTime DispatchDate { get; set; } = DateTime.Now;
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public User DispatchedTo { get; set; }
    }
}
