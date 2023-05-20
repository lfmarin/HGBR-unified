using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Metodoplanificacion
{
    public int IdMetodo { get; set; }

    public string? NombreMetodo { get; set; }

    public virtual ICollection<Motivosolicitud> Motivosolicituds { get; set; } = new List<Motivosolicitud>();
}
