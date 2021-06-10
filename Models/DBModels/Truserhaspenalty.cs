using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class Truserhaspenalty
  {
    public int Penalid { get; set; }
    public string Id { get; set; }

    public virtual Tpenalty Penal { get; set; }
    public virtual Tuser User { get; set; }
  }
}
