using System;
using System.Collections.Generic;

namespace Universidad.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? CodigoPostal { get; set; }

    public int? NumeroTelefono { get; set; }

    public virtual ICollection<CalificacionesDiseño> CalificacionesDiseños { get; set; } = new List<CalificacionesDiseño>();

    public virtual ICollection<CalificacionesMatematica> CalificacionesMatematicas { get; set; } = new List<CalificacionesMatematica>();

    public virtual ICollection<CalificacionesProgramacion> CalificacionesProgramacions { get; set; } = new List<CalificacionesProgramacion>();
}
