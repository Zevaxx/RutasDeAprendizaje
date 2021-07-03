using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class Tuser : IdentityUser
  {
    public Tuser()
    {
      Tcommunities = new HashSet<Tcommunity>();
      Tlearningroutes = new HashSet<Tlearningroute>();
      Tposts = new HashSet<Tpost>();
      Trlearningrouteshassuscribers = new HashSet<Trlearningrouteshassuscriber>();
      Truserhaspenalties = new HashSet<Truserhaspenalty>();

      Trusershasdisciplines = new HashSet<Trusershasdiscipline>();
    }

    //public int Userid { get; set; }
    //public string Username { get; set; }
    //public string Userpassword { get; set; }
    public string UserDescription { get; set; }
    public string Usercomunitypenalties { get; set; }

    public virtual ICollection<Tcommunity> Tcommunities { get; set; }
    public virtual ICollection<Tlearningroute> Tlearningroutes { get; set; }
    public virtual ICollection<Tpost> Tposts { get; set; }
    public virtual ICollection<Trlearningrouteshassuscriber> Trlearningrouteshassuscribers { get; set; }
    public virtual ICollection<Truserhaspenalty> Truserhaspenalties { get; set; }
    public virtual ICollection<Trusershasdiscipline> Trusershasdisciplines { get; set; }
  }
}
