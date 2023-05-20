using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Escolaridad
{
    public int IdEscolaridad { get; set; }

    public string? NombreEscolaridad { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
