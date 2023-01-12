using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCRUD.Server.Models;
using BlazorCRUD.Server.Data;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionesController : ControllerBase
    {
        private readonly TrabajoFinalContext _context;

        public CondicionesController(TrabajoFinalContext context)
        {
            _context = context;
        }

        // GET: api/Condiciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condicion>>> GetCondicions()
        {
            return await _context.Condicions.ToListAsync();
        }

        // GET: api/Condiciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condicion>> GetCondicion(byte id)
        {
            var condicion = await _context.Condicions.FindAsync(id);

            if (condicion == null)
            {
                return NotFound();
            }

            return condicion;
        }

        // PUT: api/Condiciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicion(byte id, Condicion condicion)
        {
            if (id != condicion.IdCondicion)
            {
                return BadRequest();
            }

            _context.Entry(condicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionExists(id))
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

        // POST: api/Condiciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condicion>> PostCondicion(Condicion condicion)
        {
            _context.Condicions.Add(condicion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondicion", new { id = condicion.IdCondicion }, condicion);
        }

        // DELETE: api/Condiciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondicion(byte id)
        {
            var condicion = await _context.Condicions.FindAsync(id);
            if (condicion == null)
            {
                return NotFound();
            }

            _context.Condicions.Remove(condicion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondicionExists(byte id)
        {
            return _context.Condicions.Any(e => e.IdCondicion == id);
        }
    }
}
