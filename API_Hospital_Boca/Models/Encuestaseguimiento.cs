using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Encuestaseguimiento
    {
        public string FkPaciente { get; set; }
        public int FkHospital { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public DateTime FechaVasectomia { get; set; }
        public string OrigenInfo { get; set; }
        public int FkConsejeria { get; set; }
        public bool Referido { get; set; }
        public int FkHospitalReferencia { get; set; }
        public int FkCalidad { get; set; }
        public bool Satisfaccion { get; set; }
        public string MotivoSatisfaccion { get; set; }
        public bool Complicacion { get; set; }
        public string MotivoComplicacion { get; set; }
        public int FkCalidadRelacion { get; set; }
        public string MotivoCalidad { get; set; }
        public DateTime FechaNegativo { get; set; }
        public string LugarEspermaconteo { get; set; }
        public bool Recomendacion { get; set; }
        public string MotivoRecomendacion { get; set; }
        public bool LugarVasectomia { get; set; }
        public string MotivoLugar { get; set; }
        public bool RecomendacionHospital { get; set; }
        public string CualRecomendacion { get; set; }

        public virtual Calidadservicio FkCalidadNavigation { get; set; }
        public virtual Calidadrelacion FkCalidadRelacionNavigation { get; set; }
        public virtual Personalconsejerium FkConsejeriaNavigation { get; set; }
        public virtual Hospitale FkHospitalNavigation { get; set; }
        public virtual Hospitale FkHospitalReferenciaNavigation { get; set; }
        public virtual Paciente FkPacienteNavigation { get; set; }
    }
}
