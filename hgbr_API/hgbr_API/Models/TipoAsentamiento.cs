using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class TipoAsentamiento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Admisione> Admisiones { get; set; } = new List<Admisione>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
