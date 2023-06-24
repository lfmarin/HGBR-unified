using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Calidadservicio
    {
        public Calidadservicio()
        {
            Encuestaseguimientos = new HashSet<Encuestaseguimiento>();
        }

        public int IdCalidad { get; set; }
        public string NombreCalidad { get; set; }

        public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; }
    }
}
