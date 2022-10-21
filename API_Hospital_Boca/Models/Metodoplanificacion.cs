using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Metodoplanificacion
    {
        public Metodoplanificacion()
        {
            Motivosolicituds = new HashSet<Motivosolicitud>();
        }

        public int IdMetodo { get; set; }
        public string NombreMetodo { get; set; }

        public virtual ICollection<Motivosolicitud> Motivosolicituds { get; set; }
    }
}
