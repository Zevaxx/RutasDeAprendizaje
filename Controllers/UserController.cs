using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RutasDeAprendizaje.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RutasDeAprendizaje.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserManager<Tuser> userManager;
    private readonly RutasdeaprendizajeContext _context;

    public UserController(UserManager<Tuser> userManager, RutasdeaprendizajeContext context)
    {
      this.userManager = userManager;
      this._context = context;
    }

    //GET: api/<UserController>
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Tuser>>> GetTuser()
    //{
    //    return await _context.Tusers.ToListAsync();
    //}

    //GET api/<UserController>/5

    [HttpGet("{id}")]
    public ActionResult<Tuser> GetUser(String id)
    {

      var user = (from u in _context.Tusers
                  join thr in _context.UserRoles
                  on u.Id equals thr.UserId
                  join r in _context.Roles 
                  on thr.RoleId equals r.Id
                  where u.Id == id
                  select new
                  {
                    userName = u.UserName,
                    role = r.Name
                  }).FirstOrDefault();
      
            if (user == null)
            {
                user = (from u in _context.Tusers
                 where u.Id == id
                 select new
                 {
                     userName = u.UserName,
                     role = "user"
                 }).FirstOrDefault();
            }

      return Ok(user);

    }

    //POST api/<UserController>
    [HttpPost("upload", Name = "upload")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFile(
     IFormFile file,
     CancellationToken cancellationToken)
    {


      await WriteFile(file);


      return Ok();
    }

    /// 

    /// Method to check if file is excel file
    /// 
    /// 


    private async Task<bool> WriteFile(IFormFile file)
    {
      bool isSaveSuccess = false;
      string fileName;
      try
      {
        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.

        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

        if (!Directory.Exists(pathBuilt))
        {
          Directory.CreateDirectory(pathBuilt);
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
           fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
          await file.CopyToAsync(stream);
        }

        isSaveSuccess = true;
      }
      catch (Exception e)
      {

      }

      return isSaveSuccess;
    }

    // PUT api/<UserController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<UserController>/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
  }
}
