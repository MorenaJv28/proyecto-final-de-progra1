using System;
using System.Collections.Generic;

namespace Universidad.Models;

public partial class CalificacionesProgramacion
{
    public int Id { get; set; }

    public int? IdEstudiante { get; set; }

    public decimal? NotaExamen1 { get; set; }

    public decimal? NotaExamen2 { get; set; }

    public decimal? NotaExamen3 { get; set; }

    public decimal? NotaFinal { get; set; }

    public int? IdProfesor { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }

    public virtual Profesore? IdProfesorNavigation { get; set; }
}
