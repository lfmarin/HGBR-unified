using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Religion
{
    public int IdReligion { get; set; }

    public string? NombreReligion { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
