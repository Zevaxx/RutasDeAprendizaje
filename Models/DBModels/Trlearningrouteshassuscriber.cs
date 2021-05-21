using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Trlearningrouteshassuscriber
    {
        public int Routeid { get; set; }
        public int Userid { get; set; }

        public virtual Tlearningroute Route { get; set; }
        public virtual Tuser User { get; set; }
    }
}
