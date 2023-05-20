using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Solicitudexamene
{
    public int FkFicha { get; set; }

    public DateTime? FechaHora { get; set; }

    public bool? TipoSolicitud { get; set; }

    public int? FkDoctor { get; set; }

    public string? Estudios { get; set; }

    public virtual Doctore? FkDoctorNavigation { get; set; }

    public virtual Fichaidentificacion FkFichaNavigation { get; set; } = null!;
}
