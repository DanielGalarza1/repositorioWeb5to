using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioCoreDelitos2.Models;

namespace ServicioCoreDelitos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelitosController : ControllerBase
    {
        private readonly DelitosContext _context;

        public DelitosController(DelitosContext context)
        {
            _context = context;
        }

        // GET: api/DelitosEcuadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DelitosEcuador>>> GetDelitosEcuadors()
        {
          if (_context.DelitosEcuadors == null)
          {
              return NotFound();
          }
            return await _context.DelitosEcuadors.ToListAsync();
        }

        // GET: api/DelitosEcuadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DelitosEcuador>> GetDelitosEcuador(int id)
        {
          if (_context.DelitosEcuadors == null)
          {
              return NotFound();
          }
            var delitosEcuador = await _context.DelitosEcuadors.FindAsync(id);

            if (delitosEcuador == null)
            {
                return NotFound();
            }

            return delitosEcuador;
        }

        // PUT: api/DelitosEcuadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelitosEcuador(int id, DelitosEcuador delitosEcuador)
        {
            if (id != delitosEcuador.Id)
            {
                return BadRequest();
            }

            _context.Entry(delitosEcuador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DelitosEcuadorExists(id))
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

        // POST: api/DelitosEcuadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DelitosEcuador>> PostDelitosEcuador(DelitosEcuador delitosEcuador)
        {
          if (_context.DelitosEcuadors == null)
          {
              return Problem("Entity set 'DelitosContext.DelitosEcuadors'  is null.");
          }
            _context.DelitosEcuadors.Add(delitosEcuador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DelitosEcuadorExists(delitosEcuador.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDelitosEcuador", new { id = delitosEcuador.Id }, delitosEcuador);
        }

        // DELETE: api/DelitosEcuadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelitosEcuador(int id)
        {
            if (_context.DelitosEcuadors == null)
            {
                return NotFound();
            }
            var delitosEcuador = await _context.DelitosEcuadors.FindAsync(id);
            if (delitosEcuador == null)
            {
                return NotFound();
            }

            _context.DelitosEcuadors.Remove(delitosEcuador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DelitosEcuadorExists(int id)
        {
            return (_context.DelitosEcuadors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
