using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagement.Dto
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<AddInventory> AddInventories { get; set; }

    }

}
