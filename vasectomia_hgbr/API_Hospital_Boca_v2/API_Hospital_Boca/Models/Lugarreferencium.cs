using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Lugarreferencium
    {
        public Lugarreferencium()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdLugar { get; set; }
        public string NombreLugar { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
