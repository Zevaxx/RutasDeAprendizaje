using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Trcoursesinroute
    {
        public int Courseid { get; set; }
        public int Routeid { get; set; }

        public virtual Tcourse Course { get; set; }
        public virtual Tlearningroute Route { get; set; }
    }
}
