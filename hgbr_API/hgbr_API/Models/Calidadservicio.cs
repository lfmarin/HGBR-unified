using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Calidadservicio
{
    public int IdCalidad { get; set; }

    public string? NombreCalidad { get; set; }

    public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; } = new List<Encuestaseguimiento>();
}
