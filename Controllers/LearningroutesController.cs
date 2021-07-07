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
  [Authorize]
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
    [AllowAnonymous]
    [HttpGet]
    public ActionResult<dynamic> GetTlearningroutes( int page = 1)
    {
      int elementosMostrar = 2;
      decimal totalElementos = _context.Tlearningroutes.Count();
      decimal totalPaginas = Math.Ceiling(totalElementos/ elementosMostrar);
      int previa = page - 1;
      int next = page + 1;

      int salto = (page - 1) * elementosMostrar;
      var learningrute = (from lr in _context.Tlearningroutes
                          select new {
                            routeId = lr.Routeid,
                            routeName = lr.Routename,
                            routeDescription = lr.Routedescription
                          })
                          .OrderBy(x=> x.routeId)
                          .Skip(salto)
                          .Take(elementosMostrar)
                          .ToList();
        
      var pagination = new {  totalcount = totalElementos,
                              page = page,
                              lastPage = totalPaginas,
                              nextPage = next ,
                              prevPage = previa
                              };  
      var dataToReturn = new {
        paginations = pagination,
        learningrutes = learningrute
      };                   

      return Ok(dataToReturn) ;
    }

    // GET: api/Learningroutes/5
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Tlearningroute>> GetTlearningroute(int id)
    {
      var tlearningroute = await _context.Tlearningroutes.FindAsync(id);

      if (tlearningroute == null)
      {
        return NotFound();
      }


      var routeToReturn = SerializerLearningRoute(id);
      return Ok(routeToReturn);
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
    public ActionResult PostTlearningroute([FromBody] ExpandoObject requestdata)
    {

      var data = ((IDictionary<string, object>)requestdata);

      if (data["userId"].ToString() == null || data["lrName"].ToString() == null)
      {
        return BadRequest("faltan usuario o nombre de la ruta");
      }

      // se crea primero la comunidad para observar el id de la comunidad
      Tcommunity nuevaComunidad = new Tcommunity();

      nuevaComunidad.Comname = data["lrName"].ToString();
      nuevaComunidad.Id = data["userId"].ToString();
      _context.Tcommunities.Add(nuevaComunidad);
      _context.SaveChanges();

      // creación de la ruta de aprendizaje

      Tlearningroute nuevaLR = new Tlearningroute();
      nuevaLR.Comid = nuevaComunidad.Comid;
      nuevaLR.Id = data["userId"].ToString();
      nuevaLR.Routename = data["lrName"].ToString();
      nuevaLR.Routedescription = data["lrDescription"].ToString();
      nuevaLR.Routedificultlevel = Int16.Parse((data["lrDificulty"]).ToString());
      //nuevaLR.Routediscipline = data["lrDiscipline"].ToString();
      _context.Tlearningroutes.Add(nuevaLR);
      _context.SaveChanges();
      nuevaComunidad.Routeid = nuevaLR.Routeid;
      _context.SaveChanges();

      // verificar que la disciplina existe
      var getDisciplineName = (from d in _context.Tdisciplines
                               where d.Disciplinename == data["lrDiscipline"].ToString()
                               select d.Disciplinename).FirstOrDefault();

      // si no existe la disciuplina se crea
      if (getDisciplineName == null)
      {
        Tdiscipline nuevaDisciplina = new Tdiscipline();
        nuevaDisciplina.Disciplinename = data["lrDiscipline"].ToString();
        _context.Tdisciplines.Add(nuevaDisciplina);
        _context.SaveChanges();

        nuevaLR.Routediscipline = nuevaDisciplina.Disciplineid.ToString();
        _context.SaveChanges();

        Trrouteshasdiscipline rutaTieneDisciplina = new Trrouteshasdiscipline();
        rutaTieneDisciplina.Disciplineid = nuevaDisciplina.Disciplineid;
        rutaTieneDisciplina.Routeid = nuevaLR.Routeid;
        _context.Trrouteshasdisciplines.Add(rutaTieneDisciplina);
        _context.SaveChanges();
      }
      // si existe la trae para asociarla a la ruta
      else
      {
        var nuevaDisciplina = (from d in _context.Tdisciplines
                               where d.Disciplinename == data["lrDiscipline"].ToString()
                               select d).FirstOrDefault();
        Trrouteshasdiscipline rutaTieneDisciplina = new Trrouteshasdiscipline();

        nuevaLR.Routediscipline = nuevaDisciplina.Disciplineid.ToString();
        _context.SaveChanges();
        rutaTieneDisciplina.Disciplineid = nuevaDisciplina.Disciplineid;
        _context.SaveChanges();

        rutaTieneDisciplina.Routeid = nuevaLR.Routeid;
        _context.Trrouteshasdisciplines.Add(rutaTieneDisciplina);
        _context.SaveChanges();
      }


      // serializado
      var returnNuevaRuta = SerializerLearningRoute(nuevaLR.Routeid);

      // devolver ruta creada
      return Ok(returnNuevaRuta);
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

      var comunitytoDelete = _context.Tcommunities.Where(c => c.Routeid == id).FirstOrDefault();

      comunitytoDelete.Routeid = null;
      await _context.SaveChangesAsync();

      var RuteHasDiscipline = _context.Trrouteshasdisciplines.Where(c => c.Routeid == id).ToList();
      RuteHasDiscipline.ForEach(Rute =>
     _context.Trrouteshasdisciplines.Remove(Rute)
      );
      await _context.SaveChangesAsync();

      _context.Tlearningroutes.Remove(tlearningroute);
      await _context.SaveChangesAsync();

      _context.Tcommunities.Remove(comunitytoDelete);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TlearningrouteExists(int id)
    {
      return _context.Tlearningroutes.Any(e => e.Routeid == id);
    }

    // GET: api/Learningroutes/mis-rutas
    [HttpGet("mis-rutas/{userId}")]
    public IActionResult GetMyRoutes(string userId)
    {


      var misRutas = (from lr in _context.Tlearningroutes
                      where lr.Id == userId
                      join rhd in _context.Trrouteshasdisciplines
                      on lr.Routeid equals rhd.Routeid
                      join d in _context.Tdisciplines
                      on rhd.Disciplineid equals d.Disciplineid
                      select new
                      {
                        routeId = lr.Routeid,
                        routeName = lr.Routename,
                        routeDescription = lr.Routedescription,
                        routeDifficulty = lr.Routedificultlevel,
                        routeDiscripline = d.Disciplinename,
                        routefollowers = lr.Routefollowers

                      }).ToList();

      return Ok(misRutas);
    }
    public dynamic SerializerLearningRoute(int id)
    {

      

      var cursosInRuta = (from lr in _context.Tlearningroutes
                          join cir in _context.Trcoursesinroutes
                          on lr.Routeid equals cir.Routeid
                          join c in _context.Tcourses
                          on cir.Courseid equals c.Courseid
                          where lr.Routeid == id
                          select new
                          {
                            courseId = c.Courseid,
                            courseName = c.Coursename,
                            courseDescripcion = c.Coursedescription,
                            courseLength = c.Coursetimelength,
                          }).ToList();

      var returnNuevaRuta = (from lr in _context.Tlearningroutes
                             join rhd in _context.Trrouteshasdisciplines
                             on lr.Routeid equals rhd.Routeid
                             join d in _context.Tdisciplines
                             on rhd.Disciplineid equals d.Disciplineid
                             where lr.Routeid == id
                             select new
                             {
                               lrId = lr.Routeid,
                               lrName = lr.Routename,
                               userId = lr.Id,
                               lrDescrition = lr.Routedescription,
                               lrDificulty = lr.Routedificultlevel,
                               lrDiscipline = d.Disciplinename,
                               courses = cursosInRuta
                             }).FirstOrDefault();

      return returnNuevaRuta;
    }

  }
}
