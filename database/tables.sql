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

CREATE TABLE tipo_vialidad(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE tipo_asentamiento(
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

CREATE TABLE pacientes(
	folio VARCHAR(13),
    nombre VARCHAR(50),
    primer_apellido VARCHAR(50),
    segundo_apellido VARCHAR(50),
    curp VARCHAR(18),
    fecha_nacimiento DATETIME,
    entidad_nacimiento VARCHAR(30),
    edad INTEGER,
    nacido_hospital BOOLEAN,
    fk_sexo INTEGER, -- llave foranea
    peso FLOAT,
    talla INTEGER,
    fk_estado_conyugal INTEGER, -- llave foranea
    insabi BOOLEAN,
    gratuitidad BOOLEAN,
    indigena BOOLEAN,
    lengua_indigena BOOLEAN,
    cual_lengua VARCHAR(30),
    fk_tipo_vialidad INTEGER, -- llave foranea
    nombre_vialidad VARCHAR(30),
    num_ext VARCHAR(10),
    num_int VARCHAR(10),
    fk_tipo_asentamiento INTEGER, -- llave foranea
    nombre_asentamiento VARCHAR(50),
    cp BIGINT,
    localidad VARCHAR(50),
    municipio_deleg VARCHAR(50),
    entidad_federativa VARCHAR(50),
    pais VARCHAR(50),
    telefono BIGINT,
    PRIMARY KEY(folio),
    FOREIGN KEY(fk_sexo) REFERENCES sexo(id),
    FOREIGN KEY(fk_estado_conyugal) REFERENCES estado_conyugal(id),
    FOREIGN KEY(fk_tipo_vialidad) REFERENCES tipo_vialidad(id),
    FOREIGN KEY(fk_tipo_asentamiento) REFERENCES tipo_asentamiento(id)
);

CREATE TABLE admisiones(
	folio INTEGER AUTO_INCREMENT,
    nombre VARCHAR(50),
    primer_apellido VARCHAR(50),
    segundo_apellido VARCHAR(50),
    curp VARCHAR(18),
    fecha_nacimiento DATETIME,
    entidad_nacimiento VARCHAR(30),
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
    entidad_federativa VARCHAR(50),
    pais VARCHAR(50),
    telefono BIGINT,
    PRIMARY KEY(folio),
    FOREIGN KEY(fk_sexo) REFERENCES sexo(id),
    FOREIGN KEY(fk_tipo_vialidad) REFERENCES tipo_vialidad(id),
    FOREIGN KEY(fk_tipo_asentamiento) REFERENCES tipo_asentamiento(id)
);