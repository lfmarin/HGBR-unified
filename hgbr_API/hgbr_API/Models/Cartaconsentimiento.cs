using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Cartaconsentimiento
{
    public int FkFicha { get; set; }

    public int? FkHospital { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? FkConsejeria { get; set; }

    public string? Testigo1 { get; set; }

    public string? Testigo2 { get; set; }

    public int? FkDoctor { get; set; }

    public virtual Personalconsejerium? FkConsejeriaNavigation { get; set; }

    public virtual Doctore? FkDoctorNavigation { get; set; }

    public virtual Fichaidentificacion FkFichaNavigation { get; set; } = null!;

    public virtual Hospitale? FkHospitalNavigation { get; set; }
}
