using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

public partial class UniversidadContext : DbContext
{
    public UniversidadContext()
    {
    }

    public UniversidadContext(DbContextOptions<UniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalificacionesDiseño> CalificacionesDiseños { get; set; }

    public virtual DbSet<CalificacionesMatematica> CalificacionesMatematicas { get; set; }

    public virtual DbSet<CalificacionesProgramacion> CalificacionesProgramacions { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QT06L4V\\SQLEXPRESS ;Database= Universidad;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalificacionesDiseño>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F4DAA0C74");

            entity.ToTable("calificacionesDiseño");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdProfesor).HasColumnName("id_Profesor");
            entity.Property(e => e.NotaExamen1)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen1");
            entity.Property(e => e.NotaExamen2)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen2");
            entity.Property(e => e.NotaExamen3)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen3");
            entity.Property(e => e.NotaFinal)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_Final");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.CalificacionesDiseños)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_calificacionesDiseño_estudiantes");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.CalificacionesDiseños)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("fk_calificacionesDiseño_Profesores");
        });

        modelBuilder.Entity<CalificacionesMatematica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83FB1CA9009");

            entity.ToTable("calificacionesMatematicas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdProfesor).HasColumnName("id_Profesor");
            entity.Property(e => e.NotaExamen1)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen1");
            entity.Property(e => e.NotaExamen2)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen2");
            entity.Property(e => e.NotaExamen3)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen3");
            entity.Property(e => e.NotaFinal)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_Final");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.CalificacionesMatematicas)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_calificacionesMatematicas_estudiantes");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.CalificacionesMatematicas)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("fk_calificacionesMatematicas_Profesores");
        });

        modelBuilder.Entity<CalificacionesProgramacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F0187A291");

            entity.ToTable("calificacionesProgramacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdProfesor).HasColumnName("id_Profesor");
            entity.Property(e => e.NotaExamen1)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen1");
            entity.Property(e => e.NotaExamen2)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen2");
            entity.Property(e => e.NotaExamen3)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_examen3");
            entity.Property(e => e.NotaFinal)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Nota_Final");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.CalificacionesProgramacions)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_calificacionesProgramacion_estudiantes");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.CalificacionesProgramacions)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("fk_calificacionesProgramacion_Profesores");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estudian__3213E83F1A743E2C");

            entity.ToTable("estudiantes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroTelefono).HasColumnName("numero_telefono");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3213E83F1809F39C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Asignatura)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("asignatura");
            entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroTelefono).HasColumnName("numero_telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
