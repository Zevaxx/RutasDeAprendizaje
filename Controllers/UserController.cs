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
using System.Dynamic;


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
    public async Task<ActionResult<Tuser>> GetUser(String id)
    {

      var dataReturn = await this.SerializerUser(id);

      return Ok(dataReturn);

      // var user = await userManager.FindByIdAsync(id);
      // var userRole = await userManager.GetRolesAsync(user);
      // if (userRole[0] == null)
      // {
      //   userRole.Add("user");
      // }
      // var dataReturn = new
      // {
      //   UserName = user.UserName,
      //   Email = user.Email,
      //   userRole = userRole
      // };
      // return Ok(dataReturn);

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
    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyUser([FromBody] ExpandoObject requestdata)
    {

      var data = ((IDictionary<string, object>)requestdata);

      if (data["id"] == null || data["description"] == null)
      {
        return BadRequest();
      }

      var user = await userManager.FindByIdAsync(data["id"].ToString());

      user.UserDescription = data["description"].ToString();
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {

      }
      var dataReturn = await this.SerializerUser(data["id"].ToString());

      return Ok(dataReturn);
    }

    // DELETE api/<UserController>/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }

    public async Task<dynamic> SerializerUser(String id)
    {


      var user = await userManager.FindByIdAsync(id);

      var GetUserRole = (from u in _context.Tusers
                         join thr in _context.UserRoles
                         on u.Id equals thr.UserId
                         join r in _context.Roles
                         on thr.RoleId equals r.Id
                         where u.Id == id
                         select new
                         {
                           r.Name,
                         }).ToList();


      var RoleArray = GetUserRole.Select(c => { return c.Name; }).ToList();

      var getRutasCreadas = (from lr in _context.Tlearningroutes
                             where lr.Id == id
                             select new
                             {
                               lr.Routeid,
                               lr.Routename,
                               lr.Routedescription
                             }).ToList();

      var dataReturn = new
      {
        userName = user.UserName,
        email = user.Email,
        userDescription = user.UserDescription,
        userRole = RoleArray,
        rutasCreadas = getRutasCreadas,
        // rutasSuscritas = user.Trlearningrouteshassuscribers,
        guid = user.Id
      };

      return dataReturn;
      // var user = (from u in _context.Tusers
      //             join thr in _context.UserRoles
      //             on u.Id equals thr.UserId
      //             join r in _context.Roles
      //             on thr.RoleId equals r.Id
      //             where u.Id == id
      //             select new
      //             {
      //               userName = u.UserName,
      //               role = r.Name,
      //               userdescription = u.UserDescription
      //             }).FirstOrDefault();

      // if (user == null)
      // {
      //   user = (from u in _context.Tusers
      //           where u.Id == id
      //           select new
      //           {
      //             userName = u.UserName,
      //             role = "user",
      //             userdescription = u.UserDescription
      //           }).FirstOrDefault();
      // }


    }

  }
}
