namespace InventoryManagement.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorBillingAddress { get; set; }
        public string VendorShippingAddress { get; set; }
        public string BenBeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIfscNumber { get; set; }

    }
}
