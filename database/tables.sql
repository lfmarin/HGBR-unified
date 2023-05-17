CREATE DATABASE hgbr; 

USE hgbr;

-- CATALOGOS
CREATE TABLE sexo(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(1),
    PRIMARY KEY(id)
);

CREATE TABLE estado_conyugal(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE tipovialidad(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE tipoasentamiento(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE estados(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(60),
    PRIMARY KEY(id)
);

-- TABLAS

CREATE TABLE pacientesArch(
	noExpediente VARCHAR(13),
    nombre VARCHAR(80),
    apPaterno VARCHAR(50),
    apMaterno VARCHAR(50),
    curp VARCHAR(18),
    fechaNac DATE,
    horaNac TIME,
    entidadNac VARCHAR(30),
    edadYears INTEGER,
    edadMonths INTEGER,
    edadDays INTEGER,
    edadHours INTEGER,
    nacidoHospital BOOLEAN,
    fkSexo INTEGER, -- llave foranea
    peso FLOAT,
    talla INTEGER,
    fkEstadoCivil INTEGER, -- llave foranea
    insabi BOOLEAN,
    gratuitidad BOOLEAN,
    indigena BOOLEAN,
    lenguaIndigena BOOLEAN,
    cualLengua VARCHAR(30),
    fkTipoCalleCasa INTEGER, -- llave foranea
    calleCasa VARCHAR(30),
    numCasa VARCHAR(10),
    numCasaInt VARCHAR(10),
    fkTipoColCasa INTEGER, -- llave foranea
    colCasa VARCHAR(50),
    cp BIGINT,
    localidad VARCHAR(50),
    municipio VARCHAR(50),
    entidadFederativa VARCHAR(50),
    pais VARCHAR(50),
    telCasa BIGINT,
    PRIMARY KEY(noExpediente),
    FOREIGN KEY(fkSexo) REFERENCES sexo(id),
    FOREIGN KEY(fkEstadoCivil) REFERENCES estadocivil(idEstadoCivil),
    FOREIGN KEY(fkTipoCalleCasa) REFERENCES tipovialidad(id),
    FOREIGN KEY(fkTipoColCasa) REFERENCES tipoasentamiento(id)
);

/*
ALTER TABLE pacientes
RENAME COLUMN edad TO edad_years,
MODIFY COLUMN fecha_nacimiento DATE,
ADD COLUMN hora_nacimiento TIME,
ADD COLUMN edad_months INTEGER,
ADD COLUMN edad_days INTEGER,
-- RENAME COLUMN edad_minutes TO edad_days, COMANDO PARA JOSUE!!!
ADD COLUMN edad_hours INTEGER;
*/

CREATE TABLE admisiones(
	folio INTEGER AUTO_INCREMENT,
    nombre VARCHAR(50),
    primer_apellido VARCHAR(50),
    segundo_apellido VARCHAR(50),
    curp VARCHAR(18),
    fecha_nacimiento DATETIME,
    entidad_nacimiento VARCHAR(30),
    -- fk_entidad_nacimiento INTEGER,
    edad INTEGER,
    fk_sexo INTEGER, -- llave foranea
    insabi BOOLEAN,
    gratuitidad BOOLEAN,
    fk_tipo_vialidad INTEGER, -- llave foranea
    nombre_vialidad VARCHAR(30),
    num_ext VARCHAR(10),
    num_int VARCHAR(10),
    fk_tipo_asentamiento INTEGER, -- llave foranea
    nombre_asentamiento VARCHAR(50),
    cp BIGINT,
    localidad VARCHAR(50),
    municipio_deleg VARCHAR(50),
    -- entidad_federativa VARCHAR(50),
	fk_entidad_federativa INTEGER,
    pais VARCHAR(50),
    telefono BIGINT,
    PRIMARY KEY(folio),
    FOREIGN KEY(fk_sexo) REFERENCES sexo(id),
    FOREIGN KEY(fk_tipo_vialidad) REFERENCES tipo_vialidad(id),
    FOREIGN KEY(fk_tipo_asentamiento) REFERENCES tipo_asentamiento(id)
    -- FOREIGN KEY(fk_entidad_nacimiento) REFERENCES estados(id),
	-- FOREIGN KEY(fk_entidad_federativa) REFERENCES estados(id)
);