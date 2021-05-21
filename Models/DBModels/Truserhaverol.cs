using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Truserhaverol
    {
        public int Rolid { get; set; }
        public int Userid { get; set; }

        public virtual Trole Rol { get; set; }
        public virtual Tuser User { get; set; }
    }
}
