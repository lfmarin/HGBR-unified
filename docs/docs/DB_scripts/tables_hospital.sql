CREATE DATABASE IF NOT EXISTS hospital_boca;
USE hospital_boca;

CREATE TABLE EstadoCivil(
	idEstadoCivil int not null auto_increment,
    nombreEstado varchar(30),
    primary key (idEstadoCivil)
);

CREATE TABLE Escolaridad(
	idEscolaridad int not null auto_increment,
    nombreEscolaridad varchar(30),
    primary key (idEscolaridad)
);

CREATE TABLE Ocupacion(
	idOcupacion int not null auto_increment,
    nombreOcupacion varchar(70),
    primary key (idOcupacion)
);
CREATE TABLE Religion(
	idReligion int not null auto_increment,
    nombreReligion varchar(30),
    primary key (idReligion)
);

CREATE TABLE LugarReferencia(
	idLugar int not null auto_increment,
    nombreLugar varchar(70),
    primary key (idLugar)
);

CREATE TABLE OpinionPareja(
	idOpinion int not null auto_increment,
    nombreOpinion varchar(30),
    primary key (idOpinion)
);

CREATE TABLE MetodoPlanificacion(
	idMetodo int not null auto_increment,
    nombreMetodo varchar(30),
    primary key (idMetodo)
);

CREATE TABLE CalidadServicio(
	idCalidad int not null auto_increment,
    nombreCalidad varchar(10),
    primary key (idCalidad)
);

CREATE TABLE CalidadRelacion(
	idCalidadRelacion int not null auto_increment,
    nombreCalidadRelacion varchar(10),
    primary key (idCalidadRelacion)
);

#--------------

CREATE TABLE Pacientes(
	noExpediente varchar(15) not null,
    nombre varchar(50),
    apPaterno varchar(50),
    apMaterno varchar(50),
    fechaNac date,
    fkEstadoCivil int, 
    ivs int,
    fkEscolaridad int,
    fkOcupacion int,
    fkReligion int,
    fkLugarReferencia int,
    numHijosVivos int,
    edadHijoMenor int,
    nombreEsposa varchar(100),
    aosRelac int,
    calleCasa varchar(50),
    numCasa int,
    colCasa varchar(50),
    telCasa varchar(12),
    calleTrabajo varchar(50),
    numTrabajo int,
    colTrabajo varchar(50),
    telTrabajo varchar(12),
    primary key (noExpediente),
    foreign key (fkEstadoCivil) references EstadoCivil(idEstadoCivil),
    foreign key (fkEscolaridad) references Escolaridad(idEscolaridad),
    foreign key (fkOcupacion) references Ocupacion(idOcupacion),
    foreign key (fkReligion) references Religion(idReligion),
    foreign key (fkLugarReferencia) references LugarReferencia(idLugar)
);

CREATE TABLE Hospitales(
	idHospital int not null auto_increment,
    entidadFederativa varchar(20),
    jurSanitaria varchar(6),
    uMedica varchar(70),
    primary key (idHospital)
);

CREATE TABLE Doctores(
	idDoctor int not null auto_increment,
    nombre varchar(50),
    apPaterno varchar(50),
    apMaterno varchar(50),
    primary key (idDoctor)
);

CREATE TABLE PersonalConsejeria(
	idPersonal int not null auto_increment,
    nombre varchar(50),
    apPaterno varchar(50),
    apMaterno varchar(50),
    primary key (idPersonal)
);

CREATE TABLE HistoriaClinica(
	idHistoriaClinica int not null auto_increment,
	fkPaciente varchar(15),
    fkHospital int,
    fechaElab date,
    primary key (idHistoriaClinica),
    foreign key (fkPaciente) references Pacientes(noExpediente),
    foreign key (fkHospital) references Hospitales(idHospital)
);

CREATE TABLE MotivoSolicitud(
	fkHistoria int,
    causaNoHijos varchar(60),
    fkOpinion int,
    fkMetodoPlanificacion int,
    primary key (fkHistoria),
    foreign key (fkHistoria) references HistoriaClinica(idHistoriaClinica),
    foreign key (fkOpinion) references OpinionPareja(idOpinion),
    foreign key (fkMetodoPlanificacion) references MetodoPlanificacion(idMetodo)
    
);

CREATE TABLE HistoriaExploracion(
	fkHistoria int,
    antFamiliares varchar(100),
    antPersonalesNoPat varchar(100),
    antPersonalesPat varchar(100),
    ta varchar(10),
    peso varchar(10),
    talla varchar(10),
    fc varchar(10),
    fr varchar(10),
    tem varchar(10),
    expOrganos varchar(40),
    tipoPaciente varchar(40),
    primary key (fkHistoria),
    foreign key (fkHistoria) references HistoriaClinica(idHistoriaClinica)    
);

