using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Doctore
{
    public int IdDoctor { get; set; }

    public string? Nombre { get; set; }

    public string? ApPaterno { get; set; }

    public string? ApMaterno { get; set; }

    public virtual ICollection<Cartaconsentimiento> Cartaconsentimientos { get; set; } = new List<Cartaconsentimiento>();

    public virtual ICollection<Instruccionespost> Instruccionesposts { get; set; } = new List<Instruccionespost>();

    public virtual ICollection<Notamedica> Notamedicas { get; set; } = new List<Notamedica>();

    public virtual ICollection<Procquirurgico> Procquirurgicos { get; set; } = new List<Procquirurgico>();

    public virtual ICollection<Solicitudexamene> Solicitudexamenes { get; set; } = new List<Solicitudexamene>();
}
