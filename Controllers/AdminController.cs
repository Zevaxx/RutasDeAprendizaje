using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RutasDeAprendizaje.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RutasDeAprendizaje.Controllers
{
    //[Authorize]
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    
    
    [ApiController]
    
    public class AdminController : ControllerBase
  {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Tuser> userManager;
        private readonly RutasdeaprendizajeContext _context;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<Tuser> userManager, RutasdeaprendizajeContext _context)
    {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._context = _context;
    }

    // GET: api/<AdminController>
    // [HttpGet]
    // public IEnumerable<string> Get()
    // {
    //   return new string[] { "value1", "value2" };
    // }

    // GET: api/<AdminController>
    [HttpGet("roles")]
    public ActionResult<IEnumerable<IdentityRole>> Getroles()
    {
      return  roleManager.Roles.ToList();
    }

    // GET api/<AdminController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<AdminController>
    [HttpPost("create-role")]
    public async Task<ActionResult<IdentityRole>> Createrole(IdentityRole role )
    {
            if (role.Name == null || role.Name == "")
                return BadRequest("Invalid data.");

            var roleExist = await roleManager.RoleExistsAsync(role.Name);
      if (!roleExist)
      {
        await roleManager.CreateAsync(new IdentityRole(role.Name));
        var result = await roleManager.FindByNameAsync(role.Name);
        return Ok(result);
      }
      else
      {
        return BadRequest(new { message = "Role Used or password is incorrect" });
      }

    }

        // POST api/<AdminController>
        [HttpPost("give-role")]
        public async Task<ActionResult<IdentityRole>> Giverole([FromBody] ExpandoObject requestdata)
        {

            var data = ((IDictionary<string, object>)requestdata);

            if (data["role"] == null || data["userid"] == null)
                return BadRequest("Invalid data.");

            var roleExist = await roleManager.RoleExistsAsync(data["role"].ToString());
            if (roleExist)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(data["userid"].ToString());
                    await userManager.AddToRoleAsync(user, data["role"].ToString());
                    var result = await roleManager.FindByNameAsync(data["role"].ToString());
                    return Ok(new { message = "role given successfully " });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return NotFound(new { message = "role don't exist" });
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
