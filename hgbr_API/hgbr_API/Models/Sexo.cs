using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Sexo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Admisione> Admisiones { get; set; } = new List<Admisione>();

    public virtual ICollection<Pacientesarch> Pacientesarches { get; set; } = new List<Pacientesarch>();
}
