using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Ocupacion
    {
        public Ocupacion()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdOcupacion { get; set; }
        public string NombreOcupacion { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
