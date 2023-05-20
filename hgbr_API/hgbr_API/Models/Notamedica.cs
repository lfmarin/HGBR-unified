using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Notamedica
{
    public int IdNota { get; set; }

    public int? FkFicha { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? SignosVitales { get; set; }

    public string? DiagnosticoPre { get; set; }

    public string? CirugiaProgramada { get; set; }

    public DateOnly? FechaCirugia { get; set; }

    public string? TipoAnestesia { get; set; }

    public string? Preparacion { get; set; }

    public int? FkDoctor { get; set; }

    public string? DiagnosticoPost { get; set; }

    public string? Complicaciones { get; set; }

    public string? Descripcion { get; set; }

    public virtual Doctore? FkDoctorNavigation { get; set; }

    public virtual Fichaidentificacion? FkFichaNavigation { get; set; }
}
