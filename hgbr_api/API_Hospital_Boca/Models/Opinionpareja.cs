using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Opinionpareja
    {
        public Opinionpareja()
        {
            Motivosolicituds = new HashSet<Motivosolicitud>();
        }

        public int IdOpinion { get; set; }
        public string NombreOpinion { get; set; }

        public virtual ICollection<Motivosolicitud> Motivosolicituds { get; set; }
    }
}
