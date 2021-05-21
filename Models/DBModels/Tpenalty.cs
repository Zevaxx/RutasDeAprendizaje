using System;
using System.Collections.Generic;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
    public partial class Tpenalty
    {
        public Tpenalty()
        {
            Truserhaspenalties = new HashSet<Truserhaspenalty>();
        }

        public int Penalid { get; set; }
        public string Penalname { get; set; }
        public string Testpenaldescription { get; set; }

        public virtual ICollection<Truserhaspenalty> Truserhaspenalties { get; set; }
    }
}
