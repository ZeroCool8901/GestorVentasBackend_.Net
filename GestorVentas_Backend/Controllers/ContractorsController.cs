using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorVentas_Backend.Models;

namespace GestorVentas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly GestorVentasContext _context;

        public ContractorsController(GestorVentasContext context)
        {
            _context = context;
        }

        // GET: api/Contractors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contractor>>> GetContractors()
        {
          if (_context.Contractors == null)
          {
              return NotFound();
          }
            return await _context.Contractors.ToListAsync();
        }

        // GET: api/Contractors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contractor>> GetContractor(int id)
        {
          if (_context.Contractors == null)
          {
              return NotFound();
          }
            var contractor = await _context.Contractors.FindAsync(id);

            if (contractor == null)
            {
                return NotFound();
            }

            return contractor;
        }

        // PUT: api/Contractors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractor(int id, Contractor contractor)
        {
            if (id != contractor.IdContractor)
            {
                return BadRequest();
            }

            _context.Entry(contractor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractorExists(id))
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

        // POST: api/Contractors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contractor>> PostContractor(Contractor contractor)
        {
          if (_context.Contractors == null)
          {
              return Problem("Entity set 'GestorVentasContext.Contractors'  is null.");
          }
            _context.Contractors.Add(contractor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContractor", new { id = contractor.IdContractor }, contractor);
        }

        // DELETE: api/Contractors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractor(int id)
        {
            if (_context.Contractors == null)
            {
                return NotFound();
            }
            var contractor = await _context.Contractors.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }

            _context.Contractors.Remove(contractor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContractorExists(int id)
        {
            return (_context.Contractors?.Any(e => e.IdContractor == id)).GetValueOrDefault();
        }
    }
}
