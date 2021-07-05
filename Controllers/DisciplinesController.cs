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
    public class DisciplinesController : ControllerBase
    {
        private readonly RutasdeaprendizajeContext _context;

        public DisciplinesController(RutasdeaprendizajeContext context)
        {
            _context = context;
        }

        // GET: api/Disciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tdiscipline>>> GetTdisciplines()
        {
            return await _context.Tdisciplines.ToListAsync();
        }

        // GET: api/Disciplines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tdiscipline>> GetTdiscipline(int id)
        {
            var tdiscipline = await _context.Tdisciplines.FindAsync(id);

            if (tdiscipline == null)
            {
                return NotFound();
            }

            return tdiscipline;
        }

        // PUT: api/Disciplines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTdiscipline(int id, Tdiscipline tdiscipline)
        {
            if (id != tdiscipline.Disciplineid)
            {
                return BadRequest();
            }

            _context.Entry(tdiscipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdisciplineExists(id))
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

        // POST: api/Disciplines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tdiscipline>> PostTdiscipline(Tdiscipline tdiscipline)
        {
            _context.Tdisciplines.Add(tdiscipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTdiscipline", new { id = tdiscipline.Disciplineid }, tdiscipline);
        }

        // DELETE: api/Disciplines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTdiscipline(int id)
        {
            var tdiscipline = await _context.Tdisciplines.FindAsync(id);
            if (tdiscipline == null)
            {
                return NotFound();
            }

            _context.Tdisciplines.Remove(tdiscipline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TdisciplineExists(int id)
        {
            return _context.Tdisciplines.Any(e => e.Disciplineid == id);
        }
    }
}
