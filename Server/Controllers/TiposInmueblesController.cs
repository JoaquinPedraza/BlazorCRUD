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
    public class TiposInmueblesController : ControllerBase
    {
        private readonly TrabajoFinalContext _context;

        public TiposInmueblesController(TrabajoFinalContext context)
        {
            _context = context;
        }

        // GET: api/TiposInmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInmueble>>> GetTipoInmuebles()
        {
            return await _context.TipoInmuebles.ToListAsync();
        }

        // GET: api/TiposInmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInmueble>> GetTipoInmueble(byte id)
        {
            var tipoInmueble = await _context.TipoInmuebles.FindAsync(id);

            if (tipoInmueble == null)
            {
                return NotFound();
            }

            return tipoInmueble;
        }

        // PUT: api/TiposInmuebles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInmueble(byte id, TipoInmueble tipoInmueble)
        {
            if (id != tipoInmueble.IdTipoInmueble)
            {
                return BadRequest();
            }

            _context.Entry(tipoInmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInmuebleExists(id))
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

        // POST: api/TiposInmuebles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoInmueble>> PostTipoInmueble(TipoInmueble tipoInmueble)
        {
            _context.TipoInmuebles.Add(tipoInmueble);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoInmueble", new { id = tipoInmueble.IdTipoInmueble }, tipoInmueble);
        }

        // DELETE: api/TiposInmuebles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInmueble(byte id)
        {
            var tipoInmueble = await _context.TipoInmuebles.FindAsync(id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }

            _context.TipoInmuebles.Remove(tipoInmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInmuebleExists(byte id)
        {
            return _context.TipoInmuebles.Any(e => e.IdTipoInmueble == id);
        }
    }
}
