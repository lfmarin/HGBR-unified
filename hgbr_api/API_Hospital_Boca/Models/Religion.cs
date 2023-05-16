using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Religion
    {
        public Religion()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdReligion { get; set; }
        public string NombreReligion { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
