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

            Tcourse nuevoCurso = new Tcourse();

            nuevoCurso.Comid = Int16.Parse((data["idComunidad"]).ToString());
            nuevoCurso.Coursename = data["nombreCurso"].ToString();
            nuevoCurso.Coursedescription = data["nombreDescripcion"].ToString();
            nuevoCurso.Coursetimelength = Int16.Parse((data["extensionCurso"]).ToString());

            _context.Tcourses.Add(nuevoCurso);

            _context.SaveChanges();

            return Ok(nuevoCurso);

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
    }
}
