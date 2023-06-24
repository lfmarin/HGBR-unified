using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Estadocivil
    {
        public Estadocivil()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEstadoCivil { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
