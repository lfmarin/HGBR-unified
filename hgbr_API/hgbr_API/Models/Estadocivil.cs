using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Estadocivil
{
    public int IdEstadoCivil { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Pacientesarch> Pacientesarches { get; set; } = new List<Pacientesarch>();
}
