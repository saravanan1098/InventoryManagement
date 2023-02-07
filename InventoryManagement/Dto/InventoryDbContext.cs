using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace InventoryManagement.Dto
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<AddInventory> AddInventories { get; set; }
        public DbSet<HsdIndent> HsdIndents { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Hsd> Hsds { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

    }

}
