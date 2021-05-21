using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Trole
    {
        public Trole()
        {
            Truserhaverols = new HashSet<Truserhaverol>();
        }

        public int Rolid { get; set; }
        public string Rolname { get; set; }
        public string Roldetail { get; set; }

        public virtual ICollection<Truserhaverol> Truserhaverols { get; set; }
    }
}
