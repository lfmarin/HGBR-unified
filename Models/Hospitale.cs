using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Hospitale
    {
        public Hospitale()
        {
            Historiaclinicas = new HashSet<Historiaclinica>();
        }

        public int IdHospital { get; set; }
        public string EntidadFederativa { get; set; }
        public string JurSanitaria { get; set; }
        public string UMedica { get; set; }

        public virtual ICollection<Historiaclinica> Historiaclinicas { get; set; }
    }
}
