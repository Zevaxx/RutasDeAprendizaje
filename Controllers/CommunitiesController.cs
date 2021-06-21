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
    public class CommunitiesController : ControllerBase
    {
        private readonly RutasdeaprendizajeContext _context;

        public CommunitiesController(RutasdeaprendizajeContext context)
        {
            _context = context;
        }

        // GET: api/Communities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcommunity>>> GetTcommunities()
        {
            return await _context.Tcommunities.ToListAsync();
        }

        // GET: api/Communities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tcommunity>> GetTcommunity(int id)
        {
            var tcommunity = await _context.Tcommunities.FindAsync(id);

            if (tcommunity == null)
            {
                return NotFound();
            }

            return tcommunity;
        }

        // PUT: api/Communities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcommunity(int id, Tcommunity tcommunity)
        {
            if (id != tcommunity.Comid)
            {
                return BadRequest();
            }

            _context.Entry(tcommunity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcommunityExists(id))
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

        // POST: api/Communities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tcommunity>> PostTcommunity(Tcommunity tcommunity)
        {
            _context.Tcommunities.Add(tcommunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTcommunity", new { id = tcommunity.Comid }, tcommunity);
        }

        // DELETE: api/Communities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTcommunity(int id)
        {
            var tcommunity = await _context.Tcommunities.FindAsync(id);
            if (tcommunity == null)
            {
                return NotFound();
            }

            _context.Tcommunities.Remove(tcommunity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TcommunityExists(int id)
        {
            return _context.Tcommunities.Any(e => e.Comid == id);
        }
    }
}
