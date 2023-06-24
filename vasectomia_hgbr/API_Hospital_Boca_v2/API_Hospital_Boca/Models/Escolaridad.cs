using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Escolaridad
    {
        public Escolaridad()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEscolaridad { get; set; }
        public string NombreEscolaridad { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
