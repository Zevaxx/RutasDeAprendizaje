using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Tdiscipline
    {
        public Tdiscipline()
        {
            Trrouteshasdisciplines = new HashSet<Trrouteshasdiscipline>();
            Trusershasdisciplines = new HashSet<Trusershasdiscipline>();
        }

        public int Disciplineid { get; set; }
        public string Disciplinename { get; set; }

        public virtual ICollection<Trrouteshasdiscipline> Trrouteshasdisciplines { get; set; }
        public virtual ICollection<Trusershasdiscipline> Trusershasdisciplines { get; set; }
    }
}
