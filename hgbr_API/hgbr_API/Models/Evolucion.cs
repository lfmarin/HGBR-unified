using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Evolucion
{
    public int FkHistoria { get; set; }

    public string? Complicaciones { get; set; }

    public bool? Espermaconteo { get; set; }

    public DateOnly? Fecha1 { get; set; }

    public string? Resultado1 { get; set; }

    public DateOnly? Fecha2 { get; set; }

    public string? Resultado2 { get; set; }

    public virtual Historiaclinica FkHistoriaNavigation { get; set; } = null!;
}
