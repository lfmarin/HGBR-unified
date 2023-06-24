using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Estudioanatomo
    {
        public int FkHistoria { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Clave { get; set; }
        public string Resultado { get; set; }

        public virtual Historiaclinica FkHistoriaNavigation { get; set; }
    }
}
