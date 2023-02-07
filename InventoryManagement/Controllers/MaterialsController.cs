﻿using System;
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
    public class MaterialsController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public MaterialsController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var Material = await _context.Materials.FindAsync(id);

            if (Material == null)
            {
                return NotFound();
            }

            return Material;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material Material)
        {
            if (id != Material.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material Material)
        {
            _context.Materials.Add(Material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = Material.MaterialId }, Material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> DeleteMaterial(int id)
        {
            var Material = await _context.Materials.FindAsync(id);
            if (Material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(Material);
            await _context.SaveChangesAsync();

            return Material;
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.MaterialId == id);
        }
    }
}
