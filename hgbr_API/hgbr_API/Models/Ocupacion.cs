using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Ocupacion
{
    public int IdOcupacion { get; set; }

    public string? NombreOcupacion { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
