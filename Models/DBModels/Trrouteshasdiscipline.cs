using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Trrouteshasdiscipline
    {
        public int Routeid { get; set; }
        public int Disciplineid { get; set; }

        public virtual Tdiscipline Discipline { get; set; }
        public virtual Tlearningroute Route { get; set; }
    }
}
