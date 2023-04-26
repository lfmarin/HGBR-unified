CREATE DATABASE IF NOT EXISTS hospital;
USE hospital;

-- CATALOGOS
CREATE TABLE Turno (
	idTurno VARCHAR(2) NOT NULL,
    NombreTurno VARCHAR(12),
    PRIMARY KEY(idTurno)
);

CREATE TABLE Sexo (
	idSexo VARCHAR(2) NOT NULL,
    NombreSexo VARCHAR(20),
    PRIMARY KEY(idSexo)
);

CREATE TABLE Ocupacion(
	idOcupacion INT NOT NULL AUTO_INCREMENT,
    NombreOcupacion VARCHAR(70),
    PRIMARY KEY (idOcupacion)
);

CREATE TABLE EstadoCivil(
	idEstadoCivil INT NOT NULL AUTO_INCREMENT,
    NombreEstado varchar(50),
    PRIMARY KEY (idEstadoCivil)
);

CREATE TABLE Municipio (
	idMunicipio INT NOT NULL AUTO_INCREMENT,
    NombreMunicipio VARCHAR(60),
    PRIMARY KEY(idMunicipio)
);

CREATE TABLE Habiencia (
	idHabiencia INT NOT NULL AUTO_INCREMENT,
    NombreHabiencia VARCHAR(20),
    PRIMARY KEY(idHabiencia)
);

-- TABLAS DEL DOCUMENTO
CREATE TABLE Pacientes(
	CURP VARCHAR(20) NOT NULL,
	NumExpediente VARCHAR(15),
    Nombre VARCHAR(50),
    apPaterno VARCHAR(50),
    apMaterno VARCHAR(50),
    fkSexo VARCHAR(2),
    FechaNac DATE,
    Edad TINYINT,
    fkOcupacion INT,
    fkEstadoCivil INT,
    Direccion TEXT,
    fkMunicipio INT,
    Telefono VARCHAR(12),
    NombreFamiliar VARCHAR(60),
    TelefonoFamiliar VARCHAR(23),
    -- DerechoHabiencia TEXT,
    FOREIGN KEY(fkSexo) REFERENCES Sexo(idSexo),
    FOREIGN KEY(fkOcupacion) REFERENCES Ocupacion(idOcupacion),
    FOREIGN KEY(fkEstadoCivil) REFERENCES EstadoCivil(idEstadoCivil),
    FOREIGN KEY(fkMunicipio) REFERENCES Municipio(idMunicipio),
    PRIMARY KEY(CURP)
);

-- Realacion ¿Multivalor?
CREATE TABLE Paciente_Habiencia (
	CURP VARCHAR(20),
    idHabiencia INT,
    FOREIGN KEY(CURP) REFERENCES Pacientes(CURP),
    FOREIGN KEY(idHabiencia) REFERENCES Habiencia(idHabiencia)
);


CREATE TABLE Admisiones (
	FolioAdmision VARCHAR(12),
    Fecha DATE,
    Hora TIME,
    Turno VARCHAR(2),
    CURP VARCHAR(20),
    MotivoConsulta TEXT,
    INEFrente BLOB,
    INEVuelta BLOB,
    CURPFoto BLOB,
    IMSS BLOB,
    ISSSTE BLOB,
    ActaNac BLOB,
    CompDomicilio BLOB,
    FOREIGN KEY(CURP) REFERENCES Pacientes(CURP),
    PRIMARY KEY(FolioAdmision)
);