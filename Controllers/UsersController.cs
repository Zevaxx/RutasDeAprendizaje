using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasDeAprendizaje.Models.DBModels;

namespace RutasDeAprendizaje.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly rutasdeaprendizajeContext _context;

    public UsersController(rutasdeaprendizajeContext context)
    {
      _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tuser>>> GetTusers()
    {
      return await _context.Tusers.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tuser>> GetTuser(int id)
    {
      var tuser = await _context.Tusers.FindAsync(id);

      if (tuser == null)
      {
        return NotFound();
      }

      return tuser;
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTuser(int id, Tuser tuser)
    {
      if (id != tuser.Userid)
      {
        return BadRequest();
      }

      _context.Entry(tuser).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TuserExists(id))
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

    // POST: api/Users
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Tuser>> PostTuser(Tuser tuser)
    {
      _context.Tusers.Add(tuser);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTuser", new { id = tuser.Userid }, tuser);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Tuser>> DeleteTuser(int id)
    {
      var tuser = await _context.Tusers.FindAsync(id);
      if (tuser == null)
      {
        return NotFound();
      }

      _context.Tusers.Remove(tuser);
      await _context.SaveChangesAsync();

      return tuser;
    }

    private bool TuserExists(int id)
    {
      return _context.Tusers.Any(e => e.Userid == id);
    }
  }
}
