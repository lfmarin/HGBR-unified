using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Procquirurgico
    {
        public int FkHistoria { get; set; }
        public DateTime FechaCirugia { get; set; }
        public int FkDoctor { get; set; }
        public string NotaQuirurgica { get; set; }
        public string Patologia { get; set; }

        public virtual Doctore FkDoctorNavigation { get; set; }
        public virtual Historiaclinica FkHistoriaNavigation { get; set; }
    }
}
