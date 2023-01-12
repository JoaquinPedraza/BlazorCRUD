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
    public class FormasPagoController : ControllerBase
    {
        private readonly TrabajoFinalContext _context;

        public FormasPagoController(TrabajoFinalContext context)
        {
            _context = context;
        }

        // GET: api/FormasPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPago>>> GetFormaPagos()
        {
            return await _context.FormaPagos.ToListAsync();
        }

        // GET: api/FormasPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> GetFormaPago(byte id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            return formaPago;
        }

        // PUT: api/FormasPago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormaPago(byte id, FormaPago formaPago)
        {
            if (id != formaPago.IdFormaPago)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
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

        // POST: api/FormasPago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormaPago>> PostFormaPago(FormaPago formaPago)
        {
            _context.FormaPagos.Add(formaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormaPago", new { id = formaPago.IdFormaPago }, formaPago);
        }

        // DELETE: api/FormasPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPago(byte id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPagos.Remove(formaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagoExists(byte id)
        {
            return _context.FormaPagos.Any(e => e.IdFormaPago == id);
        }
    }
}
