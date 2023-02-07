using System;

namespace InventoryManagement.Models
{
    public class MaterialIssue
    {
        public int MaterialIssueId { get; set; }
        public DateTime MaterialIssueDate { get; set; } = DateTime.Now;
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public User MaterialIssueedTo { get; set; }
    }
}
