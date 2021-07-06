using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasDeAprendizaje.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace RutasDeAprendizaje.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
    private readonly RutasdeaprendizajeContext _context;

    public CoursesController(RutasdeaprendizajeContext context)
    {
      _context = context;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tcourse>>> GetTcourses()
    {
      return await _context.Tcourses.ToListAsync();
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tcourse>> GetTcourse(int id)
    {
      var tcourse = await _context.Tcourses.FindAsync(id);

      if (tcourse == null)
      {
        return NotFound();
      }

      return tcourse;
    }

    // PUT: api/Courses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTcourse(int id, Tcourse tcourse)
    {
      if (id != tcourse.Courseid)
      {
        return BadRequest();
      }

      _context.Entry(tcourse).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TcourseExists(id))
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

    // POST: api/Courses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

    [HttpPost]
    public ActionResult<dynamic> PostTcourse([FromBody] ExpandoObject requestdata)
    {
      var data = ((IDictionary<string, object>)requestdata);


      Tcommunity nuevaComunidad = new Tcommunity();
      nuevaComunidad.Comname = data["courseName"].ToString();
      nuevaComunidad.Id = data["userId"].ToString();
      _context.Tcommunities.Add(nuevaComunidad);
      _context.SaveChanges();

      Tcourse nuevoCurso = new Tcourse();
      nuevoCurso.Coursename = data["courseName"].ToString();
      nuevoCurso.Coursedescription = data["courseDescripcion"].ToString();
      nuevoCurso.Coursetimelength = Int16.Parse((data["courseLength"]).ToString());
      nuevoCurso.Comid = nuevaComunidad.Comid;
      _context.Tcourses.Add(nuevoCurso);
      _context.SaveChanges();

      nuevaComunidad.Courseid = nuevoCurso.Courseid;
      _context.SaveChanges();


      Trcoursesinroute newCursoEnRuta = new Trcoursesinroute();
      newCursoEnRuta.Courseid = nuevoCurso.Courseid;
      newCursoEnRuta.Routeid = Int16.Parse(data["routeId"].ToString());
      _context.Trcoursesinroutes.Add(newCursoEnRuta);
      _context.SaveChanges();

      var dataReturn = SerializerLearningCurso(nuevoCurso.Courseid);

      return Ok(dataReturn);

    }

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTcourse(int id)
    {
      var tcourse = await _context.Tcourses.FindAsync(id);
      if (tcourse == null)
      {
        return NotFound();
      }

      _context.Tcourses.Remove(tcourse);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TcourseExists(int id)
    {
      return _context.Tcourses.Any(e => e.Courseid == id);
    }

    public dynamic SerializerLearningCurso(int id)
    {

      var returnNuevoCurso = (from c in _context.Tcourses
                              where c.Courseid == id
                              select new
                              {
                                courseName = c.Coursename,
                                courseDescripcion = c.Coursedescription,
                                courseLength = c.Coursetimelength
                              }).FirstOrDefault();

      return returnNuevoCurso;
    }
  }
}
