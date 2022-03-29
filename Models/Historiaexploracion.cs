using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Historiaexploracion
    {
        public int? FkHistoria { get; set; }
        public string AntFamiliares { get; set; }
        public string AntPersonalesNoPat { get; set; }
        public string AntPersonalesPat { get; set; }
        public string Ta { get; set; }
        public string Peso { get; set; }
        public string Talla { get; set; }
        public string Fc { get; set; }
        public string Fr { get; set; }
        public string Tem { get; set; }
        public string ExpOrganos { get; set; }
        public string TipoPaciente { get; set; }

        public virtual Historiaclinica FkHistoriaNavigation { get; set; }
    }
}
