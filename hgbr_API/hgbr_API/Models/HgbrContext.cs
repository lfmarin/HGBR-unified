using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hgbr_API.Models;

public partial class HgbrContext : DbContext
{
    public HgbrContext()
    {
    }

    public HgbrContext(DbContextOptions<HgbrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admisione> Admisiones { get; set; }

    public virtual DbSet<EstadoConyugal> EstadoConyugals { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoAsentamiento> TipoAsentamientos { get; set; }

    public virtual DbSet<TipoVialidad> TipoVialidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=123456;database=hgbr", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admisione>(entity =>
        {
            entity.HasKey(e => e.Folio).HasName("PRIMARY");

            entity.ToTable("admisiones");

            entity.HasIndex(e => e.FkSexo, "fk_sexo");

            entity.HasIndex(e => e.FkTipoAsentamiento, "fk_tipo_asentamiento");

            entity.HasIndex(e => e.FkTipoVialidad, "fk_tipo_vialidad");

            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .HasColumnName("curp");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.EntidadFederativa)
                .HasMaxLength(50)
                .HasColumnName("entidad_federativa");
            entity.Property(e => e.EntidadNacimiento)
                .HasMaxLength(30)
                .HasColumnName("entidad_nacimiento");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FkSexo).HasColumnName("fk_sexo");
            entity.Property(e => e.FkTipoAsentamiento).HasColumnName("fk_tipo_asentamiento");
            entity.Property(e => e.FkTipoVialidad).HasColumnName("fk_tipo_vialidad");
            entity.Property(e => e.Gratuitidad).HasColumnName("gratuitidad");
            entity.Property(e => e.Insabi).HasColumnName("insabi");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .HasColumnName("localidad");
            entity.Property(e => e.MunicipioDeleg)
                .HasMaxLength(50)
                .HasColumnName("municipio_deleg");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreAsentamiento)
                .HasMaxLength(50)
                .HasColumnName("nombre_asentamiento");
            entity.Property(e => e.NombreVialidad)
                .HasMaxLength(30)
                .HasColumnName("nombre_vialidad");
            entity.Property(e => e.NumExt)
                .HasMaxLength(10)
                .HasColumnName("num_ext");
            entity.Property(e => e.NumInt)
                .HasMaxLength(10)
                .HasColumnName("num_int");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("pais");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.FkSexoNavigation).WithMany(p => p.Admisiones)
                .HasForeignKey(d => d.FkSexo)
                .HasConstraintName("admisiones_ibfk_1");

            entity.HasOne(d => d.FkTipoAsentamientoNavigation).WithMany(p => p.Admisiones)
                .HasForeignKey(d => d.FkTipoAsentamiento)
                .HasConstraintName("admisiones_ibfk_3");

            entity.HasOne(d => d.FkTipoVialidadNavigation).WithMany(p => p.Admisiones)
                .HasForeignKey(d => d.FkTipoVialidad)
                .HasConstraintName("admisiones_ibfk_2");
        });

        modelBuilder.Entity<EstadoConyugal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estado_conyugal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Folio).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.FkEstadoConyugal, "fk_estado_conyugal");

            entity.HasIndex(e => e.FkSexo, "fk_sexo");

            entity.HasIndex(e => e.FkTipoAsentamiento, "fk_tipo_asentamiento");

            entity.HasIndex(e => e.FkTipoVialidad, "fk_tipo_vialidad");

            entity.Property(e => e.Folio)
                .HasMaxLength(13)
                .HasColumnName("folio");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.CualLengua)
                .HasMaxLength(30)
                .HasColumnName("cual_lengua");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .HasColumnName("curp");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.EntidadFederativa)
                .HasMaxLength(50)
                .HasColumnName("entidad_federativa");
            entity.Property(e => e.EntidadNacimiento)
                .HasMaxLength(30)
                .HasColumnName("entidad_nacimiento");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FkEstadoConyugal).HasColumnName("fk_estado_conyugal");
            entity.Property(e => e.FkSexo).HasColumnName("fk_sexo");
            entity.Property(e => e.FkTipoAsentamiento).HasColumnName("fk_tipo_asentamiento");
            entity.Property(e => e.FkTipoVialidad).HasColumnName("fk_tipo_vialidad");
            entity.Property(e => e.Gratuitidad).HasColumnName("gratuitidad");
            entity.Property(e => e.Indigena).HasColumnName("indigena");
            entity.Property(e => e.Insabi).HasColumnName("insabi");
            entity.Property(e => e.LenguaIndigena).HasColumnName("lengua_indigena");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .HasColumnName("localidad");
            entity.Property(e => e.MunicipioDeleg)
                .HasMaxLength(50)
                .HasColumnName("municipio_deleg");
            entity.Property(e => e.NacidoHospital).HasColumnName("nacido_hospital");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreAsentamiento)
                .HasMaxLength(50)
                .HasColumnName("nombre_asentamiento");
            entity.Property(e => e.NombreVialidad)
                .HasMaxLength(30)
                .HasColumnName("nombre_vialidad");
            entity.Property(e => e.NumExt)
                .HasMaxLength(10)
                .HasColumnName("num_ext");
            entity.Property(e => e.NumInt)
                .HasMaxLength(10)
                .HasColumnName("num_int");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("pais");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Talla).HasColumnName("talla");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.FkEstadoConyugalNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkEstadoConyugal)
                .HasConstraintName("pacientes_ibfk_2");

            entity.HasOne(d => d.FkSexoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkSexo)
                .HasConstraintName("pacientes_ibfk_1");

            entity.HasOne(d => d.FkTipoAsentamientoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkTipoAsentamiento)
                .HasConstraintName("pacientes_ibfk_4");

            entity.HasOne(d => d.FkTipoVialidadNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkTipoVialidad)
                .HasConstraintName("pacientes_ibfk_3");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sexo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoAsentamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_asentamiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoVialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_vialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
