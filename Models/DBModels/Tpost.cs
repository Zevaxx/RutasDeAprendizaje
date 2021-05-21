using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Tpost
    {
        public int Postid { get; set; }
        public int Comid { get; set; }
        public int Userid { get; set; }
        public string Postcontent { get; set; }
        public DateTime? Postdate { get; set; }

        public virtual Tcommunity Com { get; set; }
        public virtual Tuser User { get; set; }
    }
}
