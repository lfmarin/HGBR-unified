using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Estudioanatomo
{
    public int FkHistoria { get; set; }

    public DateOnly? FechaEnvio { get; set; }

    public string? Clave { get; set; }

    public string? Resultado { get; set; }

    public virtual Historiaclinica FkHistoriaNavigation { get; set; } = null!;
}
