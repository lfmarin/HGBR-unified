using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Doctore
    {
        public Doctore()
        {
            Cartaconsentimientos = new HashSet<Cartaconsentimiento>();
            Instruccionesposts = new HashSet<Instruccionespost>();
            Notamedicas = new HashSet<Notamedica>();
            Procquirurgicos = new HashSet<Procquirurgico>();
            Solicitudexamenes = new HashSet<Solicitudexamene>();
        }

        public int IdDoctor { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }

        public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; }
        public virtual ICollection<Instruccionespost> Instruccionesposts { get; set; }
        public virtual ICollection<Notamedica> Notamedicas { get; set; }
        public virtual ICollection<Procquirurgico> Procquirurgicos { get; set; }
        public virtual ICollection<Solicitudexamene> Solicitudexamenes { get; set; }
    }
}
