using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Personalconsejerium
{
    public int IdPersonal { get; set; }

    public string? Nombre { get; set; }

    public string? ApPaterno { get; set; }

    public string? ApMaterno { get; set; }

    public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; } = new List<Cartaconsentimiento>();

    public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; } = new List<Encuestaseguimiento>();
}
