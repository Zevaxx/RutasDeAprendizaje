using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Trcoursehastest
    {
        public int Testid { get; set; }
        public int Courseid { get; set; }

        public virtual Tcourse Course { get; set; }
        public virtual Ttest Test { get; set; }
    }
}
