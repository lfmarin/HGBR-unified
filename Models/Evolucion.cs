using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Evolucion
    {
        public int? FkHistoria { get; set; }
        public string Complicaciones { get; set; }
        public bool? Espermaconteo { get; set; }
        public DateTime? Fecha1 { get; set; }
        public string Resultado1 { get; set; }
        public DateTime? Fecha2 { get; set; }
        public string Resultado2 { get; set; }

        public virtual Historiaclinica FkHistoriaNavigation { get; set; }
    }
}
