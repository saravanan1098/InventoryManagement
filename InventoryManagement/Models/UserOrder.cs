namespace InventoryManagement.Models
{
    public class UserOrder
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string SalesDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
