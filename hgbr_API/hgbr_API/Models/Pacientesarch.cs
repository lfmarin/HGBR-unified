using System;
using System.Collections.Generic;

namespace hgbr_API.Models;

public partial class Pacientesarch
{
    public string NoExpediente { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? ApPaterno { get; set; }

    public string? ApMaterno { get; set; }

    public string? Curp { get; set; }

    public DateOnly? FechaNac { get; set; }

    public TimeOnly? HoraNac { get; set; }

    public string? EntidadNac { get; set; }

    public int? EdadYears { get; set; }

    public int? EdadMonths { get; set; }

    public int? EdadDays { get; set; }

    public int? EdadHours { get; set; }

    public bool? NacidoHospital { get; set; }

    public int? FkSexo { get; set; }

    public float? Peso { get; set; }

    public int? Talla { get; set; }

    public int? FkEstadoCivil { get; set; }

    public bool? Insabi { get; set; }

    public bool? Gratuitidad { get; set; }

    public bool? Indigena { get; set; }

    public bool? LenguaIndigena { get; set; }

    public string? CualLengua { get; set; }

    public int? FkTipoCalleCasa { get; set; }

    public string? CalleCasa { get; set; }

    public string? NumCasa { get; set; }

    public string? NumCasaInt { get; set; }

    public int? FkTipoColCasa { get; set; }

    public string? ColCasa { get; set; }

    public long? Cp { get; set; }

    public string? Localidad { get; set; }

    public string? Municipio { get; set; }

    public string? EntidadFederativa { get; set; }

    public string? Pais { get; set; }

    public long? TelCasa { get; set; }

    public virtual Estadocivil? FkEstadoCivilNavigation { get; set; }

    public virtual Sexo? FkSexoNavigation { get; set; }

    public virtual Tipovialidad? FkTipoCalleCasaNavigation { get; set; }

    public virtual Tipoasentamiento? FkTipoColCasaNavigation { get; set; }
}