CREATE TABLE ProcQuirurgico(
	fkHistoria int,
    fechaCirugia date,
    fkDoctor int,
    notaQuirurgica varchar(100),
    patologia varchar(100),
    primary key (fkHistoria),
    foreign key (fkHistoria) references HistoriaClinica(idHistoriaClinica),
    foreign key (fkDoctor) references Doctores(idDoctor)
);

CREATE TABLE EstudioAnatomo(
	fkHistoria int,
    fechaEnvio date,
    clave varchar(50),
    resultado varchar(50),
    primary key (fkHistoria),
    foreign key (fkHistoria) references HistoriaClinica(idHistoriaClinica)
);

CREATE TABLE Evolucion(
	fkHistoria int,
    complicaciones varchar(100),
    espermaconteo bool, 
    fecha1 date,
    resultado1 varchar(50),
    fecha2 date,
    resultado2 varchar(50),
    primary key (fkHistoria),
    foreign key (fkHistoria) references HistoriaClinica(idHistoriaClinica)
);

CREATE TABLE FichaIdentificacion(
	idFicha int not null auto_increment,
    fkPaciente varchar(15),
    servicio varchar(20),
    diagnostico varchar(50),
    primary key (idFicha),
    foreign key (fkPaciente) references Pacientes(noExpediente)
);

CREATE TABLE NotaMedica(
	idNota int not null auto_increment,
	fkFicha int, 
    fechaHora datetime,
    signosVitales varchar(100),
    diagnosticoPre varchar(100),
    cirugiaProgramada varchar(100),
    fechaCirugia date,
    tipoAnestesia varchar(50),
    preparacion varchar(100),
    fkDoctor int,
    diagnosticoPost varchar(100),
    complicaciones varchar(100),
    descripcion text,
    primary key (idNota),
    foreign key (fkFicha) references FichaIdentificacion(idFicha),
    foreign key (fkDoctor) references Doctores(idDoctor)
);

CREATE TABLE CartaConsentimiento(
	fkFicha int,
    fkHospital int,
    fechaHora datetime,
    fkConsejeria int,
    testigo1 varchar(100),
    testigo2 varchar(100),
    fkDoctor int,
    primary key (fkFicha),
    foreign key (fkFicha) references FichaIdentificacion(idFicha),
    foreign key (fkHospital) references Hospitales(idHospital),
    foreign key (fkConsejeria) references PersonalConsejeria(idPersonal),
    foreign key (fkDoctor) references Doctores(idDoctor)
);

CREATE TABLE InstruccionesPost(
	fkFicha int,
    fkDoctor int,
	fkHospital int,
    primary key (fkFicha),
    foreign key (fkFicha) references FichaIdentificacion(idFicha),
    foreign key (fkHospital) references Hospitales(idHospital),
    foreign key (fkDoctor) references Doctores(idDoctor)
);

CREATE TABLE EncuestaSeguimiento(
	fkPaciente varchar(15),
    fkHospital int,
    fechaEncuesta date,
    fechaVasectomia date,
    origenInfo varchar(50),
    fkConsejeria int,
    referido bool,
    fkHospitalReferencia int,
    fkCalidad int,
    satisfaccion bool,
    motivoSatisfaccion varchar(50),
    complicacion bool,
    motivoComplicacion varchar(50),
    fkCalidadRelacion int,
    motivoCalidad varchar(50),
    fechaNegativo date,
	LugarEspermaconteo varchar(50),
    recomendacion bool,
    motivoRecomendacion varchar(50),
    LugarVasectomia bool,
    motivoLugar varchar(50),
    recomendacionHospital bool,
    cualRecomendacion varchar(100),
    primary key (fkPaciente),
    foreign key (fkPaciente) references Pacientes(noExpediente),
    foreign key (fkHospital) references Hospitales(idHospital),
    foreign key (fkConsejeria) references PersonalConsejeria(idPersonal),
    foreign key (fkHospitalReferencia) references Hospitales(idHospital),
    foreign key (fkCalidad) references CalidadServicio(idCalidad),
    foreign key (fkCalidadRelacion) references CalidadRelacion(idCalidadRelacion)
);

CREATE TABLE SolicitudExamenes(
	fkFicha int,
    fechaHora datetime,
    tipoSolicitud bool,
    fkDoctor int,
    estudios text,
    primary key (fkFicha),
    foreign key (fkFicha) references FichaIdentificacion(idFicha),
    foreign key (fkDoctor) references Doctores(idDoctor)
);

