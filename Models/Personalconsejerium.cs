using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Personalconsejerium
    {
        public int IdPersonal { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
    }
}
