using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Opinionpareja
{
    public int IdOpinion { get; set; }

    public string? NombreOpinion { get; set; }

    public virtual ICollection<Motivosolicitud> Motivosolicituds { get; set; } = new List<Motivosolicitud>();
}
