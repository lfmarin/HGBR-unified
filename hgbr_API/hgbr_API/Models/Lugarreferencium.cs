using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Lugarreferencium
{
    public int IdLugar { get; set; }

    public string? NombreLugar { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
