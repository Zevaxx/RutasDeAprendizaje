using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class Tcommunity
  {
    public Tcommunity()
    {
      Tcourses = new HashSet<Tcourse>();
      Tlearningroutes = new HashSet<Tlearningroute>();
      Tposts = new HashSet<Tpost>();
    }

    public int Comid { get; set; }
    public string Id { get; set; }
    public int? Routeid { get; set; }
    public int? Courseid { get; set; }
    public string Comname { get; set; }

    public virtual Tcourse Course { get; set; }
    public virtual Tlearningroute Route { get; set; }
    public virtual Tuser User { get; set; }
    public virtual ICollection<Tcourse> Tcourses { get; set; }
    public virtual ICollection<Tlearningroute> Tlearningroutes { get; set; }
    public virtual ICollection<Tpost> Tposts { get; set; }
  }
}
