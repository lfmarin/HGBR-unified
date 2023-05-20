using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hgbr_API.Models;

public partial class HospitalBocaContext : DbContext
{
    public HospitalBocaContext()
    {
    }

    public HospitalBocaContext(DbContextOptions<HospitalBocaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admisione> Admisiones { get; set; }

    public virtual DbSet<Calidadrelacion> Calidadrelacions { get; set; }

    public virtual DbSet<Calidadservicio> Calidadservicios { get; set; }

    public virtual DbSet<Cartaconsentimiento> Cartaconsentimientos { get; set; }

    public virtual DbSet<Doctore> Doctores { get; set; }

    public virtual DbSet<Encuestaseguimiento> Encuestaseguimientos { get; set; }

    public virtual DbSet<Escolaridad> Escolaridads { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Estadocivil> Estadocivils { get; set; }

    public virtual DbSet<Estudioanatomo> Estudioanatomos { get; set; }

    public virtual DbSet<Evolucion> Evolucions { get; set; }

    public virtual DbSet<Fichaidentificacion> Fichaidentificacions { get; set; }

    public virtual DbSet<Historiaclinica> Historiaclinicas { get; set; }

    public virtual DbSet<Historiaexploracion> Historiaexploracions { get; set; }

    public virtual DbSet<Hospitale> Hospitales { get; set; }

    public virtual DbSet<Instruccionespost> Instruccionesposts { get; set; }

    public virtual DbSet<Lugarreferencium> Lugarreferencia { get; set; }

    public virtual DbSet<Metodoplanificacion> Metodoplanificacions { get; set; }

    public virtual DbSet<Motivosolicitud> Motivosolicituds { get; set; }

    public virtual DbSet<Notamedica> Notamedicas { get; set; }

    public virtual DbSet<Ocupacion> Ocupacions { get; set; }

    public virtual DbSet<Opinionpareja> Opinionparejas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pacientesarch> Pacientesarches { get; set; }

    public virtual DbSet<Personalconsejerium> Personalconsejeria { get; set; }

    public virtual DbSet<Procquirurgico> Procquirurgicos { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Solicitudexamene> Solicitudexamenes { get; set; }

    public virtual DbSet<Tipoasentamiento> Tipoasentamientos { get; set; }

    public virtual DbSet<Tipovialidad> Tipovialidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=123456;database=hospital_boca", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admisione>(entity =>
        {
            entity.HasKey(e => e.Folio).HasName("PRIMARY");

            entity.ToTable("admisiones");

            entity.HasIndex(e => e.FkSexo, "fkSexo");

            entity.HasIndex(e => e.FkTipoAsentamiento, "fkTipoAsentamiento");

            entity.HasIndex(e => e.FkTipoVialidad, "fkTipoVialidad");

            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .HasColumnName("curp");
            entity.Property(e => e.EdadDays).HasColumnName("edadDays");
            entity.Property(e => e.EdadHours).HasColumnName("edadHours");
            entity.Property(e => e.EdadMonths).HasColumnName("edadMonths");
            entity.Property(e => e.EdadYears).HasColumnName("edadYears");
            entity.Property(e => e.EntidadFederativa)
                .HasMaxLength(50)
                .HasColumnName("entidadFederativa");
            entity.Property(e => e.EntidadNacimiento)
                .HasMaxLength(30)
                .HasColumnName("entidadNacimiento");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.FkSexo).HasColumnName("fkSexo");
            entity.Property(e => e.FkTipoAsentamiento).HasColumnName("fkTipoAsentamiento");
            entity.Property(e => e.FkTipoVialidad).HasColumnName("fkTipoVialidad");
            entity.Property(e => e.Gratuitidad).HasColumnName("gratuitidad");
            entity.Property(e => e.HoraNacimiento)
                .HasColumnType("time")
                .HasColumnName("horaNacimiento");
            entity.Property(e => e.Insabi).HasColumnName("insabi");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .HasColumnName("localidad");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreAsentamiento)
                .HasMaxLength(50)
                .HasColumnName("nombreAsentamiento");
            entity.Property(e => e.NombreVialidad)
                .HasMaxLength(30)
                .HasColumnName("nombreVialidad");
            entity.Property(e => e.NumExt)
                .HasMaxLength(10)
                .HasColumnName("numExt");
            entity.Property(e => e.NumInt)
                .HasMaxLength(10)
                .HasColumnName("numInt");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("pais");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .HasColumnName("primerApellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .HasColumnName("segundoApellido");
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

        modelBuilder.Entity<Calidadrelacion>(entity =>
        {
            entity.HasKey(e => e.IdCalidadRelacion).HasName("PRIMARY");

            entity.ToTable("calidadrelacion");

            entity.Property(e => e.IdCalidadRelacion).HasColumnName("idCalidadRelacion");
            entity.Property(e => e.NombreCalidadRelacion)
                .HasMaxLength(10)
                .HasColumnName("nombreCalidadRelacion");
        });

        modelBuilder.Entity<Calidadservicio>(entity =>
        {
            entity.HasKey(e => e.IdCalidad).HasName("PRIMARY");

            entity.ToTable("calidadservicio");

            entity.Property(e => e.IdCalidad).HasColumnName("idCalidad");
            entity.Property(e => e.NombreCalidad)
                .HasMaxLength(10)
                .HasColumnName("nombreCalidad");
        });

        modelBuilder.Entity<Cartaconsentimiento>(entity =>
        {
            entity.HasKey(e => e.FkFicha).HasName("PRIMARY");

            entity.ToTable("cartaconsentimiento");

            entity.HasIndex(e => e.FkConsejeria, "fkConsejeria");

            entity.HasIndex(e => e.FkDoctor, "fkDoctor");

            entity.HasIndex(e => e.FkHospital, "fkHospital");

            entity.Property(e => e.FkFicha)
                .ValueGeneratedNever()
                .HasColumnName("fkFicha");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fechaHora");
            entity.Property(e => e.FkConsejeria).HasColumnName("fkConsejeria");
            entity.Property(e => e.FkDoctor).HasColumnName("fkDoctor");
            entity.Property(e => e.FkHospital).HasColumnName("fkHospital");
            entity.Property(e => e.Testigo1)
                .HasMaxLength(100)
                .HasColumnName("testigo1");
            entity.Property(e => e.Testigo2)
                .HasMaxLength(100)
                .HasColumnName("testigo2");

            entity.HasOne(d => d.FkConsejeriaNavigation).WithMany(p => p.Cartaconsentimientos)
                .HasForeignKey(d => d.FkConsejeria)
                .HasConstraintName("cartaconsentimiento_ibfk_3");

            entity.HasOne(d => d.FkDoctorNavigation).WithMany(p => p.Cartaconsentimientos)
                .HasForeignKey(d => d.FkDoctor)
                .HasConstraintName("cartaconsentimiento_ibfk_4");

            entity.HasOne(d => d.FkFichaNavigation).WithOne(p => p.Cartaconsentimiento)
                .HasForeignKey<Cartaconsentimiento>(d => d.FkFicha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartaconsentimiento_ibfk_1");

            entity.HasOne(d => d.FkHospitalNavigation).WithMany(p => p.Cartaconsentimientos)
                .HasForeignKey(d => d.FkHospital)
                .HasConstraintName("cartaconsentimiento_ibfk_2");
        });

        modelBuilder.Entity<Doctore>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PRIMARY");

            entity.ToTable("doctores");

            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(50)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(50)
                .HasColumnName("apPaterno");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Encuestaseguimiento>(entity =>
        {
            entity.HasKey(e => e.FkPaciente).HasName("PRIMARY");

            entity.ToTable("encuestaseguimiento");

            entity.HasIndex(e => e.FkCalidad, "fkCalidad");

            entity.HasIndex(e => e.FkCalidadRelacion, "fkCalidadRelacion");

            entity.HasIndex(e => e.FkConsejeria, "fkConsejeria");

            entity.HasIndex(e => e.FkHospital, "fkHospital");

            entity.HasIndex(e => e.FkHospitalReferencia, "fkHospitalReferencia");

            entity.Property(e => e.FkPaciente)
                .HasMaxLength(15)
                .HasColumnName("fkPaciente");
            entity.Property(e => e.Complicacion).HasColumnName("complicacion");
            entity.Property(e => e.CualRecomendacion)
                .HasMaxLength(100)
                .HasColumnName("cualRecomendacion");
            entity.Property(e => e.FechaEncuesta).HasColumnName("fechaEncuesta");
            entity.Property(e => e.FechaNegativo).HasColumnName("fechaNegativo");
            entity.Property(e => e.FechaVasectomia).HasColumnName("fechaVasectomia");
            entity.Property(e => e.FkCalidad).HasColumnName("fkCalidad");
            entity.Property(e => e.FkCalidadRelacion).HasColumnName("fkCalidadRelacion");
            entity.Property(e => e.FkConsejeria).HasColumnName("fkConsejeria");
            entity.Property(e => e.FkHospital).HasColumnName("fkHospital");
            entity.Property(e => e.FkHospitalReferencia).HasColumnName("fkHospitalReferencia");
            entity.Property(e => e.LugarEspermaconteo).HasMaxLength(50);
            entity.Property(e => e.MotivoCalidad)
                .HasMaxLength(50)
                .HasColumnName("motivoCalidad");
            entity.Property(e => e.MotivoComplicacion)
                .HasMaxLength(50)
                .HasColumnName("motivoComplicacion");
            entity.Property(e => e.MotivoLugar)
                .HasMaxLength(50)
                .HasColumnName("motivoLugar");
            entity.Property(e => e.MotivoRecomendacion)
                .HasMaxLength(50)
                .HasColumnName("motivoRecomendacion");
            entity.Property(e => e.MotivoSatisfaccion)
                .HasMaxLength(50)
                .HasColumnName("motivoSatisfaccion");
            entity.Property(e => e.OrigenInfo)
                .HasMaxLength(50)
                .HasColumnName("origenInfo");
            entity.Property(e => e.Recomendacion).HasColumnName("recomendacion");
            entity.Property(e => e.RecomendacionHospital).HasColumnName("recomendacionHospital");
            entity.Property(e => e.Referido).HasColumnName("referido");
            entity.Property(e => e.Satisfaccion).HasColumnName("satisfaccion");

            entity.HasOne(d => d.FkCalidadNavigation).WithMany(p => p.Encuestaseguimientos)
                .HasForeignKey(d => d.FkCalidad)
                .HasConstraintName("encuestaseguimiento_ibfk_5");

            entity.HasOne(d => d.FkCalidadRelacionNavigation).WithMany(p => p.Encuestaseguimientos)
                .HasForeignKey(d => d.FkCalidadRelacion)
                .HasConstraintName("encuestaseguimiento_ibfk_6");

            entity.HasOne(d => d.FkConsejeriaNavigation).WithMany(p => p.Encuestaseguimientos)
                .HasForeignKey(d => d.FkConsejeria)
                .HasConstraintName("encuestaseguimiento_ibfk_3");

            entity.HasOne(d => d.FkHospitalNavigation).WithMany(p => p.EncuestaseguimientoFkHospitalNavigations)
                .HasForeignKey(d => d.FkHospital)
                .HasConstraintName("encuestaseguimiento_ibfk_2");

            entity.HasOne(d => d.FkHospitalReferenciaNavigation).WithMany(p => p.EncuestaseguimientoFkHospitalReferenciaNavigations)
                .HasForeignKey(d => d.FkHospitalReferencia)
                .HasConstraintName("encuestaseguimiento_ibfk_4");

            entity.HasOne(d => d.FkPacienteNavigation).WithOne(p => p.Encuestaseguimiento)
                .HasForeignKey<Encuestaseguimiento>(d => d.FkPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("encuestaseguimiento_ibfk_1");
        });

        modelBuilder.Entity<Escolaridad>(entity =>
        {
            entity.HasKey(e => e.IdEscolaridad).HasName("PRIMARY");

            entity.ToTable("escolaridad");

            entity.Property(e => e.IdEscolaridad).HasColumnName("idEscolaridad");
            entity.Property(e => e.NombreEscolaridad)
                .HasMaxLength(30)
                .HasColumnName("nombreEscolaridad");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estados");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estadocivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil).HasName("PRIMARY");

            entity.ToTable("estadocivil");

            entity.Property(e => e.IdEstadoCivil).HasColumnName("idEstadoCivil");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(30)
                .HasColumnName("nombreEstado");
        });

        modelBuilder.Entity<Estudioanatomo>(entity =>
        {
            entity.HasKey(e => e.FkHistoria).HasName("PRIMARY");

            entity.ToTable("estudioanatomo");

            entity.Property(e => e.FkHistoria)
                .ValueGeneratedNever()
                .HasColumnName("fkHistoria");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.FechaEnvio).HasColumnName("fechaEnvio");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .HasColumnName("resultado");

            entity.HasOne(d => d.FkHistoriaNavigation).WithOne(p => p.Estudioanatomo)
                .HasForeignKey<Estudioanatomo>(d => d.FkHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudioanatomo_ibfk_1");
        });

        modelBuilder.Entity<Evolucion>(entity =>
        {
            entity.HasKey(e => e.FkHistoria).HasName("PRIMARY");

            entity.ToTable("evolucion");

            entity.Property(e => e.FkHistoria)
                .ValueGeneratedNever()
                .HasColumnName("fkHistoria");
            entity.Property(e => e.Complicaciones)
                .HasMaxLength(100)
                .HasColumnName("complicaciones");
            entity.Property(e => e.Espermaconteo).HasColumnName("espermaconteo");
            entity.Property(e => e.Fecha1).HasColumnName("fecha1");
            entity.Property(e => e.Fecha2).HasColumnName("fecha2");
            entity.Property(e => e.Resultado1)
                .HasMaxLength(50)
                .HasColumnName("resultado1");
            entity.Property(e => e.Resultado2)
                .HasMaxLength(50)
                .HasColumnName("resultado2");

            entity.HasOne(d => d.FkHistoriaNavigation).WithOne(p => p.Evolucion)
                .HasForeignKey<Evolucion>(d => d.FkHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evolucion_ibfk_1");
        });

        modelBuilder.Entity<Fichaidentificacion>(entity =>
        {
            entity.HasKey(e => e.IdFicha).HasName("PRIMARY");

            entity.ToTable("fichaidentificacion");

            entity.HasIndex(e => e.FkPaciente, "fkPaciente");

            entity.Property(e => e.IdFicha).HasColumnName("idFicha");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(50)
                .HasColumnName("diagnostico");
            entity.Property(e => e.FkPaciente)
                .HasMaxLength(15)
                .HasColumnName("fkPaciente");
            entity.Property(e => e.Servicio)
                .HasMaxLength(20)
                .HasColumnName("servicio");

            entity.HasOne(d => d.FkPacienteNavigation).WithMany(p => p.Fichaidentificacions)
                .HasForeignKey(d => d.FkPaciente)
                .HasConstraintName("fichaidentificacion_ibfk_1");
        });

        modelBuilder.Entity<Historiaclinica>(entity =>
        {
            entity.HasKey(e => e.IdHistoriaClinica).HasName("PRIMARY");

            entity.ToTable("historiaclinica");

            entity.HasIndex(e => e.FkHospital, "fkHospital");

            entity.HasIndex(e => e.FkPaciente, "fkPaciente");

            entity.Property(e => e.IdHistoriaClinica).HasColumnName("idHistoriaClinica");
            entity.Property(e => e.FechaElab).HasColumnName("fechaElab");
            entity.Property(e => e.FkHospital).HasColumnName("fkHospital");
            entity.Property(e => e.FkPaciente)
                .HasMaxLength(15)
                .HasColumnName("fkPaciente");

            entity.HasOne(d => d.FkHospitalNavigation).WithMany(p => p.Historiaclinicas)
                .HasForeignKey(d => d.FkHospital)
                .HasConstraintName("historiaclinica_ibfk_2");

            entity.HasOne(d => d.FkPacienteNavigation).WithMany(p => p.Historiaclinicas)
                .HasForeignKey(d => d.FkPaciente)
                .HasConstraintName("historiaclinica_ibfk_1");
        });

        modelBuilder.Entity<Historiaexploracion>(entity =>
        {
            entity.HasKey(e => e.FkHistoria).HasName("PRIMARY");

            entity.ToTable("historiaexploracion");

            entity.Property(e => e.FkHistoria)
                .ValueGeneratedNever()
                .HasColumnName("fkHistoria");
            entity.Property(e => e.AntFamiliares)
                .HasMaxLength(100)
                .HasColumnName("antFamiliares");
            entity.Property(e => e.AntPersonalesNoPat)
                .HasMaxLength(100)
                .HasColumnName("antPersonalesNoPat");
            entity.Property(e => e.AntPersonalesPat)
                .HasMaxLength(100)
                .HasColumnName("antPersonalesPat");
            entity.Property(e => e.ExpOrganos)
                .HasMaxLength(40)
                .HasColumnName("expOrganos");
            entity.Property(e => e.Fc)
                .HasMaxLength(10)
                .HasColumnName("fc");
            entity.Property(e => e.Fr)
                .HasMaxLength(10)
                .HasColumnName("fr");
            entity.Property(e => e.Peso)
                .HasMaxLength(10)
                .HasColumnName("peso");
            entity.Property(e => e.Ta)
                .HasMaxLength(10)
                .HasColumnName("ta");
            entity.Property(e => e.Talla)
                .HasMaxLength(10)
                .HasColumnName("talla");
            entity.Property(e => e.Tem)
                .HasMaxLength(10)
                .HasColumnName("tem");
            entity.Property(e => e.TipoPaciente)
                .HasMaxLength(40)
                .HasColumnName("tipoPaciente");

            entity.HasOne(d => d.FkHistoriaNavigation).WithOne(p => p.Historiaexploracion)
                .HasForeignKey<Historiaexploracion>(d => d.FkHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historiaexploracion_ibfk_1");
        });

        modelBuilder.Entity<Hospitale>(entity =>
        {
            entity.HasKey(e => e.IdHospital).HasName("PRIMARY");

            entity.ToTable("hospitales");

            entity.Property(e => e.IdHospital).HasColumnName("idHospital");
            entity.Property(e => e.EntidadFederativa)
                .HasMaxLength(20)
                .HasColumnName("entidadFederativa");
            entity.Property(e => e.JurSanitaria)
                .HasMaxLength(6)
                .HasColumnName("jurSanitaria");
            entity.Property(e => e.UMedica)
                .HasMaxLength(70)
                .HasColumnName("uMedica");
        });

        modelBuilder.Entity<Instruccionespost>(entity =>
        {
            entity.HasKey(e => e.FkFicha).HasName("PRIMARY");

            entity.ToTable("instruccionespost");

            entity.HasIndex(e => e.FkDoctor, "fkDoctor");

            entity.HasIndex(e => e.FkHospital, "fkHospital");

            entity.Property(e => e.FkFicha)
                .ValueGeneratedNever()
                .HasColumnName("fkFicha");
            entity.Property(e => e.FkDoctor).HasColumnName("fkDoctor");
            entity.Property(e => e.FkHospital).HasColumnName("fkHospital");

            entity.HasOne(d => d.FkDoctorNavigation).WithMany(p => p.Instruccionesposts)
                .HasForeignKey(d => d.FkDoctor)
                .HasConstraintName("instruccionespost_ibfk_3");

            entity.HasOne(d => d.FkFichaNavigation).WithOne(p => p.Instruccionespost)
                .HasForeignKey<Instruccionespost>(d => d.FkFicha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("instruccionespost_ibfk_1");

            entity.HasOne(d => d.FkHospitalNavigation).WithMany(p => p.Instruccionesposts)
                .HasForeignKey(d => d.FkHospital)
                .HasConstraintName("instruccionespost_ibfk_2");
        });

        modelBuilder.Entity<Lugarreferencium>(entity =>
        {
            entity.HasKey(e => e.IdLugar).HasName("PRIMARY");

            entity.ToTable("lugarreferencia");

            entity.Property(e => e.IdLugar).HasColumnName("idLugar");
            entity.Property(e => e.NombreLugar)
                .HasMaxLength(70)
                .HasColumnName("nombreLugar");
        });

        modelBuilder.Entity<Metodoplanificacion>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("PRIMARY");

            entity.ToTable("metodoplanificacion");

            entity.Property(e => e.IdMetodo).HasColumnName("idMetodo");
            entity.Property(e => e.NombreMetodo)
                .HasMaxLength(30)
                .HasColumnName("nombreMetodo");
        });

        modelBuilder.Entity<Motivosolicitud>(entity =>
        {
            entity.HasKey(e => e.FkHistoria).HasName("PRIMARY");

            entity.ToTable("motivosolicitud");

            entity.HasIndex(e => e.FkMetodoPlanificacion, "fkMetodoPlanificacion");

            entity.HasIndex(e => e.FkOpinion, "fkOpinion");

            entity.Property(e => e.FkHistoria)
                .ValueGeneratedNever()
                .HasColumnName("fkHistoria");
            entity.Property(e => e.CausaNoHijos)
                .HasMaxLength(60)
                .HasColumnName("causaNoHijos");
            entity.Property(e => e.FkMetodoPlanificacion).HasColumnName("fkMetodoPlanificacion");
            entity.Property(e => e.FkOpinion).HasColumnName("fkOpinion");

            entity.HasOne(d => d.FkHistoriaNavigation).WithOne(p => p.Motivosolicitud)
                .HasForeignKey<Motivosolicitud>(d => d.FkHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("motivosolicitud_ibfk_1");

            entity.HasOne(d => d.FkMetodoPlanificacionNavigation).WithMany(p => p.Motivosolicituds)
                .HasForeignKey(d => d.FkMetodoPlanificacion)
                .HasConstraintName("motivosolicitud_ibfk_3");

            entity.HasOne(d => d.FkOpinionNavigation).WithMany(p => p.Motivosolicituds)
                .HasForeignKey(d => d.FkOpinion)
                .HasConstraintName("motivosolicitud_ibfk_2");
        });

        modelBuilder.Entity<Notamedica>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PRIMARY");

            entity.ToTable("notamedica");

            entity.HasIndex(e => e.FkDoctor, "fkDoctor");

            entity.HasIndex(e => e.FkFicha, "fkFicha");

            entity.Property(e => e.IdNota).HasColumnName("idNota");
            entity.Property(e => e.CirugiaProgramada)
                .HasMaxLength(100)
                .HasColumnName("cirugiaProgramada");
            entity.Property(e => e.Complicaciones)
                .HasMaxLength(100)
                .HasColumnName("complicaciones");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DiagnosticoPost)
                .HasMaxLength(100)
                .HasColumnName("diagnosticoPost");
            entity.Property(e => e.DiagnosticoPre)
                .HasMaxLength(100)
                .HasColumnName("diagnosticoPre");
            entity.Property(e => e.FechaCirugia).HasColumnName("fechaCirugia");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fechaHora");
            entity.Property(e => e.FkDoctor).HasColumnName("fkDoctor");
            entity.Property(e => e.FkFicha).HasColumnName("fkFicha");
            entity.Property(e => e.Preparacion)
                .HasMaxLength(100)
                .HasColumnName("preparacion");
            entity.Property(e => e.SignosVitales)
                .HasMaxLength(100)
                .HasColumnName("signosVitales");
            entity.Property(e => e.TipoAnestesia)
                .HasMaxLength(50)
                .HasColumnName("tipoAnestesia");

            entity.HasOne(d => d.FkDoctorNavigation).WithMany(p => p.Notamedicas)
                .HasForeignKey(d => d.FkDoctor)
                .HasConstraintName("notamedica_ibfk_2");

            entity.HasOne(d => d.FkFichaNavigation).WithMany(p => p.Notamedicas)
                .HasForeignKey(d => d.FkFicha)
                .HasConstraintName("notamedica_ibfk_1");
        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(e => e.IdOcupacion).HasName("PRIMARY");

            entity.ToTable("ocupacion");

            entity.Property(e => e.IdOcupacion).HasColumnName("idOcupacion");
            entity.Property(e => e.NombreOcupacion)
                .HasMaxLength(70)
                .HasColumnName("nombreOcupacion");
        });

        modelBuilder.Entity<Opinionpareja>(entity =>
        {
            entity.HasKey(e => e.IdOpinion).HasName("PRIMARY");

            entity.ToTable("opinionpareja");

            entity.Property(e => e.IdOpinion).HasColumnName("idOpinion");
            entity.Property(e => e.NombreOpinion)
                .HasMaxLength(30)
                .HasColumnName("nombreOpinion");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.NoExpediente).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.FkEscolaridad, "fkEscolaridad");

            entity.HasIndex(e => e.FkEstadoCivil, "fkEstadoCivil");

            entity.HasIndex(e => e.FkLugarReferencia, "fkLugarReferencia");

            entity.HasIndex(e => e.FkOcupacion, "fkOcupacion");

            entity.HasIndex(e => e.FkReligion, "fkReligion");

            entity.Property(e => e.NoExpediente)
                .HasMaxLength(15)
                .HasColumnName("noExpediente");
            entity.Property(e => e.AosRelac).HasColumnName("aosRelac");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(50)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(50)
                .HasColumnName("apPaterno");
            entity.Property(e => e.CalleCasa)
                .HasMaxLength(50)
                .HasColumnName("calleCasa");
            entity.Property(e => e.CalleTrabajo)
                .HasMaxLength(50)
                .HasColumnName("calleTrabajo");
            entity.Property(e => e.ColCasa)
                .HasMaxLength(50)
                .HasColumnName("colCasa");
            entity.Property(e => e.ColTrabajo)
                .HasMaxLength(50)
                .HasColumnName("colTrabajo");
            entity.Property(e => e.EdadHijoMenor).HasColumnName("edadHijoMenor");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.FkEscolaridad).HasColumnName("fkEscolaridad");
            entity.Property(e => e.FkEstadoCivil).HasColumnName("fkEstadoCivil");
            entity.Property(e => e.FkLugarReferencia).HasColumnName("fkLugarReferencia");
            entity.Property(e => e.FkOcupacion).HasColumnName("fkOcupacion");
            entity.Property(e => e.FkReligion).HasColumnName("fkReligion");
            entity.Property(e => e.Ivs).HasColumnName("ivs");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreEsposa)
                .HasMaxLength(100)
                .HasColumnName("nombreEsposa");
            entity.Property(e => e.NumCasa).HasColumnName("numCasa");
            entity.Property(e => e.NumHijosVivos).HasColumnName("numHijosVivos");
            entity.Property(e => e.NumTrabajo).HasColumnName("numTrabajo");
            entity.Property(e => e.TelCasa)
                .HasMaxLength(12)
                .HasColumnName("telCasa");
            entity.Property(e => e.TelTrabajo)
                .HasMaxLength(12)
                .HasColumnName("telTrabajo");

            entity.HasOne(d => d.FkEscolaridadNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkEscolaridad)
                .HasConstraintName("pacientes_ibfk_2");

            entity.HasOne(d => d.FkEstadoCivilNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkEstadoCivil)
                .HasConstraintName("pacientes_ibfk_1");

            entity.HasOne(d => d.FkLugarReferenciaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkLugarReferencia)
                .HasConstraintName("pacientes_ibfk_5");

            entity.HasOne(d => d.FkOcupacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkOcupacion)
                .HasConstraintName("pacientes_ibfk_3");

            entity.HasOne(d => d.FkReligionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkReligion)
                .HasConstraintName("pacientes_ibfk_4");
        });

