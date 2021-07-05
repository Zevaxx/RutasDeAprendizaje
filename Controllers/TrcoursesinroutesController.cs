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
    public class TrcoursesinroutesController : ControllerBase
    {
        private readonly RutasdeaprendizajeContext _context;

        public TrcoursesinroutesController(RutasdeaprendizajeContext context)
        {
            _context = context;
        }

        // GET: api/Trcoursesinroutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trcoursesinroute>>> GetTrcoursesinroutes()
        {
            return await _context.Trcoursesinroutes.ToListAsync();
        }

        // GET: api/Trcoursesinroutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trcoursesinroute>> GetTrcoursesinroute(int id)
        {
            var trcoursesinroute = await _context.Trcoursesinroutes.FindAsync(id);

            if (trcoursesinroute == null)
            {
                return NotFound();
            }

            return trcoursesinroute;
        }

        // PUT: api/Trcoursesinroutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrcoursesinroute(int id, Trcoursesinroute trcoursesinroute)
        {
            if (id != trcoursesinroute.Courseid)
            {
                return BadRequest();
            }

            _context.Entry(trcoursesinroute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrcoursesinrouteExists(id))
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

        // POST: api/Trcoursesinroutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trcoursesinroute>> PostTrcoursesinroute(Trcoursesinroute trcoursesinroute)
        {
            _context.Trcoursesinroutes.Add(trcoursesinroute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrcoursesinrouteExists(trcoursesinroute.Courseid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrcoursesinroute", new { id = trcoursesinroute.Courseid }, trcoursesinroute);
        }

        // DELETE: api/Trcoursesinroutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrcoursesinroute(int id)
        {
            var trcoursesinroute = await _context.Trcoursesinroutes.FindAsync(id);
            if (trcoursesinroute == null)
            {
                return NotFound();
            }

            _context.Trcoursesinroutes.Remove(trcoursesinroute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrcoursesinrouteExists(int id)
        {
            return _context.Trcoursesinroutes.Any(e => e.Courseid == id);
        }
    }
}
