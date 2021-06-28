using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RutasDeAprendizaje.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly RoleManager<IdentityRole> roleManager;

    public AdminController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    // GET: api/<AdminController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<AdminController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<AdminController>
    [HttpPost]
    public async Task<ActionResult<IdentityRole>> Create(IdentityRole role)
    {
      var roleExist = await roleManager.RoleExistsAsync(role.Name);
      if (!roleExist)
      {
        var result = await roleManager.CreateAsync(new IdentityRole(role.Name));
        return Ok(result);
      }
      else
      {
        return BadRequest(new { message = "Role Used or password is incorrect" });
      }


    }

    //public async Task<ActionResult<Tcourse>> PostTcourse(Tcourse tcourse)
    //{
    //    _context.Tcourses.Add(tcourse);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetTcourse", new { id = tcourse.Courseid }, tcourse);
    //}

    // PUT api/<AdminController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<AdminController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
