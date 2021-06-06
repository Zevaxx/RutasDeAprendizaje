using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class Tlearningroute
  {
    public Tlearningroute()
    {
      Tcommunities = new HashSet<Tcommunity>();
      Trcoursesinroutes = new HashSet<Trcoursesinroute>();
      Trlearningrouteshassuscribers = new HashSet<Trlearningrouteshassuscriber>();
      Trrouteshasdisciplines = new HashSet<Trrouteshasdiscipline>();
    }

    public int Routeid { get; set; }
    public string Id { get; set; }
    public int Comid { get; set; }
    public string Routename { get; set; }
    public string Routedescription { get; set; }
    public int Routedificultlevel { get; set; }
    public string Routediscipline { get; set; }
    public int? Routescore { get; set; }
    public int? Routefollowers { get; set; }

    public virtual Tcommunity Com { get; set; }
    public virtual Tuser User { get; set; }
    public virtual ICollection<Tcommunity> Tcommunities { get; set; }
    public virtual ICollection<Trcoursesinroute> Trcoursesinroutes { get; set; }
    public virtual ICollection<Trlearningrouteshassuscriber> Trlearningrouteshassuscribers { get; set; }
    public virtual ICollection<Trrouteshasdiscipline> Trrouteshasdisciplines { get; set; }
  }
}
