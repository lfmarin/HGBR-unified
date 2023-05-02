﻿using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Admisione
{
    public int Folio { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Curp { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? EntidadNacimiento { get; set; }

    public int? Edad { get; set; }

    public int? FkSexo { get; set; }

    public bool? Insabi { get; set; }

    public bool? Gratuitidad { get; set; }

    public int? FkTipoVialidad { get; set; }

    public string? NombreVialidad { get; set; }

    public string? NumExt { get; set; }

    public string? NumInt { get; set; }

    public int? FkTipoAsentamiento { get; set; }

    public string? NombreAsentamiento { get; set; }

    public long? Cp { get; set; }

    public string? Localidad { get; set; }

    public string? MunicipioDeleg { get; set; }

    public string? EntidadFederativa { get; set; }

    public string? Pais { get; set; }

    public long? Telefono { get; set; }

    public virtual Sexo? FkSexoNavigation { get; set; }

    public virtual TipoAsentamiento? FkTipoAsentamientoNavigation { get; set; }

    public virtual TipoVialidad? FkTipoVialidadNavigation { get; set; }
}
