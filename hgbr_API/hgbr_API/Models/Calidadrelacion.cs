using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Calidadrelacion
{
    public int IdCalidadRelacion { get; set; }

    public string? NombreCalidadRelacion { get; set; }

    public virtual ICollection<Encuestaseguimiento> Encuestaseguimientos { get; set; } = new List<Encuestaseguimiento>();
}