        modelBuilder.Entity<Pacientesarch>(entity =>
        {
            entity.HasKey(e => e.NoExpediente).HasName("PRIMARY");

            entity.ToTable("pacientesarch");

            entity.HasIndex(e => e.FkEstadoCivil, "fkEstadoCivil");

            entity.HasIndex(e => e.FkSexo, "fkSexo");

            entity.HasIndex(e => e.FkTipoCalleCasa, "fkTipoCalleCasa");

            entity.HasIndex(e => e.FkTipoColCasa, "fkTipoColCasa");

            entity.Property(e => e.NoExpediente)
                .HasMaxLength(13)
                .HasColumnName("noExpediente");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(50)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(50)
                .HasColumnName("apPaterno");
            entity.Property(e => e.CalleCasa)
                .HasMaxLength(30)
                .HasColumnName("calleCasa");
            entity.Property(e => e.ColCasa)
                .HasMaxLength(50)
                .HasColumnName("colCasa");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.CualLengua)
                .HasMaxLength(30)
                .HasColumnName("cualLengua");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .HasColumnName("curp");
            entity.Property(e => e.EdadDays).HasColumnName("edadDays");
            entity.Property(e => e.EdadHours).HasColumnName("edadHours");
            entity.Property(e => e.EdadMonths).HasColumnName("edadMonths");
            entity.Property(e => e.EdadYears).HasColumnName("edadYears");
            entity.Property(e => e.EntidadFederativa)
                .HasMaxLength(50)
                .HasColumnName("entidadFederativa");
            entity.Property(e => e.EntidadNac)
                .HasMaxLength(30)
                .HasColumnName("entidadNac");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.FkEstadoCivil).HasColumnName("fkEstadoCivil");
            entity.Property(e => e.FkSexo).HasColumnName("fkSexo");
            entity.Property(e => e.FkTipoCalleCasa).HasColumnName("fkTipoCalleCasa");
            entity.Property(e => e.FkTipoColCasa).HasColumnName("fkTipoColCasa");
            entity.Property(e => e.Gratuitidad).HasColumnName("gratuitidad");
            entity.Property(e => e.HoraNac)
                .HasColumnType("time")
                .HasColumnName("horaNac");
            entity.Property(e => e.Indigena).HasColumnName("indigena");
            entity.Property(e => e.Insabi).HasColumnName("insabi");
            entity.Property(e => e.LenguaIndigena).HasColumnName("lenguaIndigena");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .HasColumnName("localidad");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .HasColumnName("municipio");
            entity.Property(e => e.NacidoHospital).HasColumnName("nacidoHospital");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.NumCasa)
                .HasMaxLength(10)
                .HasColumnName("numCasa");
            entity.Property(e => e.NumCasaInt)
                .HasMaxLength(10)
                .HasColumnName("numCasaInt");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("pais");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.Talla).HasColumnName("talla");
            entity.Property(e => e.TelCasa).HasColumnName("telCasa");

            entity.HasOne(d => d.FkEstadoCivilNavigation).WithMany(p => p.Pacientesarches)
                .HasForeignKey(d => d.FkEstadoCivil)
                .HasConstraintName("pacientesarch_ibfk_2");

            entity.HasOne(d => d.FkSexoNavigation).WithMany(p => p.Pacientesarches)
                .HasForeignKey(d => d.FkSexo)
                .HasConstraintName("pacientesarch_ibfk_1");

            entity.HasOne(d => d.FkTipoCalleCasaNavigation).WithMany(p => p.Pacientesarches)
                .HasForeignKey(d => d.FkTipoCalleCasa)
                .HasConstraintName("pacientesarch_ibfk_3");

            entity.HasOne(d => d.FkTipoColCasaNavigation).WithMany(p => p.Pacientesarches)
                .HasForeignKey(d => d.FkTipoColCasa)
                .HasConstraintName("pacientesarch_ibfk_4");
        });

        modelBuilder.Entity<Personalconsejerium>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PRIMARY");

            entity.ToTable("personalconsejeria");

            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(50)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(50)
                .HasColumnName("apPaterno");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Procquirurgico>(entity =>
        {
            entity.HasKey(e => e.FkHistoria).HasName("PRIMARY");

            entity.ToTable("procquirurgico");

            entity.HasIndex(e => e.FkDoctor, "fkDoctor");

            entity.Property(e => e.FkHistoria)
                .ValueGeneratedNever()
                .HasColumnName("fkHistoria");
            entity.Property(e => e.FechaCirugia).HasColumnName("fechaCirugia");
            entity.Property(e => e.FkDoctor).HasColumnName("fkDoctor");
            entity.Property(e => e.NotaQuirurgica)
                .HasMaxLength(100)
                .HasColumnName("notaQuirurgica");
            entity.Property(e => e.Patologia)
                .HasMaxLength(100)
                .HasColumnName("patologia");

            entity.HasOne(d => d.FkDoctorNavigation).WithMany(p => p.Procquirurgicos)
                .HasForeignKey(d => d.FkDoctor)
                .HasConstraintName("procquirurgico_ibfk_2");

            entity.HasOne(d => d.FkHistoriaNavigation).WithOne(p => p.Procquirurgico)
                .HasForeignKey<Procquirurgico>(d => d.FkHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procquirurgico_ibfk_1");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.IdReligion).HasName("PRIMARY");

            entity.ToTable("religion");

            entity.Property(e => e.IdReligion).HasColumnName("idReligion");
            entity.Property(e => e.NombreReligion)
                .HasMaxLength(30)
                .HasColumnName("nombreReligion");
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

        modelBuilder.Entity<Solicitudexamene>(entity =>
        {
            entity.HasKey(e => e.FkFicha).HasName("PRIMARY");

            entity.ToTable("solicitudexamenes");

            entity.HasIndex(e => e.FkDoctor, "fkDoctor");

            entity.Property(e => e.FkFicha)
                .ValueGeneratedNever()
                .HasColumnName("fkFicha");
            entity.Property(e => e.Estudios)
                .HasColumnType("text")
                .HasColumnName("estudios");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fechaHora");
            entity.Property(e => e.FkDoctor).HasColumnName("fkDoctor");
            entity.Property(e => e.TipoSolicitud).HasColumnName("tipoSolicitud");

            entity.HasOne(d => d.FkDoctorNavigation).WithMany(p => p.Solicitudexamenes)
                .HasForeignKey(d => d.FkDoctor)
                .HasConstraintName("solicitudexamenes_ibfk_2");

            entity.HasOne(d => d.FkFichaNavigation).WithOne(p => p.Solicitudexamene)
                .HasForeignKey<Solicitudexamene>(d => d.FkFicha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudexamenes_ibfk_1");
        });

        modelBuilder.Entity<Tipoasentamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipoasentamiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipovialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipovialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
