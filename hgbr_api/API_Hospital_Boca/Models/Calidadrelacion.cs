using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Calidadrelacion
    {
        public Calidadrelacion()
        {
            Encuestaseguimientos = new HashSet<Encuestaseguimiento>();
        }

        public int IdCalidadRelacion { get; set; }
        public string NombreCalidadRelacion { get; set; }

        public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; }
    }
}
