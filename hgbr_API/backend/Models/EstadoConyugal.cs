﻿using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class EstadoConyugal
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
