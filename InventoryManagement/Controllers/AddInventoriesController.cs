using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Dto;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddInventoriesController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public AddInventoriesController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/AddInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddInventory>>> GetAddInventories()
        {
            return await _context.AddInventories.ToListAsync();
        }

        // GET: api/AddInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddInventory>> GetAddInventory(int id)
        {
            var addInventory = await _context.AddInventories.FindAsync(id);

            if (addInventory == null)
            {
                return NotFound();
            }

            return addInventory;
        }

        // PUT: api/AddInventories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddInventory(int id, AddInventory addInventory)
        {
            if (id != addInventory.AddInventoryId)
            {
                return BadRequest();
            }
            AddInventory oldAddInventory = await  _context.AddInventories.Where(x => x.ProductId == addInventory.ProductId).FirstOrDefaultAsync();
            Product product = await _context.Products.Where(x => x.ProductId == addInventory.ProductId).FirstOrDefaultAsync();
            product.Quantity += addInventory.Quantity - oldAddInventory.Quantity;
            product.Price = addInventory.Price;
            _context.Products.Update(product);
            _context.Entry(addInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddInventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddInventories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AddInventory>> PostAddInventory(AddInventory addInventory)
        {
            _context.AddInventories.Add(addInventory);
            Product product = await _context.Products.Where(x => x.ProductId == addInventory.ProductId).FirstOrDefaultAsync();
            product.Quantity += addInventory.Quantity;
            product.Price = addInventory.Price;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddInventory", new { id = addInventory.AddInventoryId }, addInventory);
        }

        // DELETE: api/AddInventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddInventory>> DeleteAddInventory(int id)
        {
            var addInventory = await _context.AddInventories.FindAsync(id);
            if (addInventory == null)
            {
                return NotFound();
            }

            _context.AddInventories.Remove(addInventory);
            _context.AddInventories.Add(addInventory);
            Product product = await _context.Products.Where(x => x.ProductId == addInventory.ProductId).FirstOrDefaultAsync();
            product.Quantity -= addInventory.Quantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return addInventory;
        }

        private bool AddInventoryExists(int id)
        {
            return _context.AddInventories.Any(e => e.AddInventoryId == id);
        }
    }
}
