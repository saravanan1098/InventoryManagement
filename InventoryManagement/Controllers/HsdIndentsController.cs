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
    public class HsdIndentsController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        public HsdIndentsController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/HsdIndents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HsdIndent>>> GetHsdIndents()
        {
            return await _context.HsdIndents.ToListAsync();
        }

        // GET: api/HsdIndents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HsdIndent>> GetHsdIndent(int id)
        {
            var hsdIndent = await _context.HsdIndents.FindAsync(id);

            if (hsdIndent == null)
            {
                return NotFound();
            }

            return hsdIndent;
        }

        // PUT: api/HsdIndents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHsdIndent(int id, HsdIndent hsdIndent)
        {
            if (id != hsdIndent.IndentId)
            {
                return BadRequest();
            }

            _context.Entry(hsdIndent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HsdIndentExists(id))
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

        // POST: api/HsdIndents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HsdIndent>> PostHsdIndent(HsdIndent hsdIndent)
        {
            await _context.Hsds.ForEachAsync(h => h.TotalQuantity += hsdIndent.Quantity);
            _context.HsdIndents.Add(hsdIndent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHsdIndent", new { id = hsdIndent.IndentId }, hsdIndent);
        }

        // DELETE: api/HsdIndents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HsdIndent>> DeleteHsdIndent(int id)
        {
            var hsdIndent = await _context.HsdIndents.FindAsync(id);
            if (hsdIndent == null)
            {
                return NotFound();
            }

            _context.HsdIndents.Remove(hsdIndent);
            await _context.SaveChangesAsync();

            return hsdIndent;
        }

        private bool HsdIndentExists(int id)
        {
            return _context.HsdIndents.Any(e => e.IndentId == id);
        }
    }
}
