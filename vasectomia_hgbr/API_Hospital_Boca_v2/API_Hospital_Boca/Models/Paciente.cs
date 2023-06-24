using System;
using System.Collections.Generic;

#nullable disable

namespace API_Hospital_Boca.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Fichaidentificacions = new HashSet<Fichaidentificacion>();
            Historiaclinicas = new HashSet<Historiaclinica>();
        }

		public string NombreCompleto => $"{Nombre} {ApPaterno} {ApMaterno}";
        public int Edad()
        {
            var today = DateTime.Today;
            var age = today.Year - FechaNac.Year;
			if (FechaNac.Date > today.AddYears(-age))
                age--;

            return age;
		}

		public string NoExpediente { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime FechaNac { get; set; }
        public int? FkEstadoCivil { get; set; }
        public int? Ivs { get; set; }
        public int? FkEscolaridad { get; set; }
        public int? FkOcupacion { get; set; }
        public int? FkReligion { get; set; }
        public int? FkLugarReferencia { get; set; }
        public int? NumHijosVivos { get; set; }
        public int? EdadHijoMenor { get; set; }
        public string NombreEsposa { get; set; }
        public int? AosRelac { get; set; }
        public string CalleCasa { get; set; }
        public int? NumCasa { get; set; }
        public string ColCasa { get; set; }
        public string TelCasa { get; set; }
        public string CalleTrabajo { get; set; }
        public int? NumTrabajo { get; set; }
        public string ColTrabajo { get; set; }
        public string TelTrabajo { get; set; }

        public virtual Escolaridad FkEscolaridadNavigation { get; set; }
        public virtual Estadocivil FkEstadoCivilNavigation { get; set; }
        public virtual Lugarreferencium FkLugarReferenciaNavigation { get; set; }
        public virtual Ocupacion FkOcupacionNavigation { get; set; }
        public virtual Religion FkReligionNavigation { get; set; }
        public virtual Encuestaseguimiento Encuestaseguimiento { get; set; }
        public virtual ICollection<Fichaidentificacion> Fichaidentificacions { get; set; }
        public virtual ICollection<Historiaclinica> Historiaclinicas { get; set; }
    }
}
