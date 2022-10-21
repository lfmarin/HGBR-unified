using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Hospitale
    {
        public Hospitale()
        {
            Cartaconsentimientos = new HashSet<Cartaconsentimiento>();
            EncuestaseguimientoFkHospitalNavigations = new HashSet<Encuestaseguimiento>();
            EncuestaseguimientoFkHospitalReferenciaNavigations = new HashSet<Encuestaseguimiento>();
            Historiaclinicas = new HashSet<Historiaclinica>();
            Instruccionesposts = new HashSet<Instruccionespost>();
        }

        public int IdHospital { get; set; }
        public string EntidadFederativa { get; set; }
        public string JurSanitaria { get; set; }
        public string UMedica { get; set; }

        public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; }
        public virtual ICollection<Encuestaseguimiento> EncuestaseguimientoFkHospitalNavigations { get; set; }
        public virtual ICollection<Encuestaseguimiento> EncuestaseguimientoFkHospitalReferenciaNavigations { get; set; }
        public virtual ICollection<Historiaclinica> Historiaclinicas { get; set; }
        public virtual ICollection<Instruccionespost> Instruccionesposts { get; set; }
    }
}
