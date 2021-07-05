using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasDeAprendizaje.Models.DBModels;

namespace RutasDeAprendizaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrrouteshasdisciplinesController : ControllerBase
    {
        private readonly RutasdeaprendizajeContext _context;

        public TrrouteshasdisciplinesController(RutasdeaprendizajeContext context)
        {
            _context = context;
        }

        // GET: api/Trrouteshasdisciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trrouteshasdiscipline>>> GetTrrouteshasdisciplines()
        {
            return await _context.Trrouteshasdisciplines.ToListAsync();
        }

        // GET: api/Trrouteshasdisciplines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trrouteshasdiscipline>> GetTrrouteshasdiscipline(int id)
        {
            var trrouteshasdiscipline = await _context.Trrouteshasdisciplines.FindAsync(id);

            if (trrouteshasdiscipline == null)
            {
                return NotFound();
            }

            return trrouteshasdiscipline;
        }

        // PUT: api/Trrouteshasdisciplines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrrouteshasdiscipline(int id, Trrouteshasdiscipline trrouteshasdiscipline)
        {
            if (id != trrouteshasdiscipline.Routeid)
            {
                return BadRequest();
            }

            _context.Entry(trrouteshasdiscipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrrouteshasdisciplineExists(id))
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

        // POST: api/Trrouteshasdisciplines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trrouteshasdiscipline>> PostTrrouteshasdiscipline(Trrouteshasdiscipline trrouteshasdiscipline)
        {
            _context.Trrouteshasdisciplines.Add(trrouteshasdiscipline);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrrouteshasdisciplineExists(trrouteshasdiscipline.Routeid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrrouteshasdiscipline", new { id = trrouteshasdiscipline.Routeid }, trrouteshasdiscipline);
        }

        // DELETE: api/Trrouteshasdisciplines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrrouteshasdiscipline(int id)
        {
            var trrouteshasdiscipline = await _context.Trrouteshasdisciplines.FindAsync(id);
            if (trrouteshasdiscipline == null)
            {
                return NotFound();
            }

            _context.Trrouteshasdisciplines.Remove(trrouteshasdiscipline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrrouteshasdisciplineExists(int id)
        {
            return _context.Trrouteshasdisciplines.Any(e => e.Routeid == id);
        }
    }
}
