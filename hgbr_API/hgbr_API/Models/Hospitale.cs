using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Hospitale
{
    public int IdHospital { get; set; }

    public string? EntidadFederativa { get; set; }

    public string? JurSanitaria { get; set; }

    public string? UMedica { get; set; }

    public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; } = new List<Cartaconsentimiento>();

    public virtual ICollection<Encuestaseguimiento> EncuestaseguimientoFkHospitalNavigations { get; set; } = new List<Encuestaseguimiento>();

    public virtual ICollection<Encuestaseguimiento> EncuestaseguimientoFkHospitalReferenciaNavigations { get; set; } = new List<Encuestaseguimiento>();

    public virtual ICollection<Historiaclinica> Historiaclinicas { get; set; } = new List<Historiaclinica>();

    public virtual ICollection<Instruccionespost> Instruccionesposts { get; set; } = new List<Instruccionespost>();
}
