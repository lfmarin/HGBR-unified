using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Personalconsejerium
    {
        public Personalconsejerium()
        {
            Cartaconsentimientos = new HashSet<Cartaconsentimiento>();
            Encuestaseguimientos = new HashSet<Encuestaseguimiento>();
        }

        public string NombreCompleto => $"{Nombre} {ApMaterno} {ApPaterno}";

        public int IdPersonal { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }

        public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; }
        public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; }
    }
}
