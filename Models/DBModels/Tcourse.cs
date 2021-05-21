using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Tcourse
    {
        public Tcourse()
        {
            Tcommunities = new HashSet<Tcommunity>();
            Trcoursehastests = new HashSet<Trcoursehastest>();
            Trcoursesinroutes = new HashSet<Trcoursesinroute>();
        }

        public int Courseid { get; set; }
        public int Comid { get; set; }
        public string Coursename { get; set; }
        public int Coursetimelength { get; set; }
        public int? Coursescore { get; set; }

        public virtual Tcommunity Com { get; set; }
        public virtual ICollection<Tcommunity> Tcommunities { get; set; }
        public virtual ICollection<Trcoursehastest> Trcoursehastests { get; set; }
        public virtual ICollection<Trcoursesinroute> Trcoursesinroutes { get; set; }
    }
}
