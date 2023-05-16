using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Fichaidentificacion
    {
        public int IdFicha { get; set; }
        public string FkPaciente { get; set; }
        public string Servicio { get; set; }
        public string Diagnostico { get; set; }

        public virtual Paciente FkPacienteNavigation { get; set; }
        public virtual Cartaconsentimiento Cartaconsentimiento { get; set; }
        public virtual Instruccionespost Instruccionespost { get; set; }
        public virtual Notamedica Notamedica { get; set; }
        public virtual Solicitudexamene Solicitudexamene { get; set; }
    }
}
