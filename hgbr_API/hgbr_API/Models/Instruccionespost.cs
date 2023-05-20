using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Instruccionespost
{
    public int FkFicha { get; set; }

    public int? FkDoctor { get; set; }

    public int? FkHospital { get; set; }

    public virtual Doctore? FkDoctorNavigation { get; set; }

    public virtual Fichaidentificacion FkFichaNavigation { get; set; } = null!;

    public virtual Hospitale? FkHospitalNavigation { get; set; }
}
