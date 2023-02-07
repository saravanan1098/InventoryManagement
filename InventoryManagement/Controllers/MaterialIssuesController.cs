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
    public class MaterialIssuesController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public MaterialIssuesController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/MaterialIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialIssue>>> GetMaterialIssuees()
        {
            return await _context.MaterialIssuees.ToListAsync();
        }

        // GET: api/MaterialIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialIssue>> GetMaterialIssue(int id)
        {
            var materialIssue = await _context.MaterialIssuees.FindAsync(id);

            if (materialIssue == null)
            {
                return NotFound();
            }

            return materialIssue;
        }

        // PUT: api/MaterialIssues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialIssue(int id, MaterialIssue materialIssue)
        {
            if (id != materialIssue.MaterialIssueId)
            {
                return BadRequest();
            }
            AddInventory oldAddInventory = await _context.AddInventories.Where(x => x.MaterialId == materialIssue.MaterialId).FirstOrDefaultAsync();
            Material Material = await _context.Materials.Where(x => x.MaterialId == materialIssue.MaterialId).FirstOrDefaultAsync();
            Material.Quantity -= materialIssue.Quantity - oldAddInventory.Quantity;

            _context.Entry(materialIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialIssueExists(id))
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

        // POST: api/MaterialIssues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaterialIssue>> PostMaterialIssue(MaterialIssue materialIssue)
        {
            _context.MaterialIssuees.Add(materialIssue);
            Material Material = await _context.Materials.Where(x => x.MaterialId == materialIssue.MaterialId).FirstOrDefaultAsync();
            Material.Quantity -= materialIssue.Quantity;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialIssue", new { id = materialIssue.MaterialIssueId }, materialIssue);
        }

        // DELETE: api/MaterialIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialIssue>> DeleteMaterialIssue(int id)
        {
            var materialIssue = await _context.MaterialIssuees.FindAsync(id);
            if (materialIssue == null)
            {
                return NotFound();
            }

            _context.MaterialIssuees.Remove(materialIssue);
            Material Material = await _context.Materials.Where(x => x.MaterialId == materialIssue.MaterialId).FirstOrDefaultAsync();
            Material.Quantity += materialIssue.Quantity;
            _context.Materials.Update(Material);
            await _context.SaveChangesAsync();

            return materialIssue;
        }

        private bool MaterialIssueExists(int id)
        {
            return _context.MaterialIssuees.Any(e => e.MaterialIssueId == id);
        }
    }
}
