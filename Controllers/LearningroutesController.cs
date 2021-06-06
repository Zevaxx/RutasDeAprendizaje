using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasDeAprendizaje.Models.DBModels;
using Microsoft.AspNetCore.Authorization;

namespace RutasDeAprendizaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningroutesController : ControllerBase
    {
        private readonly RutasdeaprendizajeContext _context;

        public LearningroutesController(RutasdeaprendizajeContext context)
        {
            _context = context;
        }

        // GET: api/Learningroutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tlearningroute>>> GetTlearningroutes()
        {
            return await _context.Tlearningroutes.ToListAsync();
        }

        // GET: api/Learningroutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tlearningroute>> GetTlearningroute(int id)
        {
            var tlearningroute = await _context.Tlearningroutes.FindAsync(id);

            if (tlearningroute == null)
            {
                return NotFound();
            }

            return tlearningroute;
        }

        // PUT: api/Learningroutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTlearningroute(int id, Tlearningroute tlearningroute)
        {
            if (id != tlearningroute.Routeid)
            {
                return BadRequest();
            }

            _context.Entry(tlearningroute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TlearningrouteExists(id))
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

        // POST: api/Learningroutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tlearningroute>> PostTlearningroute(Tlearningroute tlearningroute)
        {
            _context.Tlearningroutes.Add(tlearningroute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTlearningroute", new { id = tlearningroute.Routeid }, tlearningroute);
        }

        // DELETE: api/Learningroutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTlearningroute(int id)
        {
            var tlearningroute = await _context.Tlearningroutes.FindAsync(id);
            if (tlearningroute == null)
            {
                return NotFound();
            }

            _context.Tlearningroutes.Remove(tlearningroute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TlearningrouteExists(int id)
        {
            return _context.Tlearningroutes.Any(e => e.Routeid == id);
        }
    }
}
