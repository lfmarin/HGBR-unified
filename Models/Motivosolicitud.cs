using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Motivosolicitud
    {
        public int? FkHistoria { get; set; }
        public string CausaNoHijos { get; set; }
        public int? FkOpinion { get; set; }
        public int? FkMetodoPlanificacion { get; set; }

        public virtual Historiaclinica FkHistoriaNavigation { get; set; }
        public virtual Metodoplanificacion FkMetodoPlanificacionNavigation { get; set; }
        public virtual Opinionpareja FkOpinionNavigation { get; set; }
    }
}
