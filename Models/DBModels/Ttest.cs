using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Ttest
    {
        public Ttest()
        {
            Trcoursehastests = new HashSet<Trcoursehastest>();
        }

        public int Testid { get; set; }
        public string Testname { get; set; }
        public string Testpenaldescription { get; set; }
        public int? Testdifficultylevel { get; set; }

        public virtual ICollection<Trcoursehastest> Trcoursehastests { get; set; }
    }
}
