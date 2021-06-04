using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class Trusershasdiscipline
  {
    public string Id { get; set; }
    public int Disciplineid { get; set; }

    public virtual Tdiscipline Discipline { get; set; }
    public virtual Tuser User { get; set; }
  }
}
